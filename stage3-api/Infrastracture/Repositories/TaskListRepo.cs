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
        private IDatabaseContext _dbcontext;

        public TaskListRepo(IDatabaseContext context) => _dbcontext = context;

        public void aw()
        {
            throw new NotImplementedException();
        }

        public void Create(TaskListModel entity)
        {
            //entity.idTaskList = Guid.NewGuid();
            _dbcontext.TaskList.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<TaskListModel> FindAll()
        {
            return _dbcontext.TaskList.ToList().OrderBy(c => c.taskName);
        }

        public TaskListModel FindById(int id)
        {
            return _dbcontext.TaskList.Where(d => d.idTask.Equals(id)).FirstOrDefault();
        }

        public void Remove(TaskListModel entity)
        {
            _dbcontext.TaskList.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(TaskListModel entity)
        {
            _dbcontext.TaskList.Update(entity);
            _dbcontext.Save();
        }
    }
}
    