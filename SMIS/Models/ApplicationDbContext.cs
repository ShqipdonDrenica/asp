using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMIS.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>{

        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options){}

        public DbSet<Department>Departments{ get; set; }
        public DbSet<Faculty>Faculties{ get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
