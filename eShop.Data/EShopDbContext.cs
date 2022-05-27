using eShop.Data.Configurations;
using eShop.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace eShop.Data
{
	public class EShopDbContext : IdentityDbContext<User, Role, Guid>
	{
		public EShopDbContext(DbContextOptions<EShopDbContext> options)
			: base(options)
		{

		}

		public DbSet<Address> Addresses { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderProduct> OrderProducts { get; set; }
		public DbSet<CategoryProduct> CategoryProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new UserTypeConfiguration());
			builder.ApplyConfiguration(new OrderTypeConfiguration());
			builder.ApplyConfiguration(new AddressTypeConfiguration());
			builder.ApplyConfiguration(new ProductTypeConfiguration());
			builder.ApplyConfiguration(new CategoryTypeConfiguration());
			builder.ApplyConfiguration(new OrderProductTypeConfiguration());
			builder.ApplyConfiguration(new CategoryProductTypeConfiguration());
		}
	}
}
