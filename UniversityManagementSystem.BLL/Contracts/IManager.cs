using System.Collections.Generic;

namespace UniversityManagementSystem.BLL.Contracts
{
    public interface IManager<T> where T:class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);

        T GetById(long? id);
        ICollection<T> GetAll();
    }
}
