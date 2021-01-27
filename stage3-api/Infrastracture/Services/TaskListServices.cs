using Domain.Contracts;
using Domain.Models;
using Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Services
{
    public class TaskListServices : ITaskListServices
    {
        private ITaskList _repoServices;
        public TaskListServices(ITaskList repo) => _repoServices = repo;
        public void Create(TaskListModel entity)
        {
            _repoServices.Create(entity);
        }

        public IEnumerable<TaskListModel> FindAll()
        {
            return _repoServices.FindAll().OrderBy(c => c.taskName);
        }

        public TaskListModel FindById(int id)
        {
            return _repoServices.FindById(id);
        }

        public void Remove(TaskListModel entity)
        {
            _repoServices.Remove(entity);
        }

        public void samp()
        {

        }

        public void Update(TaskListModel entity)
        {
            _repoServices.Update(entity);
        }
    }
}
