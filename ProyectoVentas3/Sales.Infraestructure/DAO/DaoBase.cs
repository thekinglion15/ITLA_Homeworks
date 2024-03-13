using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.DAO
{
    public abstract class DaoBase<TEntity> : IDaoBase<TEntity> where TEntity : class
    {
        private readonly SalesContext context;
        private DbSet<TEntity> entities;

        public DaoBase(SalesContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> GetAll()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return this.entities.Find(id);
        }

        public virtual DataResult Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Add(entity);

            result.Success = true;

            return result;
        }

        public virtual List<TEntity> GetEntitiesWithFilters(Func<TEntity, bool> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual DataResult Update(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Update(entity);

            result.Success = true;

            return result;
        }

        public virtual int Commit()
        {
            return this.context.SaveChanges();
        }
    }
}
