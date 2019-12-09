using System.Collections.Generic;

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
        IEnumerable<TEntity> Get();

        /// <summary>
        /// Generic get method to retrieve an entity
        /// </summary>
        /// <param name="id">id of the entity to be retrieved</param>
        TEntity Get(object id);

        /// <summary>
        /// Generic method to insert an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// Generic delete method for the entities
        /// </summary>
        /// <param name="id">id of the entity to be deleted</param>
        void Delete(object id);

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate">entity to update</param>
        void Update(TEntity entityToUpdate);
    }
}
