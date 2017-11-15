using Doar.Entity.Entities;
using Doar.Entity.EntitiesSearch;
using System.Collections.Generic;

namespace Doar.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<UsuarioResultadoPesquisa> PerquisarUsuarioPorParametos(UsuarioPesquisa usuario, out int totalRows);
        Usuario ObterUsuarioPorEmail(string email);
        Usuario ObterUsuarioPorIdString(string id);
    }
}