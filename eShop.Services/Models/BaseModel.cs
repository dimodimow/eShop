using eShop.Services.Interfaces;
using System;

namespace eShop.Services.Models
{
	public class BaseModel : IBaseModel
	{
		public Guid Id { get; set; }
		public UserModel CreatedBy { get; set; }
		public UserModel ModifiedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool IsDeleted { get; set; }
	}
}
