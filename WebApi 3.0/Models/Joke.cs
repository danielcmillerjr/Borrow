using System;
using System.Collections.Generic;

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
        /// Question of the joke
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// List of possible Answers for the joke
        /// </summary>
        public string Answer { get; set; }
    }
}
