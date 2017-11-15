using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Doar.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(object id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        TEntity Update(TEntity entity, int id);
        TEntity Update(TEntity entity, string id);
        TEntity Remover(object id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        int TotalDeRegistro();
        TEntity ObterPorIdSemRelacionamento(int id);
        bool VarificarSeEntidadePossuiRelacionamento(int id);
        List<string> ObterRelacionamentosDaEntidade(int id);
    }
}
