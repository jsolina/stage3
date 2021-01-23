using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Infrastracture.Persistence;
using Domain.Contracts;
using Domain.Models;
//using Serilog;

namespace Infrastracture.Repositories
{
    public class TaskListRepo : ITaskList
    {
        private IDatabaseContext _dbcontext;

        public TaskListRepo(IDatabaseContext context) => _dbcontext = context;

        public void aw()
        {
            //Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("@log.txt").CreateLogger();
        }

        public void Create(TaskList entity)
        {   
           //entity.idTaskList = Guid.NewGuid();
            _dbcontext.TaskList.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<TaskList> FindAll()
        {
            return _dbcontext.TaskList.ToList();
        }

        public TaskList FindById(int id)
        {
            return _dbcontext.TaskList.Where(d => d.idTask.Equals(id)).FirstOrDefault();
        }

        public void Remove(TaskList entity)
        {
            _dbcontext.TaskList.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(TaskList entity)
        {
            _dbcontext.TaskList.Update(entity);
            _dbcontext.Save();
        }
    }
}
