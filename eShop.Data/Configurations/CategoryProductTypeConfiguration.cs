using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Data.Configurations
{
	public class CategoryProductTypeConfiguration : IEntityTypeConfiguration<CategoryProduct>
	{
		public void Configure(EntityTypeBuilder<CategoryProduct> builder)
		{
			builder.HasOne(c => c.Category)
				.WithMany(cp => cp.CategoryProducts)
				.HasForeignKey(x => x.CategoryId);

			builder.HasOne(c => c.Product)
				.WithMany(cp => cp.CategoryProducts)
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
