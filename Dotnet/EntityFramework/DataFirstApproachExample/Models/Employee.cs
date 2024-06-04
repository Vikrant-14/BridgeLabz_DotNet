using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Table("employees")]
    public partial class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("fullname")]
        [StringLength(100)]
        [Unicode(false)]
        public string Fullname { get; set; } = null!;
    }
}
