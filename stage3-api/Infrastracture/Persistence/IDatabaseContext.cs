using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<TaskListModel> TaskList { get; set; }
        DbSet<ItemListModel> ItemList { get; set; }
        void Save();

    }
}
