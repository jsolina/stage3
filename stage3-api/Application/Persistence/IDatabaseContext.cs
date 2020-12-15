using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<Course> Courses { get; set; }
        void Save();

    }
}
