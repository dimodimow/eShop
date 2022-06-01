using eShop.Services.Models;
using System;

namespace eShop.Services.Interfaces
{
	public interface IBaseModel
	{
		public Guid Id { get; set; }
		public UserModel CreatedBy { get; set; }
		public UserModel ModifiedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool IsDeleted { get; set; }
	}
}
