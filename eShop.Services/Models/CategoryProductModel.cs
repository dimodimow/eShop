using System;

namespace eShop.Services.Models
{
    public class CategoryProductModel : BaseModel
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
    }
}
