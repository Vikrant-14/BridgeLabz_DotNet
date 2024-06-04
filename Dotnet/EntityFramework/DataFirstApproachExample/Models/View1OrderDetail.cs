using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Keyless]
    public partial class View1OrderDetail
    {
        [Column("customer_name")]
        [StringLength(101)]
        public string? CustomerName { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("order_date", TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column("staff_name")]
        [StringLength(101)]
        public string? StaffName { get; set; }
        [Column("staff_number")]
        [StringLength(20)]
        public string? StaffNumber { get; set; }
    }
}
