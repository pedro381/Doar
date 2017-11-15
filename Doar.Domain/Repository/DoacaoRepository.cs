using BoletoNet;
using Doar.Domain.Context;
using Doar.Domain.Interfaces.Repository;
using Doar.Entity.Entities;
using Doar.Session;
using System.Linq;

namespace Doar.Domain.Repository
{
    public class DoacaoRepository : Repository<Doacao>, IDoacaoRepository
    {
        public DoacaoRepository(DoarContext context) : base(context)
        {
        }

        public string GerarBoleto(int id)
        {
            var doacao = Db.Doacoes.Find(id);
            if (doacao == null || doacao.UsuarioId != UsuarioSession.Usuario?.UsuarioId) return null;
            var cliente = Db.Clientes.First();

            var c = new Cedente(cliente.Cnpj, cliente.Nome, cliente.Agencia, cliente.Conta);

            var b = new Boleto(doacao.Vencimento, doacao.Valor, cliente.Carteira, cliente.NossoNumero, c, new EspecieDocumento(341, "1"))
            {
                NumeroDocumento = id.ToString(),

                Sacado = new Sacado(UsuarioSession.Usuario.Cpf, UsuarioSession.Usuario.Nome)
            };

            var usuario = Db.Usuarios.Find(UsuarioSession.Usuario.UsuarioId);
            Db.Entry(usuario).Reference(x => x.Endereco).Load();
            b.Sacado.Endereco = new BoletoNet.Endereco
            {
                End = usuario.Endereco.End,
                Numero = usuario.Endereco.Numero,
                Complemento = usuario.Endereco.Complemento,
                Bairro = usuario.Endereco.Bairro,
                Cidade = usuario.Endereco.Cidade,
                UF = usuario.Endereco.UF,
                CEP = usuario.Endereco.CEP,
                Email = usuario.Endereco.Email
            };
            var boletoBancario = new BoletoBancario
            {
                CodigoBanco = 341,
                Boleto = b
            };
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }
    }
}
