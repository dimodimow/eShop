using eShop.Entities;
using System;
using System.Threading.Tasks;

namespace eShop.Repositories.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Category> CategoryRepository { get; set; }
		IRepository<Order> OrderRepository { get; set; }
		IRepository<Product> ProductRepository { get; set; }
		IUserRepository UserRepository { get; set; }

		Task<bool> SaveChangesAsync();
	}
}
