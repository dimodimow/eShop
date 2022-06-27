using eShop.Data;
using eShop.Entities.Interfaces;
using eShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eShop.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        private readonly EShopDbContext context;

        private DbSet<TEntity> entities;

        public Repository(EShopDbContext context)
        {
            this.context = context;

            this.entities = context.Set<TEntity>();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await this.entities.AddAsync(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            entity.IsDeleted = true;

            this.entities.Update(entity);
        }

        public virtual void ForceDelete(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string[] includings,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = this.entities.AsQueryable();

            if (includings.Length > 0)
            {
                foreach (var including in includings)
                {
                    query.Include(including);
                }
            }

            if (filter != null)
            {
                query.Where(filter);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await this.entities.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }
    }
}
