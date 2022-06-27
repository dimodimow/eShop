using System;

namespace eShop.Services.Interfaces
{
    public interface IBaseModel
    {
        public Guid Id { get; set; }
        public Guid CreatedById { get; set; }
        public Guid ModifiedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
