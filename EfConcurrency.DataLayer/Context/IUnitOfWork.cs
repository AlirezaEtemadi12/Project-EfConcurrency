using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace EfConcurrency.DataLayer.Context
{
    public interface IUnitOfWork
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsDetached<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsUnchanged<TEntity>(TEntity entity) where TEntity : class;
        void DetachAll();
        void ChangeState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
        void UpdateFields<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] fields) where TEntity : class;
        void UpdateFields<TEntity>(TEntity entity, params string[] fields) where TEntity : class;
        void ExcludeFieldFromUpdate<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties) where TEntity : class;
        T ExecuteSafely<T>(Func<T> fn);
        int SaveChanges(bool validateOnSaveEnabled = true);
        int SaveChangesSafely(bool validateOnSaveEnabled = true);
        int ExecuteSqlCommand(string sqlQuery, params object[] sqlParam);
        void Dispose();
    }
}
