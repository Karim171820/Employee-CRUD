using EmployeeCRUD_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD_BE.GenericRepository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EmployeeContext _context = null;
        private DbSet<T> table = null;


        public IQueryable<T> GetAllAsQueryable() => table.AsQueryable();

        public GenericRepository()
        {
            this._context = new EmployeeContext();

            table = _context.Set<T>();
        }

        public GenericRepository(EmployeeContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateAndSaveChanges(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            table.Update(entity);
            _context.SaveChanges();
        }
    }
}
