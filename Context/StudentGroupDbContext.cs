using Microsoft.EntityFrameworkCore;
using StudentGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroup.Context
{
    internal class StudentGroupDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        string connection = "Server=DESKTOP-609D4KS;Database=StudentGroup;Trusted_Connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);    
        }
    }
}
