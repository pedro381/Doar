using Doar.Domain.Context;
using Doar.Domain.Interfaces.Repository;
using Doar.Entity.Entities;

namespace Doar.Domain.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DoarContext context) : base(context)
        {
        }        

        public override Cliente Atualizar(Cliente Cliente)
        {
            var dominio = Db.Clientes.Find(Cliente.ClienteId);
            if (dominio == null) return null;
            dominio.Nome = Cliente.Nome;
            dominio.Cnpj = Cliente.Cnpj;
            dominio.Agencia = Cliente.Agencia;
            dominio.Conta = Cliente.Conta;
            dominio.Carteira = Cliente.Carteira;
            dominio.NossoNumero = Cliente.NossoNumero;
            return dominio;
        }        
    }
}
