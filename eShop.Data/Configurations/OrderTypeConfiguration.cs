using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Data.Configurations
{
	public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasOne(x => x.User)
				.WithMany(x => x.Orders)
				.HasForeignKey(x => x.UserId);

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
