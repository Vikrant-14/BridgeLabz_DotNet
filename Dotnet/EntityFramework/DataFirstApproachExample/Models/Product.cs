using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Category { get; set; } = null!;
        [StringLength(255)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [Column("model_year")]
        public int? ModelYear { get; set; }
    }
}
