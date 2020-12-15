using System;
using System.Collections.Generic;
using Infrastracture.Persistence;
using Domain.Contracts;
using Domain.Models;

namespace Infrastracture.Repositories
{
    public class TaskListRepo : ITaskList
    {
        RestTaskList rClient = new RestTaskList();

        public void Create(TaskList entity)
        {
            rClient.postRequest(entity);
        }

        public IEnumerable<TaskList> FindAll()
        {
            return rClient.getRequest();
        }

        public IEnumerable<TaskList> FindByFK()
        {
            throw new NotImplementedException();
        }

        public TaskList FindById(int id)
        {
            throw new NotImplementedException();
            //return _dbcontext.TaskLists.Where(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(TaskList entity)
        {
            throw new NotImplementedException();
            //_dbcontext.TaskLists.Remove(entity);
            //_dbcontext.Save();
        }

        public void Update(TaskList entity)
        {
            rClient.putRequest(entity);
        }
    }
}
