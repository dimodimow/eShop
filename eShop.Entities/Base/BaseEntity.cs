using eShop.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace eShop.Entities.Base
{
	public class BaseEntity : IBaseEntity
	{
		[Key]
		public Guid Id { get; set; }
		public User CreatedBy { get; set; }
		public User ModifiedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool IsDeleted { get; set; }
	}
}
