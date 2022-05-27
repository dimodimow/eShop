using eShop.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace eShop.Entities
{
	public class User : IdentityUser<Guid>, IBaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public User CreatedBy { get; set; }
		public User ModifiedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool IsDeleted { get; set; }

		public virtual Address Address { get; set; }
	}
}
