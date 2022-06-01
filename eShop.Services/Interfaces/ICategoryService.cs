using eShop.Entities;
using eShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Services.Interfaces
{
	public interface ICategoryService
	{
		Task CreateAsync(CreateCategoryModel model);
		Task UpdateAsync(Category entity);
		Task DeleteAsync(Guid id);
		Task ForceDeleteAsync(Guid id);
		Task<Category> GetByIdAsync(Guid id);
		Task<IEnumerable<Category>> GetAllAsync(string includings, string orderBy);
	}
}
