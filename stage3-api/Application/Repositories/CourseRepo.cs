using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Contracts;
using Domain.Models;
using Application.Persistence;
using System.Linq;

namespace Application.Repositories
{
    public class CourseRepo : ICourse
    {
        private IDatabaseContext _dbcontext;

        public CourseRepo(IDatabaseContext context) => _dbcontext = context;

        public void Create(Course entity)
        {
            entity.Id = Guid.NewGuid();
            _dbcontext.Courses.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<Course> FindAll()
        {
            return _dbcontext.Courses.ToList();
        }

        public Course FindById(Guid id)
        {
            return _dbcontext.Courses.Where(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(Course entity)
        {
            _dbcontext.Courses.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(Course entity)
        {
            _dbcontext.Courses.Update(entity);
            _dbcontext.Save();
        }
    }
}
