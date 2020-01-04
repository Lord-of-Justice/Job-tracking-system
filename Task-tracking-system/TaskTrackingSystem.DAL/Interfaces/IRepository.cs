using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTrackingSystem.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class 
    {
        void Create(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Update(T item);
    }
}
