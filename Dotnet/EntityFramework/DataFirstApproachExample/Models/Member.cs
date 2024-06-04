using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Table("members")]
    public partial class Member
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("project_id")]
        public int? ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("Members")]
        public virtual Project? Project { get; set; }
    }
}
