using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jokes.WebApi.Data;
using Jokes.WebApi.Data.GenericRepository;
using Jokes.WebApi.Models;

namespace Jokes.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;

        private IGenericRepository<Joke> JokeRepository { get; }

        public JokeController(ILogger<JokeController> logger, JokesDbContext jokeRepository)
        {
            _logger = logger;
            JokeRepository = new GenericRepository<Joke>(jokeRepository);
        }

        /// <summary>
        /// Get method to retrieve jokes
        /// GET: api/Joke
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        [HttpGet]
        public IEnumerable<Joke> Get(int? skip = null, int? take = null)
        {
            try
            {
                if (skip.HasValue && take.HasValue)
                {
                    return this.JokeRepository.Get().Skip(skip.Value).Take(take.Value);
                }

                return this.JokeRepository.Get();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Get an individual Joke by passing in the id
        /// GET: api/Joke/5
        /// </summary>
        /// <param name="id">Guid id</param>
        /// <returns>a joke</returns>
        [HttpGet("{id:guid}", Name = "Get")]
        public Joke Get(Guid id)
        {
            return this.JokeRepository.Get(id);
        }

        /// <summary>
        /// Post method, used to add a joke
        /// POST: api/Joke
        /// </summary>
        /// <param name="joke">The joke to be saved</param>
        [HttpPost]
        public void Post([FromBody] Joke joke)
        {
            this.JokeRepository.Insert(joke);
        }

        /// <summary>
        /// Post method, used to add a joke
        /// PUT: api/Joke/5
        /// </summary>
        /// <param name="id">The id of the joke to be removed</param>
        /// <param name="joke">The joke to be saved</param>
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody]Joke joke)
        {
            ///there are several approaches here
            ///one would be to eliminate the id and use the one on the joke
            ///another would be to query the database for the expected joke confirm there are changes 
            ///I've chose to look for the joke and if found go ahead and process the update
            ///otherwise we are going to throw an exception.
            var oldJoke = this.JokeRepository.Get(id);
            if (oldJoke != null)
            {
                this.JokeRepository.Update(joke);
                return;
            }

            throw new KeyNotFoundException($"Unable to locate the joke with the provided information {id}");
        }

        /// <summary>
        /// delete method, used to remove a joke
        /// DELETE: api/ApiWithActions/5
        /// </summary>
        /// <param name="id">The id of the joke to be removed</param>
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            this.JokeRepository.Delete(id);
        }
    }
}
