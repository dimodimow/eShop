using eShop.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Entities
{
	public class Category : BaseEntity
	{
		public Category()
		{
			this.CategoryProducts = new List<CategoryProduct>();
		}

		public string Name { get; set; }

		public Guid ParentCategoryId { get; set; }
		public Category ParentCategory { get; set; }

		public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
	}
}
