using Microsoft.EntityFrameworkCore;
using MusicWebSite.DataAcess.Repositories.IRepository;
using MusicWebSite.DataAcessData.Data;
using System.Linq.Expressions;

namespace MusicWebSite.DataAcess.Repositories
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

        public IEnumerable<T> GetAll()
        {
            IQueryable<T>? values = dbSet;
            return values.ToList();
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
