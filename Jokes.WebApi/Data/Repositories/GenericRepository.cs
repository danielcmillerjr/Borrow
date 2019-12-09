using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await this.DbSet.ToListAsync();
        }

        /// <summary>
        /// Generic Get method to retrieve an entity
        /// </summary>
        /// <param name="id">primary key of the entity</param>
        /// <returns>an entity</returns>
        public virtual async Task<TEntity> GetAsync(object id)
        {
            return await this.DbSet.FindAsync(id);
        }


        /// <summary>
        /// Generic Get method to retrieve an entity
        /// </summary>
        /// <param name="id">primary key of the entity</param>
        /// <returns>an entity</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync(int skip, int take)
        {
            return await this.DbSet.Skip(skip).Take(take).ToListAsync();
        }

        /// <summary>
        /// Generic search method to retrieve filtered entities
        /// </summary>
        /// <param name="propertyName">property To Search</param>
        /// <param name="searchText">text to Search</param>
        /// <returns>enumerable of entity</returns>
        public virtual async Task<IEnumerable<TEntity>> SearchAsync(IEnumerable<string> propertyNames, string searchText)
        {
            List<TEntity> returnList = new List<TEntity>();

            var dataSet = await this.DbSet.ToListAsync();
            if (!dataSet.Any())
            {
                return this.DbSet;
            }

            var type = typeof(TEntity);

            foreach (var propertyName in propertyNames)
            {
                var info = type.GetProperty(propertyName);
                var filtered = dataSet.Where(joke =>
                {
                    object jk = info.GetValue(joke);

                    return (jk != null) ? jk.ToString().Contains(searchText, System.StringComparison.InvariantCultureIgnoreCase) : false;
                });
                if (filtered.Any())
                {
                    returnList.AddRange(filtered);
                }
            }

            return returnList;
        }

        /// <summary>
        /// Generic insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task InsertAsync(TEntity entity)
        {
            this.DbSet.Add(entity);
            await this.Context.SaveChangesAsync();
        }

        /// <summary>
        /// Generic delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await this.DbSet.FindAsync(id);
            await Delete(entityToDelete);
        }

        /// <summary>
        /// Generic delete method for the Entitiy
        /// </summary>
        /// <param name="entityToRemove"></param>
        private async Task Delete(TEntity entityToRemove)
        {
            if (this.Context.Entry(entityToRemove).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToRemove);
            }
            this.DbSet.Remove(entityToRemove);
            await this.Context.SaveChangesAsync();
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            this.Context.Update(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();
        }

        /// <summary>
        /// Search for a randomid
        /// </summary>
        /// <param name="randomId"></param>
        /// <returns></returns>
        public async Task<TEntity> SearchAsync(int randomId)
        {
            var properties = new List<string> { "RandomId" };
            var entityList = await this.SearchAsync(properties, randomId.ToString());
            return entityList.FirstOrDefault();
        }
    }
}
