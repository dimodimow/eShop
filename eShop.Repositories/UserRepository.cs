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
			var result = await userManager.CreateAsync(entity);

			if (result.Succeeded)
			{
				await userManager.AddPasswordAsync(entity, password);
				await userManager.AddToRolesAsync(entity, roles);
			}
		}

		public override async void ForceDeleteAsync(User entity)
		{
			await userManager.DeleteAsync(entity);
		}

		public override async void UpdateAsync(User entity)
		{
			await userManager.UpdateAsync(entity);
		}
	}
}
