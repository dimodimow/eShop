using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Data.Configurations
{
	public class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.HasMany(x => x.Users)
				.WithOne(x => x.Address);

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
