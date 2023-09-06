using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Models;
namespace project.Data
{
    public class projectContext : DbContext
    {
        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        {
        }
        public DbSet<project.Models.infos> Infos { get; set; } = default!;
        public DbSet<project.Models.skills>? Skills { get; set; } = default!;
        public DbSet<project.Models.experiences>? Experiences { get; set; }
        public DbSet<project.Models.educations>? Educations { get; set; }
        public DbSet<project.Models.certificates>? Certificates{ get; set; }
        public DbSet<project.Models.projects>?Projects { get; set; }
    }
}













