using eShop.Entities.Base;
using System.Collections.Generic;

namespace eShop.Entities
{
	public class Address : BaseEntity
	{
		public string Country { get; set; }
		public string City { get; set; }
		public string ZIP { get; set; }
		public string Street { get; set; }
		public string Floor { get; set; }

		public virtual ICollection<User> Users { get; set; }
	}
}
