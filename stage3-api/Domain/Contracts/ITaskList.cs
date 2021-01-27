using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Contracts
{
    public interface ITaskList : IBaseRepo<TaskListModel>
    {
        void aw();
    }
}
