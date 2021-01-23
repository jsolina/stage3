using Domain.Contracts;
using Domain.Models;
using Infrastracture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Repositories
{
    public class ItemRepo : IItem
    {
        ItemRest _dbcontext = new ItemRest();

        public void Create(ItemModel entity)
        {
            _dbcontext.PostRequest(entity);
        }

        public IEnumerable<ItemModel> FindAll()
        {
            return _dbcontext.GetRequest();
        }

        public IEnumerable<ItemModel> FindByFK(object id)
        {
            return _dbcontext.GetRequest().OrderByDescending(i => i.IdItem).Where(d => d.IdTask.Equals(id)).ToList();
        }

        public ItemModel FindById(int id)
        {
            return _dbcontext.GetByIdRequest(id);
        }

        public void Remove(int entity)
        {
            _dbcontext.DeleteRequest(entity);
        }

        public void Update(ItemModel entity)
        {
            _dbcontext.PutRequest(entity);
        }
    }
}
