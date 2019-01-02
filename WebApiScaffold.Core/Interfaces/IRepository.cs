using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiScaffold.Core.Entities;

namespace WebApiScaffold.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}