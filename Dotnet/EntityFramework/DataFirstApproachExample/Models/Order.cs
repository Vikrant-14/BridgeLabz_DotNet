using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Table("orders")]
    public partial class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("order_status")]
        [StringLength(255)]
        [Unicode(false)]
        public string OrderStatus { get; set; } = null!;
        [Column("order_date", TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column("required_date", TypeName = "date")]
        public DateTime RequiredDate { get; set; }
        [Column("shipped_date", TypeName = "date")]
        public DateTime? ShippedDate { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("staff_id")]
        public int StaffId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey(nameof(StaffId))]
        [InverseProperty(nameof(staff.Orders))]
        public virtual staff Staff { get; set; } = null!;
    }
}
