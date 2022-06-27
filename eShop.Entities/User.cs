using eShop.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public Guid CreatedById { get; set; }
        public Guid ModifiedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
