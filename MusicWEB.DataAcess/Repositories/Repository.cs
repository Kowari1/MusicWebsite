using Microsoft.EntityFrameworkCore;
using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.DataAcessData.Data;
using System.Linq.Expressions;

namespace MusicWEB.DataAcess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> values = dbSet;
            return values.Where(filter).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T>? values = dbSet;
            return values;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entitys)
        {
            dbSet.RemoveRange(entitys);
        }
    }
}
