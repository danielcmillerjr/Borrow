using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jokes.WebApi.Data.GenericRepository
{
    /// <summary>
    /// Generic Repository interface
    /// </summary>
    /// <typeparam name="TEntity">The entity we are building the repository</typeparam>
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Generic method to retrieve a list of entities
        /// </summary>
        /// <returns>list of entities</returns>
        Task<IEnumerable<TEntity>> GetAsync();

        /// <summary>
        /// Generic get method to retrieve an entity
        /// </summary>
        /// <param name="id">id of the entity to be retrieved</param>
        Task<TEntity> GetAsync(object id);

        /// <summary>
        /// Generic Get method to retrieve an entity
        /// </summary>
        /// <param name="id">primary key of the entity</param>
        /// <returns>an entity</returns>
        Task<IEnumerable<TEntity>> GetAsync(int skip, int take);

        /// <summary>
        /// Generic Get method to retrieve an entity
        /// </summary>
        /// <param name="id">primary key of the entity</param>
        /// <returns>an entity</returns>
        Task<TEntity> SearchAsync(int randomId);

        /// <summary>
        /// Generic search method to retrieve filtered entities
        /// </summary>
        /// <param name="propertyName">property To Search</param>
        /// <param name="searchText">text to Search</param>
        /// <returns>enumerable of entity</returns>
        Task<IEnumerable<TEntity>> SearchAsync(IEnumerable<string> propertyNames, string searchText);

        /// <summary>
        /// Generic method to insert an entity.
        /// </summary>
        /// <param name="entity"></param>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Generic delete method for the entities
        /// </summary>
        /// <param name="id">id of the entity to be deleted</param>
        Task DeleteAsync(object id);

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate">entity to update</param>
        Task UpdateAsync(TEntity entityToUpdate);
    }
}
