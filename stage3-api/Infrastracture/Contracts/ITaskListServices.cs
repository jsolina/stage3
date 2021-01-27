using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastracture.Contracts
{
    public interface ITaskListServices : IBaseServices<TaskListModel>
    {
        void samp();
    }

}
