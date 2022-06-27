using eShop.Data;
using eShop.Entities;
using eShop.Repositories.Base;
using eShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace eShop.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<User> userManager;

        public UserRepository(EShopDbContext context, UserManager<User> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(User entity, string password, string[] roles)
        {
            var result = await this.userManager.CreateAsync(entity);

            if (result.Succeeded)
            {
                await this.userManager.AddPasswordAsync(entity, password);
                await this.userManager.AddToRolesAsync(entity, roles);
            }
        }

        public override async void ForceDelete(User entity)
        {
            await this.userManager.DeleteAsync(entity);
        }

        public async Task<bool> IsEmailAvailable(string email)
        {
            var result = await this.userManager.FindByEmailAsync(email);

            if (result != null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> IsUserNameAvailable(string userName)
        {
            var result = await this.userManager.FindByNameAsync(userName);

            if (result != null)
            {
                return false;
            }

            return true;
        }

        public override async void Update(User entity)
        {
            await this.userManager.UpdateAsync(entity);
        }
    }
}
