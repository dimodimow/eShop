using eShop.Entities;
using eShop.Services.Interfaces;
using eShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Services
{
	public class CategoryService : ICategoryService
	{
		public Task CreateAsync(CreateCategoryModel model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task ForceDeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Category>> GetAllAsync(string includings, string orderBy)
		{
			throw new NotImplementedException();
		}

		public Task<Category> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Category entity)
		{
			throw new NotImplementedException();
		}
	}
}
