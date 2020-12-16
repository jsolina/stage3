using System;
using System.Collections.Generic;
using Infrastracture.Persistence;
using Domain.Contracts;
using Domain.Models;

namespace Infrastracture.Repositories
{
    public class TaskListRepo : ITaskList
    {
        RsharpTaskList rClient = new RsharpTaskList();

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
