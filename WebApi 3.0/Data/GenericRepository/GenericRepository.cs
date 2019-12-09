using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Jokes.WebApi.Data.GenericRepository
{
    /// <summary>
    /// Generice Repository is a class for Entity Operations
    /// </summary>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal JokesDbContext Context;
        internal DbSet<TEntity> DbSet;

        /// <summary>
        /// GenericRepository Constructor
        /// </summary>
        /// <param name="context">Database Context</param>
        public GenericRepository(JokesDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Generic Get method for entities
        /// </summary>
        /// <returns>an enumerable of entities</returns>
        public virtual IEnumerable<TEntity> Get()
        {
            return this.DbSet.ToList();
        }

        /// <summary>
        /// Generic Get method to retrieve an entity
        /// </summary>
        /// <param name="id">primary key of the entity</param>
        /// <returns>an entity</returns>
        public virtual TEntity Get(object id)
        {
            return this.DbSet.Find(id);
        }

        /// <summary>
        /// Generic insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            this.DbSet.Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Generic delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Generic delete method for the Entitiy
        /// </summary>
        /// <param name="entityToRemove"></param>
        private void Delete(TEntity entityToRemove)
        {
            if (this.Context.Entry(entityToRemove).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToRemove);
            }
            this.DbSet.Remove(entityToRemove);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            this.Context.SaveChanges();
        }
    }
}
