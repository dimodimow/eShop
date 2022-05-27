using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Data.Configurations
{
	public class OrderProductTypeConfiguration : IEntityTypeConfiguration<OrderProduct>
	{
		public void Configure(EntityTypeBuilder<OrderProduct> builder)
		{
			builder.Property(x => x.Price)
				.HasPrecision(18, 2);

			builder.HasOne(x => x.Order)
				.WithMany(op => op.OrderProducts)
				.HasForeignKey(x => x.OrderId);

			builder.HasOne(x => x.Product)
				.WithMany(op => op.OrderProducts)
				.HasForeignKey(x => x.ProductId);

			builder.HasOne(x => x.CreatedBy)
				.WithMany()
				.HasForeignKey(x => x.CreatedById)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.ModifiedBy)
				.WithMany()
				.HasForeignKey(x => x.ModifiedById)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
