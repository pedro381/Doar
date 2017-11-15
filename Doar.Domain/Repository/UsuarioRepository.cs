using System.Collections.Generic;
using Doar.Domain.Interfaces.Repository;
using Doar.Domain.Context;
using System.Linq;
using Doar.Entity.Entities;
using Doar.Entity.EntitiesSearch;

namespace Doar.Domain.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DoarContext context) : base(context)
        {
        }

        public override Usuario ObterPorId(object id)
        {
            var usuario = Db.Usuarios.Find(id);
            Db.Entry(usuario).Reference(x => x.Endereco).Load();
            return usuario;
        }

        public override Usuario Atualizar(Usuario usuario)
        {
            var dominio = Db.Usuarios.Find(usuario.UsuarioId);
            if (dominio == null) return null;
            Db.Entry(dominio).Reference(x => x.Endereco).Load();
            dominio.EmailConfirmacao = "teste";
            dominio.SenhaConfirmacao = "teste";
            dominio.Nome = usuario.Nome;
            dominio.Nome = usuario.Nome;
            dominio.Cpf = usuario.Cpf;
            dominio.Nascimento = usuario.Nascimento;
            dominio.Telefone = usuario.Telefone;
            dominio.ReceberEmail = usuario.ReceberEmail;
            dominio.Endereco.End = usuario.Endereco.End;
            dominio.Endereco.Numero = usuario.Endereco.Numero;
            dominio.Endereco.Complemento = usuario.Endereco.Complemento;
            dominio.Endereco.Bairro = usuario.Endereco.Bairro;
            dominio.Endereco.Cidade = usuario.Endereco.Cidade;
            dominio.Endereco.UF = usuario.Endereco.UF;
            dominio.Endereco.CEP = usuario.Endereco.CEP;
            return dominio;
        }

        public IEnumerable<UsuarioResultadoPesquisa> PerquisarUsuarioPorParametos(UsuarioPesquisa usuario, out int totalRows)
        {
            var usuarios = Consulta(usuario)
                .OrderBy(x => x.Nome)
                .Skip((usuario.PaginaAtual - 1) * usuario.ItensPorPagina)
                .Take(usuario.ItensPorPagina)
                .ToList();

            var usuarioResultadoPesquisa = new List<UsuarioResultadoPesquisa>();
            usuarios.ForEach(x =>
            {
                var usuarioResult = new UsuarioResultadoPesquisa
                {
                    UsuarioId = x.UsuarioId,
                    Email = x.Email,
                    Nome = x.Nome
                };
                usuarioResultadoPesquisa.Add(usuarioResult);
            });

            totalRows = Consulta(usuario).Count();

            return usuarioResultadoPesquisa;
        }

        private IQueryable<Usuario> Consulta(UsuarioPesquisa usuario)
        {
            var dataCriacaoInicial = usuario.DataCriacaoInicial;
            var dataCriacaoFinal = usuario.DataCriacaoFinal?.AddDays(1);

            return Db.Usuarios.Where(x =>
                (string.IsNullOrEmpty(usuario.Nome) || x.Nome.Contains(usuario.Nome))
                && (string.IsNullOrEmpty(usuario.Email) || x.Email.Contains(usuario.Email))
                && (dataCriacaoInicial == null || x.DataCadastro >= dataCriacaoInicial)
                && (dataCriacaoFinal == null || x.DataCadastro < dataCriacaoFinal));
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            return Db.Usuarios.FirstOrDefault(c => c.Email == email);
        }

        public Usuario ObterUsuarioPorIdString(string id)
        {
            return Db.Usuarios.Find(id);
        }
    }
}
