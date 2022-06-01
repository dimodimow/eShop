using eShop.Data;
using eShop.Entities;
using eShop.Repositories.Base;
using eShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace eShop.Repositories.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private EShopDbContext context;
		private UserManager<User> userManager;

		public UnitOfWork(EShopDbContext context, UserManager<User> userManager)
		{
			this.context = context;
			this.userManager = userManager;

			this.CategoryRepository = new Repository<Category>(context);
			this.OrderRepository = new Repository<Order>(context);
			this.ProductRepository = new Repository<Product>(context);
			this.UserRepository = new UserRepository(context, userManager);
		}

		public IRepository<Category> CategoryRepository { get; set; }
		public IRepository<Order> OrderRepository { get; set; }
		public IRepository<Product> ProductRepository { get; set; }
		public IUserRepository UserRepository { get; set; }

		public void Dispose()
		{
			context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await context.SaveChangesAsync() > 0;
		}
	}

}
