using eShop.Common.Enums;
using eShop.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eShop.Entities
{
	public class Order : BaseEntity
	{
		public Order()
		{
			this.OrderProducts = new List<OrderProduct>();
		}

		public Guid UserId { get; set; }
		public virtual User User { get; set; }
		[Required]
		public OrderStatuses OrderStatus { get; set; }
		[Required]
		public OrderPaymentTypes OrderPaymentType { get; set; }
		public decimal TotalPrice { get { return this.OrderProducts.Sum(x => x.Price * x.Quantity); } }
		public virtual ICollection<OrderProduct> OrderProducts { get; set; }
	}
}