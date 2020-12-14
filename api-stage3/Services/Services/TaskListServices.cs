using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Contracts;
using Infrastracture.Contracts;

namespace Services.Application
{
    public class TaskListServices : ITaskListServices
    {
        private ITaskList _repoServices;
        public TaskListServices(ITaskList repo) => _repoServices = repo;
        public void Create(TaskList entity)
        {
            _repoServices.Create(entity);
        }

        public IEnumerable<TaskList> FindAll()
        {
            return _repoServices.FindAll().OrderBy(c => c.taskName);
        }

        public TaskList FindById(int id)
        {
            return _repoServices.FindById(id);
        }

        public void Remove(TaskList entity)
        {
            _repoServices.Remove(entity);
        }

        public void samp()
        {

        }

        public void Update(TaskList entity)
        {
            _repoServices.Update(entity);
        }
    }
}
