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
            rClient.PostRequest(entity);
        }

        public IEnumerable<Item> FindAll()
        {
            return rClient.GetRequest();
        }

        public IEnumerable<Item> FindByFK(int id)
        {
            return rClient.GetRequest().OrderByDescending(i => i.IdItem).Where(d => d.IdTask.Equals(id)).ToList();
        }

        public Item FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item entity)
        {
            rClient.DeleteRequest(entity);
        }

        public void Update(Item entity)
        {
            rClient.PutRequest(entity);
        }
    }
}
