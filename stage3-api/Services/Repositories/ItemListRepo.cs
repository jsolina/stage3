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
    public class ItemListRepo : IItemList
    {
        private IDatabaseContext _dbcontext;

        public ItemListRepo(IDatabaseContext context) => _dbcontext = context;

        public void Create(ItemList entity)
        {
            _dbcontext.ItemList.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<ItemList> FindAll()
        {
            return _dbcontext.ItemList.ToList();
        }

        public ItemList FindById(int id)
        {
            return _dbcontext.ItemList.Where(d => d.idItem.Equals(id)).FirstOrDefault();
        }

        public void Remove(ItemList entity)
        {
            _dbcontext.ItemList.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(ItemList entity)
        {
            _dbcontext.ItemList.Update(entity);
            _dbcontext.Save();
        }
    }
}
