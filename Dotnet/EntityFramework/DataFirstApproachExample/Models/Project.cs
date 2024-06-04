using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataFirstApproachExample.Models
{
    [Table("projects")]
    public partial class Project
    {
        public Project()
        {
            Members = new HashSet<Member>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(255)]
        [Unicode(false)]
        public string Title { get; set; } = null!;

        [InverseProperty(nameof(Member.Project))]
        public virtual ICollection<Member> Members { get; set; }
    }
}
