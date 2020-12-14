using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<TaskList> TaskList { get; set; }
        public DbSet<ItemList> ItemList { get; set; }

        public void Save()
        {
            SaveChanges();
        }
    }
}
