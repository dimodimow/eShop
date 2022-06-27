using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eShop.Services.Models
{
    public class CategoryModel : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual Guid ParentCategoryId { get; set; }

        public virtual List<CategoryProductModel> CategoryProducts { get; set; }
    }
}
