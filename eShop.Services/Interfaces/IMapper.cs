using eShop.Entities.Interfaces;

namespace eShop.Services.Interfaces
{
    public interface IMapper<TEntity, TModel>
        where TEntity : IBaseEntity
        where TModel : IBaseModel
    {
        TEntity ToEntity(TModel model);
        TModel ToModel(TEntity entity);
    }
}
