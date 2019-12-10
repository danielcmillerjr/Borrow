using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jokes.WebApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Jokes.WebApi.Services;
using Jokes.WebApi.Validators;

namespace Jokes.WebApi.Controllers
{
    /// <summary>
    /// Joke Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;

        private IJokeService JokeService { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="jokeService">Joke Service</param>
        public JokeController(ILogger<JokeController> logger, IJokeService jokeService)
        {
            _logger = logger;
            JokeService = jokeService;
        }

        /// <summary>
        /// Get method to retrieve jokes
        /// GET: api/v1/Joke
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Joke>> GetAsync(int? skip = null, int? take = null)
        {
            try
            {
                if (skip.HasValue && take.HasValue)
                {
                    return await this.JokeService.GetAsync(skip.Value, take.Value);
                }

                return await this.JokeService.GetAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get method to retrieve a random joke
        /// GetRandomAsync: api/v1/Joke/GetRandomAsync
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        [HttpGet("GetRandomAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Joke> GetRandomAsync()
        {
            try
            {
                Random random = new Random();
                var list = await this.JokeService.GetAsync();
                return list.FirstOrDefault(x => x.RandomId == random.Next(1, list.Count()));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// find method to retrieve filtered jokes
        /// FindAsync: api/v1/Joke/valueToSearch
        /// </summary>
        /// <returns>an enumerable of jokes</returns>
        [HttpGet("{valueToSearch}", Name = "FindAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Joke>> Search(string valueToSearch)
        {
            try
            {
                var properties = new List<string> { "Question", "Answer" };
                return await this.JokeService.SearchAsync(properties, valueToSearch);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get an individual Joke by passing in the id
        /// GetAsync: api/v1/Joke/5
        /// </summary>
        /// <param name="id">Guid id</param>
        /// <returns>a joke</returns>
        [HttpGet("{id:guid}", Name = "GetAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Joke> GetAsync(Guid id)
        {
            try
            {
                return await this.JokeService.GetAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Post method, used to add a joke
        /// PostAsync: api/v1/Joke
        /// </summary>
        /// <param name="joke">The joke to be saved</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task PostAsync([FromBody] Joke joke)
        {
            try
            {
                Validate(joke);
                await this.JokeService.InsertAsync(joke);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Post method, used to add a joke
        /// PutAsync: api/v1/Joke/5
        /// </summary>
        /// <param name="id">The id of the joke to be removed</param>
        /// <param name="joke">The joke to be saved</param>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task PutAsync(Guid id, [FromBody]Joke joke)
        {
            try
            {
                //there are several approaches here
                //one would be to eliminate the id and use the one on the joke
                //another would be to query the database for the expected joke confirm there are changes 
                //I've chosen to simply update the joke for brevity process the update
                Validate(joke);
                await this.JokeService.UpdateAsync(joke);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// delete method, used to remove a joke
        /// DeleteAsync: api/v1/joke/5
        /// </summary>
        /// <param name="id">The id of the joke to be removed</param>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await this.JokeService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        private void Validate(Joke joke)
        {
            var results = new JokeValidator().Validate(joke);

            if (!results.IsValid)
            {
                throw new Exception($"The following errors have occurred: {string.Join(", ", results.Errors)}");
            }
        }
    }
}
