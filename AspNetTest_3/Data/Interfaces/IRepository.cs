using System.Collections.Generic;

namespace AspNetTest_3.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
