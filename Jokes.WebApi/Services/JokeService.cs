using Jokes.WebApi.Data.GenericRepository;
using Jokes.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jokes.WebApi.Services
{
    /// <summary>
    /// Joke Service
    /// </summary>
    public class JokeService : IJokeService
    {
        private IGenericRepository<Joke> JokeRepository { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jokeRepository">Joke Repository</param>
        public JokeService(IGenericRepository<Joke> jokeRepository)
        {
            JokeRepository = jokeRepository;
        }

        /// <summary>
        /// GetAsync method to retrieve jokes
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        public async Task<IEnumerable<Joke>> GetAsync()
        {
            return await this.JokeRepository.GetAsync();
        }

        /// <summary>
        /// GetAsync method to retrieve jokes
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        public async Task<Joke> GetAsync(object id)
        {
            return await this.JokeRepository.GetAsync(id);
        }

        /// <summary>
        /// GetAsync method to retrieve jokes
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        public async Task<IEnumerable<Joke>> GetAsync(int skip, int take)
        {
            return await this.JokeRepository.GetAsync(skip, take);
        }

        /// <summary>
        /// SearchAsync method to retrieve a random joke
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        public async Task<Joke> GetByRandomIdAsync(int randomId)
        {
            return await this.JokeRepository.GetByRandomIdAsync(randomId);
        }

        /// <summary>
        /// SearchAsync method to retrieve filtered jokes
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        public async Task<IEnumerable<Joke>> SearchAsync(IEnumerable<string> propertyNames, string searchText)
        {
            return await this.JokeRepository.SearchAsync(propertyNames, searchText);
        }

        /// <summary>
        /// InsertAsync method, used to add a joke
        /// </summary>
        /// <param name="entity">The joke to be saved</param>
        public async Task InsertAsync(Joke entity)
        {
            await this.JokeRepository.InsertAsync(entity);
        }

        /// <summary>
        /// DeleteAsync method, used to remove a joke
        /// </summary>
        /// <param name="id">The id of the joke to be removed</param>
        public async Task DeleteAsync(object id)
        {
            await this.JokeRepository.DeleteAsync(id);
        }

        /// <summary>
        /// UpdateAsync method, used to modify a joke
        /// </summary>
        /// <param name="entityToUpdate">The joke to be saved</param>
        public async Task UpdateAsync(Joke entityToUpdate)
        {
            await this.JokeRepository.UpdateAsync(entityToUpdate);
        }
    }
}
