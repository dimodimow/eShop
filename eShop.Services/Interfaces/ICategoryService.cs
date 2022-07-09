using eShop.Entities;
using eShop.Services.Filters;
using eShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryModel model);
        Task UpdateAsync(CategoryModel model);
        Task DeleteAsync(Guid id);
        Task ForceDeleteAsync(Guid id);
        Task<Category> GetAsync(Guid id);
        Task<IEnumerable<Category>> GetAllAsync(CategoryQueryParams queryParams);
    }
}
