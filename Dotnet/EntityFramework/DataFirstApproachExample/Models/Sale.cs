using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Table("sales")]
    public partial class Sale
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string ProductName { get; set; } = null!;
        [Column("region")]
        [StringLength(255)]
        [Unicode(false)]
        public string Region { get; set; } = null!;
        [Column("amount")]
        public int? Amount { get; set; }
    }
}
