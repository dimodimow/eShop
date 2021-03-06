using eShop.Entities.Base;
using System;

namespace eShop.Entities
{
	public class CategoryProduct : BaseEntity
	{
		public Guid CategoryId { get; set; }
		public virtual Category Category { get; set; }
		public Guid ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}
