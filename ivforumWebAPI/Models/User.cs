﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ivforumWebAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string RepositoryUrl { get; set; }

        public int IdentityId { get; set; }
        public virtual UserModel Identity{ get; set; }
        public virtual Token Token { get; set; } = null;
        public virtual List<Forum> Forums { get; set; } = new List<Forum>();
        public virtual List<Project> Projects { get; set; } = new List<Project>();
    }
}
