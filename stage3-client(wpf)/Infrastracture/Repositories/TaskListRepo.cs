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
            rClient.PostRequest(entity);
        }

        public IEnumerable<TaskList> FindAll()
        {
            return rClient.GetRequest();
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
            rClient.DeleteRequest(entity);
        }

        public void Update(TaskList entity)
        {
            rClient.PutRequest(entity);
        }
    }
}
