using Jokes.WebApi.Data.GenericRepository;
using Jokes.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jokes.WebApi.Services
{
    public class JokeService : IJokeService
    {
        private IGenericRepository<Joke> JokeRepository { get; }

        public JokeService(IGenericRepository<Joke> jokeRepository)
        {
            JokeRepository = jokeRepository;
        }

        public async Task<IEnumerable<Joke>> GetAsync()
        {
            return await this.JokeRepository.GetAsync();
        }

        public async Task<Joke> GetAsync(object id)
        {
            return await this.JokeRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Joke>> GetAsync(int skip, int take)
        {
            return await this.JokeRepository.GetAsync(skip, take);
        }

        public async Task<Joke> SearchAsync(int randomId)
        {
            return await this.JokeRepository.SearchAsync(randomId);
        }

        public async Task<IEnumerable<Joke>> SearchAsync(IEnumerable<string> propertyNames, string searchText)
        {
            return await this.JokeRepository.SearchAsync(propertyNames, searchText);
        }

        public async Task InsertAsync(Joke entity)
        {
            await this.JokeRepository.InsertAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            await this.JokeRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Joke entityToUpdate)
        {
            await this.JokeRepository.UpdateAsync(entityToUpdate);
        }
    }
}
