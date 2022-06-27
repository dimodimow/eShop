using eShop.Entities;
using eShop.Services.Interfaces;
using eShop.Services.Models;
using System.Linq;

namespace eShop.Services.Mappers
{
    public class CategoryMapper : Mapper<Category, CategoryModel>, ICategoryMapper
    {
        public override Category ToEntity(CategoryModel model)
        {
            var entity = base.ToEntity(model);

            entity.Name = model.Name;
            entity.ParentCategoryId = model.ParentCategoryId;
            entity.CategoryProducts = model.CategoryProducts.Select(x => new CategoryProduct()
            {
                CategoryId = x.CategoryId,
                ProductId = x.ProductId
            }).ToList();

            return entity;
        }

        public override CategoryModel ToModel(Category entity)
        {
            var model = base.ToModel(entity);

            model.Name = entity.Name;
            model.ParentCategoryId = entity.ParentCategoryId;
            model.CategoryProducts = entity.CategoryProducts.Select(x => new CategoryProductModel()
            {
                CategoryId = x.CategoryId,
                ProductId = x.ProductId
            }).ToList();

            return model;
        }
    }
}
