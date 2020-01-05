using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingSystem.BLL.Interfaces
{
    public interface IService<T>
    {
        void Create(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Update(T item);
    }
}
