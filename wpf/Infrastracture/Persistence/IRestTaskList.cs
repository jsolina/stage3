using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastracture.Persistence
{

    public interface IRestTaskList
    {
        TaskList TaskLists { get; set; }
        public IEnumerable<TaskList>getRequest();
        public string postRequest(TaskList TaskLists);

        public string putRequest(TaskList TaskLists);

        public string serializeObject(TaskList TaskLists);
        public string makeRequest();

        
    }
}
