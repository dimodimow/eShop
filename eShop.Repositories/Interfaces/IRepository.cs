using eShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eShop.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void ForceDelete(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync(string[] includings,
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}