using eShop.Entities.Base;
using System;

namespace eShop.Entities
{
	public class CategoryProduct : BaseEntity
	{
		public Guid CategoryId { get; set; }
		public Category Category { get; set; }
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
