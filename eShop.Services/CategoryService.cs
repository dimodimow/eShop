using eShop.Common;
using eShop.Common.Constants;
using eShop.Entities;
using eShop.Repositories.Interfaces;
using eShop.Services.Filters;
using eShop.Services.Interfaces;
using eShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CategoryModel model)
        {
            var isNameAvailable = await this.unitOfWork.CategoryRepository.IsNameAvailable(model.Name);

            if (!isNameAvailable)
            {
                throw new Exception(string.Format(ExceptionMessages.CategoryNameNotAvailable, model.Name));
            }

            var categoryToAdd = mapper.ToEntity(model);

            await this.unitOfWork.CategoryRepository.CreateAsync(categoryToAdd);

            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await this.unitOfWork.CategoryRepository.GetAsync(id);

            Helper.CheckIsEntityNull(category, ExceptionMessages.CategoryIsNull);

            this.unitOfWork.CategoryRepository.Delete(category);

            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task ForceDeleteAsync(Guid id)
        {
            var category = await this.unitOfWork.CategoryRepository.GetAsync(id);

            Helper.CheckIsEntityNull(category, ExceptionMessages.CategoryIsNull);

            this.unitOfWork.CategoryRepository.ForceDelete(category);

            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CategoryQueryParams queryParams)
        {
            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = queryParams == null ? null : this.OrderByFunc(queryParams?.OrderBy);

            var filter = queryParams == null ? null : Filter(queryParams);

            var categories = await this.unitOfWork.CategoryRepository.GetAllAsync(Includings(), filter, orderBy);

            return categories;
        }

        public async Task<Category> GetAsync(Guid id)
        {
            var category = await this.unitOfWork.CategoryRepository.GetAsync(id);

            Helper.CheckIsEntityNull(category, ExceptionMessages.CategoryIsNull);

            return category;
        }

        public async Task UpdateAsync(CategoryModel model)
        {
            var categoryToUpdate = await this.unitOfWork.CategoryRepository.GetAsync(model.Id);

            Helper.CheckIsEntityNull(categoryToUpdate, ExceptionMessages.CategoryIsNull);

            categoryToUpdate.Name = model.Name;
            categoryToUpdate.CategoryProducts = model.CategoryProducts.Select(cp => new CategoryProduct
            {
                CategoryId = cp.CategoryId,
                ProductId = cp.ProductId
            }).ToList();

            this.unitOfWork.CategoryRepository.Update(categoryToUpdate);

            await this.unitOfWork.SaveChangesAsync();
        }

        private static Expression<Func<Category, bool>> Filter(CategoryQueryParams filter)
        {
            Expression<Func<Category, bool>> expressionFilter = category => filter.Name == null || category.Name.Contains(filter.Name);

            return expressionFilter;
        }

        private static Expression<Func<Category, object>>[] Includings()
        {
            return new Expression<Func<Category, object>>[]
            {
                x => x.CreatedBy,
                x => x.ModifiedBy,
                x => x.CategoryProducts
            };
        }

        private Func<IQueryable<Category>, IOrderedQueryable<Category>> OrderByFunc(string orderBy)
        {
            IOrderedQueryable<Category> OrderBy(IQueryable<Category> query)
            {
                var ordered = query.OrderBy(x => x);

                foreach (var item in orderBy.Split(","))
                {
                    switch (item)
                    {
                        case "name":
                            ordered.OrderBy(x => x.Name);
                            break;
                        case "descName":
                            ordered.OrderByDescending(x => x.Name);
                            break;
                    }
                }

                return ordered;
            }

            return OrderBy;
        }
    }
}
