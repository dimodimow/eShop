using eShop.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Entities.Base
{
	public class BaseEntity : IBaseEntity
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		[ForeignKey(nameof(CreatedById))]
		public User CreatedBy { get; set; }
		[ForeignKey(nameof(ModifiedById))]
		public User ModifiedBy { get; set; }
		public Guid CreatedById { get; set; }
		public Guid ModifiedById { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool IsDeleted { get; set; }
	}
}
