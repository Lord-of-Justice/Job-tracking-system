using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Update(T item);
    }
}
