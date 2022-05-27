using eShop.Entities.Base;
using System.Collections.Generic;

namespace eShop.Entities
{
	public class Product : BaseEntity
	{
		public Product()
		{
			this.OrderProducts = new List<OrderProduct>();
			this.CategoryProducts = new List<CategoryProduct>();
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageURL { get; set; }

		public virtual ICollection<OrderProduct> OrderProducts { get; set; }
		public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
	}
}
