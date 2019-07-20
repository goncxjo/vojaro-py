using System.Collections.Generic;
 
namespace vojaro.core
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
