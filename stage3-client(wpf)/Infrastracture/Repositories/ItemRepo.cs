using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Infrastracture.Persistence;
using Domain.Contracts;
using Domain.Models;

namespace Infrastracture.Repositories
{
    public class ItemRepo : IItem
    {
        RestItem rClient = new RestItem();

        public void Create(Item entity)
        {
            rClient.postRequest(entity);
        }

        public IEnumerable<Item> FindAll()
        {
            return rClient.getRequest();
        }

        public IEnumerable<Item> FindByFK(int id)
        {
            return rClient.getRequest().OrderByDescending(i => i.Id).Where(d => d.IdTask.Equals(id)).ToList();
        }

        public Item FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Item entity)
        {
            rClient.putRequest(entity);
        }
    }
}
