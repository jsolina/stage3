using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Course> Courses { get; set; }

        public void Save()
        {
            SaveChanges();
        }
    }
}
