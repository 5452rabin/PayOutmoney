using Assignment.Data;
using Assignment.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assignment.GenericRepository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AssignmentDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; // Mark the entity as modified
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                _dbContext.SaveChanges();
            }
        }
        public IQueryable<T> GetDatas()
        {

            return _dbSet.AsNoTracking().AsQueryable();
        }
    }
}
