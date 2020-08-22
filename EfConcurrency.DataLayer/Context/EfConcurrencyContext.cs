using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using EfConcurrency.DataLayer.Entities;
using EfConcurrency.DataLayer.Entities.BaseClasses;

namespace EfConcurrency.DataLayer.Context
{
    public class EfConcurrencyContext : DbContext, IUnitOfWork
    {
        private readonly object _lockObject = new object();

        public EfConcurrencyContext() : base("IGameConnectionString")
        {
            Database.SetInitializer<EfConcurrencyContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Database.CommandTimeout = 180;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // set default configs
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(100));
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));
            modelBuilder.Properties().Where(x => x.Name.Contains("Description")).Configure(x => x.HasMaxLength(2000));

            //it loads config dll.
            modelBuilder.Configurations.AddFromAssembly(typeof(Album).Assembly);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class
        {
            ChangeState(entity, EntityState.Added);
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            ChangeState(entity, EntityState.Modified);
        }

        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public void MarkAsDetached<TEntity>(TEntity entity) where TEntity : class
        {
            ChangeState(entity, EntityState.Detached);
        }

        public void MarkAsUnchanged<TEntity>(TEntity entity) where TEntity : class
        {
            ChangeState(entity, EntityState.Unchanged);
        }

        public void DetachAll()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    Entry(dbEntityEntry.Entity).State = EntityState.Detached;
                }
            }
        }

        public void ChangeState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {
            var baseEntity = entity as BaseEntity;
            if (baseEntity != null)
            {
                var id = baseEntity.Id;
                var local = Set<TEntity>().Local.FirstOrDefault(x =>
                {
                    var ben = (x as BaseEntity);
                    return ben != null && ben.Id == id;
                });
                if (local != null)
                {
                    Entry(local).State = EntityState.Detached;
                }
            }

            Entry(entity).State = state;
        }

        public void UpdateFields<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] fields) where TEntity : class
        {
            foreach (var property in fields)
            {
                Entry(entity).Property(property).IsModified = true;
            }
        }

        public void UpdateFields<TEntity>(TEntity entity, params string[] fields) where TEntity : class
        {
            foreach (var property in fields)
            {
                Entry(entity).Property(property).IsModified = true;
            }
        }

        public void ExcludeFieldsFromUpdate<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] excludedFields) where TEntity : class
        {
            var dbEntityEntry = Entry(entity);
            foreach (var property in excludedFields)
            {
                dbEntityEntry.Property(property).IsModified = false;
            }
        }

        public int SaveChanges(bool validateOnSaveEnabled = true)
        {
            try
            {
                var defaultValidation = Configuration.ValidateOnSaveEnabled;
                Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;

                var saveResult = base.SaveChanges();
                Configuration.ValidateOnSaveEnabled = defaultValidation;

                return saveResult;
            }
            finally
            {
                // make sure to detach all entities after each save change
                DetachAll();
            }
        }

        public int SaveChangesSafely(bool validateOnSaveEnabled = true)
        {
            lock (_lockObject)
            {
                return SaveChanges(validateOnSaveEnabled);
            }
        }

        public T ExecuteSafely<T>(Func<T> fn)
        {
            lock (_lockObject)
            {
                return fn();
            }
        }

        public int ExecuteSqlCommand(string sqlQuery, params object[] sqlParam)
        {
            lock (_lockObject)
            {
                return Database.ExecuteSqlCommand(sqlQuery, sqlParam);
            }
        }
    }
}
