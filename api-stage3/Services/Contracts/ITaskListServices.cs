using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Infrastracture.Contracts
{
    public interface ITaskListServices : IBaseServices<TaskList>
    {
        void samp();
    }
}
