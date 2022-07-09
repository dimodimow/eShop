using eShop.Entities;
using eShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class CategoryController : OverviewController
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet(nameof(GetAllAsync))]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await this.categoryService.GetAllAsync(null);

            return categories;
        }
    }
}