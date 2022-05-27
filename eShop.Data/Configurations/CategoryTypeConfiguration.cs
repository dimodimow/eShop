using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Data.Configurations
{
	public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasOne(x => x.ParentCategory)
				.WithMany()
				.HasForeignKey(x => x.ParentCategoryId)
				.OnDelete(DeleteBehavior.Restrict);

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
