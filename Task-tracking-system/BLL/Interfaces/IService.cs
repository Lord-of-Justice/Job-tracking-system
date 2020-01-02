using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IService<T>
    {
        void Create(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Update(T item);
    }
}
