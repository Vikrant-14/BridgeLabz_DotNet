using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    public partial class staff
    {
        public staff()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }
        [Column("phone")]
        [StringLength(20)]
        public string? Phone { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("store_id")]
        public int? StoreId { get; set; }
        [Column("manager_id")]
        public int? ManagerId { get; set; }

        [InverseProperty(nameof(Order.Staff))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
