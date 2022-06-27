using eShop.Common;
using eShop.Common.Constants;
using eShop.Entities;
using eShop.Repositories.Interfaces;
using eShop.Services.Interfaces;
using eShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var category = await this.unitOfWork.CategoryRepository.GetByIdAsync(id);

            Helper.CheckIsEntityNull(category, ExceptionMessages.CategoryIsNull);

            this.unitOfWork.CategoryRepository.Delete(category);

            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task ForceDeleteAsync(Guid id)
        {
            var category = await this.unitOfWork.CategoryRepository.GetByIdAsync(id);

            Helper.CheckIsEntityNull(category, ExceptionMessages.CategoryIsNull);

            this.unitOfWork.CategoryRepository.ForceDelete(category);

            await this.unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<Category>> GetAllAsync(string orderBy)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await this.unitOfWork.CategoryRepository.GetByIdAsync(id);

            Helper.CheckIsEntityNull(category, ExceptionMessages.CategoryIsNull);

            return category;
        }

        public async Task UpdateAsync(CategoryModel model)
        {
            var categoryToUpdate = await this.unitOfWork.CategoryRepository.GetByIdAsync(model.Id);

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
    }
}
