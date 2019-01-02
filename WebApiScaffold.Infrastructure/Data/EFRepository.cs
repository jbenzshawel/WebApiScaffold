using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApiScaffold.Core.Interfaces;
using WebApiScaffold.Core.Entities;

namespace WebApiScaffold.Infrastructure.Data
{
    public class EFRepository : IRepository
    {
        private readonly DataContext _dbContext;

        public EFRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Get<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>();
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public int SaveChanges() 
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}