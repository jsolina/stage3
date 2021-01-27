using Domain.Contracts;
using Domain.Models;
using Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Services
{
    public class ItemListServices : IItemListServices
    {
        private IItemList _repoServices;
        public ItemListServices(IItemList repo) => _repoServices = repo;
        public void Create(ItemListModel entity)
        {
            _repoServices.Create(entity);
        }

        public IEnumerable<ItemListModel> FindAll()
        {
            return _repoServices.FindAll().OrderBy(c => c.itemName);
        }

        ItemListModel IBaseServices<ItemListModel>.FindById(int id)
        {
            return _repoServices.FindById(id);
        }

        public void Remove(ItemListModel entity)
        {
            _repoServices.Remove(entity);
        }

        public void samp()
        {

        }

        public void Update(ItemListModel entity)
        {
            _repoServices.Update(entity);
        }
    }
}
