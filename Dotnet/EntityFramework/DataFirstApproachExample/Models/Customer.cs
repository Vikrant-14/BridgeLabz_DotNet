using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Table("customers")]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Column("phone")]
        [StringLength(20)]
        public string? Phone { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }
        [Column("street")]
        [StringLength(100)]
        public string? Street { get; set; }
        [Column("city")]
        [StringLength(50)]
        public string? City { get; set; }
        [Column("state")]
        [StringLength(50)]
        public string? State { get; set; }
        [Column("zip_code")]
        [StringLength(10)]
        public string? ZipCode { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
