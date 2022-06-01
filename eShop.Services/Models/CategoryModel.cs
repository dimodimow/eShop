using eShop.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eShop.Services.Models
{
	public class CategoryModel : BaseModel
	{
		public CategoryModel()
		{ }


		[Required]
		public string Name { get; set; }

		public virtual CategoryModel ParentCategory { get; set; }

		public virtual List<CategoryProductModel> CategoryProducts { get; set; }
	}
}
