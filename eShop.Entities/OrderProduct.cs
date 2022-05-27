using eShop.Entities.Base;
using System;

namespace eShop.Entities
{
	public class OrderProduct : BaseEntity
	{
		public Guid OrderId { get; set; }
		public virtual Order Order { get; set; }
		public Guid ProductId { get; set; }
		public virtual Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}