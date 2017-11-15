using Doar.Entity.Entities;

namespace Doar.Domain.Interfaces.Repository
{
    public interface IDoacaoRepository : IRepository<Doacao>
    {
        string GerarBoleto(int id);
    }
}