using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<TaskList> TaskList { get; set; }
        DbSet<ItemList> ItemList { get; set; }
        void Save();

    }
}
