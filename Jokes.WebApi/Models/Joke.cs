using Jokes.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jokes.WebApi.Models
{
    /// <summary>
    /// Joke Class 
    /// </summary>
    public class Joke
    {
        /// <summary>
        /// The id of the joke.
        /// </summary>
        public Guid JokeId { get; set; }

        /// <summary>
        /// this id is used to provide both a way for random selection and clustering
        /// </summary>
        public long RandomId { get; set; }

        /// <summary>
        /// Question of the joke
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Answer to the joke
        /// </summary>
        public string Answer { get; set; }
    }
}
