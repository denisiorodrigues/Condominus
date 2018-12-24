using DR.Condominus.Infra.Data.Context;
using DR.Domain.Interfaces;
using DR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DR.Condominus.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected CondominusContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new CondominusContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);

            SaveChanges();
        }

        public virtual void Atualizar(TEntity entity)
        {
            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;

            SaveChanges();
        }

        public virtual void Remover(Guid id)
        {
            var entity = new TEntity() { Id = id };
            DbSet.Remove(entity);

            SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
