using Domain.Contracts;
using Domain.Models;
using Infrastracture.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Services.Application
{
    public class ItemListServices : IItemListServices
    {
        private IItemList _repoServices;
        public ItemListServices(IItemList repo) => _repoServices = repo;
        public void Create(ItemList entity)
        {
            _repoServices.Create(entity);
        }

        public IEnumerable<ItemList> FindAll()
        {
            return _repoServices.FindAll().OrderBy(c => c.itemName);
        }

        ItemList IBaseServices<ItemList>.FindById(int id)
        {
            return _repoServices.FindById(id);
        }

        public void Remove(ItemList entity)
        {
            _repoServices.Remove(entity);
        }

        public void samp()
        {

        }

        public void Update(ItemList entity)
        {
            _repoServices.Update(entity);
        }


    }
}

