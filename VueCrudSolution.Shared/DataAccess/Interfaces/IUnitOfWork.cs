using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VueCrudSolution.Data.Models;
using VueCrudSolution.Shared.DataAccess.Interfaces;

namespace VueCrudSolution.Shared.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> CommitAsync();
    }
}
