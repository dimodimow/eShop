using eShop.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace eShop.Entities
{
	public class Address : BaseEntity
	{
		[Required]
		public string Country { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string ZIP { get; set; }
		[Required]
		public string Street { get; set; }
		public string Floor { get; set; }
		public Guid UserId { get; set; }
		public virtual User User { get; set; }
	}
}
