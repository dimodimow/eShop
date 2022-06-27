using eShop.Data;
using eShop.Entities;
using eShop.Repositories.Base;
using eShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly EShopDbContext context;
        public CategoryRepository(EShopDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<bool> IsNameAvailable(string name)
        {
            var category = await this.context.Categories.Where(c => c.Name.Equals(name)).FirstOrDefaultAsync();

            if (category != null)
            {
                return false;
            }

            return true;
        }
    }
}
