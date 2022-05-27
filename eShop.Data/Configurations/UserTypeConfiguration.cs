using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Data.Configurations
{
	public class UserTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasOne(a => a.Address)
					.WithMany(u => u.Users)
					.HasForeignKey(x => x.AddressId)
					.OnDelete(DeleteBehavior.Cascade);

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
