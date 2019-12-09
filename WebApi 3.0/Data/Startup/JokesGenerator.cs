using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Jokes.WebApi.Models;

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
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var repository = new GenericRepository.GenericRepository<Joke>(new JokesDbContext(serviceProvider.GetRequiredService<DbContextOptions<JokesDbContext>>()));

            if (repository.Get().Any())
            {
                return;
            }

            repository.Insert(new Joke
            {
                JokeId = Guid.NewGuid(),
                Question = "If you’re an American in the kitchen, what are you when you’re in the bathroom?",
                Answer = "European!"
            });
            repository.Insert(new Joke
            {
                JokeId = Guid.NewGuid(),
                Question = "Why didn't the toilet paper cross the road?",
                Answer = "Because it got stuck in a crack"
            });
            repository.Insert(new Joke
            {
                JokeId = Guid.NewGuid(),
                Question = "Doctor, I keep seeing an insect buzzing around me.",
                Answer = "Don’t worry; that’s just a bug that’s going around."
            });
            repository.Insert(new Joke
            {
                JokeId = Guid.NewGuid(),
                Question = "Did you hear about the cheese factory that exploded in France?",
                Answer = "There was nothing left but de Brie."
            });
        }
    }
}
