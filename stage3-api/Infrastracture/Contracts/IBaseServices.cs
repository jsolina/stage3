using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastracture.Contracts
{
    public interface IBaseServices<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
