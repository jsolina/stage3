using Domain.Contracts;
using Domain.Models;
using Infrastracture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Repositories
{
    public class TaskListRepo : ITaskList
    {
        TaskListRest _dbcontext = new TaskListRest();

        public void Create(TaskListModel entity)
        {
            _dbcontext.PostRequest(entity);
        }

        public IEnumerable<TaskListModel> FindAll()
        {
            return _dbcontext.GetRequest();
        }

        public IEnumerable<TaskListModel> FindByFK()
        {
            throw new NotImplementedException();
        }

        public TaskListModel FindById(int id)
        {
            return _dbcontext.GetByIdRequest(id);
        }

        public void Remove(int entity)
        {
            _dbcontext.DeleteRequest(entity);
        }

        public void Update(TaskListModel entity)
        {
            _dbcontext.PutRequest(entity);
        }
    }
}
