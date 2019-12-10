using Jokes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jokes.WebApi.Services
{
    /// <summary>
    /// Joke Service Interface 
    /// </summary>
    public interface IJokeService
    {
        /// <summary>
        /// Generic method to retrieve a list of entities
        /// </summary>
        /// <returns>list of entities</returns>
        Task<IEnumerable<Joke>> GetAsync();

        /// <summary>
        /// Generic get method to retrieve an entity
        /// </summary>
        /// <param name="id">id of the entity to be retrieved</param>
        Task<Joke> GetAsync(object id);

        /// <summary>
        /// Generic Get method to retrieve an entity
        /// </summary>
        /// <param name="skip">starting point of the list</param>
        /// <param name="take">amount to take from the list</param>
        /// <returns>an entity</returns>
        Task<IEnumerable<Joke>> GetAsync(int skip, int take);

        /// <summary>
        /// Generic Get method to retrieve an entity
        /// </summary>
        /// <param name="randomId">primary key of the entity</param>
        /// <returns>an entity</returns>
        Task<Joke> GetByRandomIdAsync(int randomId);

        /// <summary>
        /// Generic search method to retrieve filtered entities
        /// </summary>
        /// <param name="propertyNames">properties To Search</param>
        /// <param name="searchText">text to Search</param>
        /// <returns>enumerable of entity</returns>
        Task<IEnumerable<Joke>> SearchAsync(IEnumerable<string> propertyNames, string searchText);

        /// <summary>
        /// Generic method to insert an entity.
        /// </summary>
        /// <param name="entity"></param>
        Task InsertAsync(Joke entity);

        /// <summary>
        /// Generic delete method for the entities
        /// </summary>
        /// <param name="id">id of the entity to be deleted</param>
        Task DeleteAsync(object id);

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate">entity to update</param>
        Task UpdateAsync(Joke entityToUpdate);
    }
}
