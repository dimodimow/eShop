﻿using eShop.Entities.Base;
using System;

namespace eShop.Entities
{
	public class OrderProduct : BaseEntity
	{
		public Guid OrderId { get; set; }
		public Order Order { get; set; }
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}