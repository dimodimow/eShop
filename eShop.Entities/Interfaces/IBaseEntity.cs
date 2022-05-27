using System;

namespace eShop.Entities.Interfaces
{
	public interface IBaseEntity
	{
		public Guid Id { get; set; }
		public Guid CreatedById { get; set; }
		public User CreatedBy { get; set; }
		public Guid ModifiedById { get; set; }
		public User ModifiedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool IsDeleted { get; set; }

	}
}
