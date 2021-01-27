using Domain.Contracts;
using Domain.Models;
using Infrastracture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Repositories
{
    public class ItemListRepo : IItemList
    {
        private IDatabaseContext _dbcontext;

        public ItemListRepo(IDatabaseContext context) => _dbcontext = context;

        public void Create(ItemListModel entity)
        {
            _dbcontext.ItemList.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<ItemListModel> FindAll()
        {
            return _dbcontext.ItemList.ToList();
        }

        public ItemListModel FindById(int id)
        {
            return _dbcontext.ItemList.Where(d => d.idItem.Equals(id)).FirstOrDefault();
        }

        public void Remove(ItemListModel entity)
        {
            _dbcontext.ItemList.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(ItemListModel entity)
        {
            _dbcontext.ItemList.Update(entity);
            _dbcontext.Save();
        }
    }
}
