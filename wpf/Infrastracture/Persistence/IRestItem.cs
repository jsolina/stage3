using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastracture.Persistence
{

    public interface IRestItem
    {
        Item Items { get; set; }
        public IEnumerable<Item> getRequest();
        public string postRequest(Item TaskLists);

        public string putRequest(Item TaskLists);

        public string serializeObject(Item TaskLists);
        public string makeRequest();
    }
}
