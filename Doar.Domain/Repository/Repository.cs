using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using Dapper;
using Doar.Domain.Interfaces.Repository;
using Doar.Domain.Context;

namespace Doar.Domain.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    { 
        protected DoarContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(DoarContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            return DbSet.Add(obj);
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            return obj;
        }

        public virtual TEntity Update(TEntity entity, int id)
        {
            var attached = DbSet.Find(id);

            if (attached == null)
                throw new ArgumentOutOfRangeException(nameof(entity));

            var entry = Db.Entry(attached);
            entry.CurrentValues.SetValues(entity);

            return entity;
        }

        public virtual TEntity Update(TEntity entity, string id)
        {
            var attached = DbSet.Find(id);

            if (attached == null)
                throw new ArgumentOutOfRangeException(nameof(entity));

            var entry = Db.Entry(attached);
            entry.CurrentValues.SetValues(entity);

            return entity;
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(object id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Remover(object id)
        {
            var entity = ObterPorId(id);
            if (entity != null) DbSet.Remove(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public int TotalDeRegistro()
        {
            return DbSet.Count();
        }

        public ICollection<T> AdicionarColection<T>(ICollection<T> viewModel, ICollection<T> dominio, Expression<Func<T, object>> idEntity, IRepository<T> repository) where T : class
        {
            var retorno = new Collection<T>();
            var ids = dominio.Select(item => (int) idEntity.Compile()(item)).ToList();

            foreach (var item in viewModel)
            {
                var id = (int)idEntity.Compile()(item);
                if (ids.Contains(id))
                {
                    var entry = repository.ObterPorId(id);
                    Db.Entry(entry).CurrentValues.SetValues(item);
                    retorno.Add(entry);
                }
                else
                    retorno.Add(item);
                ids.Remove(id);
            }
            ids.ForEach(x=>{repository.Remover(x);});
            return retorno;
        }

        public virtual TEntity ObterPorIdSemRelacionamento(int id)
        {
            return DbSet.Find(id);
        }

        public virtual bool VarificarSeEntidadePossuiRelacionamento(int id)
        {
            return ObterRelacionamentosDaEntidade(id).Count > 0;
        }

        public virtual List<string> ObterRelacionamentosDaEntidade(int id)
        {
            var tabela = typeof(TEntity).Name;
            var results = Db.Database.Connection.Query<string>(@"declare @RowId int = " + id + @"
                                                                 declare @TableName sysname = '" + tabela + @"'
                                                                 declare @Command varchar(max)
                                                                 select @Command = isnull(@Command + ' union all ', '') + 'select ''' + object_name(parent_object_id) +
                                                                     ''' where exists(select * from ' + object_name(parent_object_id) + ' where ' + col.name + ' = ' + cast(@RowId as varchar) + ')'
                                                                 from sys.foreign_key_columns fkc
                                                                     join sys.columns col on
                                                                         fkc.parent_object_id = col.object_id and fkc.parent_column_id = col.column_id
                                                                 where object_name(referenced_object_id) = @TableName
                                                                 execute(@Command)");
            return results.ToList();
        }
        
    }
}
