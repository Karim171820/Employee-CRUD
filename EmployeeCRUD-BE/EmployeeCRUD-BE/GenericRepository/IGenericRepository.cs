using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeCRUD_BE.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        public IQueryable<T> GetAllAsQueryable();

    }
}
