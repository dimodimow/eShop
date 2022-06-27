using eShop.Entities.Interfaces;
using eShop.Services.Interfaces;

namespace eShop.Services
{
    public class Mapper<TEntity, TModel> : IMapper<TEntity, TModel>
        where TEntity : IBaseEntity, new()
        where TModel : IBaseModel, new()
    {
        public virtual TEntity ToEntity(TModel model)
        {
            return new TEntity()
            {
                Id = model.Id,
                CreatedById = model.CreatedById,
                ModifiedById = model.ModifiedById,
                IsDeleted = model.IsDeleted,
            };
        }

        public virtual TModel ToModel(TEntity entity)
        {
            return new TModel()
            {
                Id = entity.Id,
                CreatedById = entity.CreatedById,
                ModifiedById = entity.ModifiedById,
                IsDeleted = entity.IsDeleted,
            };
        }
    }
}
