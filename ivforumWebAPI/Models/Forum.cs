﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ivforumWebAPI.Models
{
    public class Forum
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Background { get; set; }

        [Required]
        public virtual User Owner { get; set; }
        public virtual List<Project> Projects { get; set; } = new List<Project>();
    }
}
