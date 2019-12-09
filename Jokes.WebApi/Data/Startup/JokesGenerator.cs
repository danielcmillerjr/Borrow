using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Jokes.WebApi.Models;
using Jokes.WebApi.Data.GenericRepository;
using System.Threading.Tasks;

namespace Jokes.WebApi.Data.Startup
{
    /// <summary>
    /// Jokes Generator to provide an initial list of jokes.
    /// </summary>
    public class JokesGenerator
    {
        /// <summary>
        /// method to build up the database of jokes
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var repository = new GenericRepository<Joke>(new JokesDbContext(serviceProvider.GetRequiredService<DbContextOptions<JokesDbContext>>()));
            var list = await repository.GetAsync();
            if (list.Any())
            {
                return;
            }

            await repository.InsertAsync(new Joke
            {
                JokeId = Guid.NewGuid(),
                RandomId = 1,
                Question = "If you’re an American in the kitchen, what are you when you’re in the bathroom?",
                Answer = "European!"
            });
            await repository.InsertAsync(new Joke
            {
                JokeId = Guid.NewGuid(),
                RandomId = 2,
                Question = "Why didn't the toilet paper cross the road?",
                Answer = "Because it got stuck in a crack"
            });
            await repository.InsertAsync(new Joke
            {
                JokeId = Guid.NewGuid(),
                RandomId = 3,
                Question = "Doctor, I keep seeing an insect buzzing around me.",
                Answer = "Don’t worry; that’s just a bug that’s going around."
            });
            await repository.InsertAsync(new Joke
            {
                JokeId = Guid.NewGuid(),
                RandomId = 4,
                Question = "Did you hear about the cheese factory that exploded in France?",
                Answer = "There was nothing left but de Brie."
            });
        }
    }
}
