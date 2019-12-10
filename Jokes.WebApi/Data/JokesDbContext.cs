using Microsoft.EntityFrameworkCore;
using Jokes.WebApi.Models;

namespace Jokes.WebApi.Data
{
    /// <summary>
    /// Jokes DbContext
    /// </summary>
    public class JokesDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextOptions">Options</param>
        public JokesDbContext(DbContextOptions<JokesDbContext> dbContextOptions) :
            base(dbContextOptions)
        { }

        /// <summary>
        /// DbSet of jokes
        /// </summary>
        public DbSet<Joke> Jokes { get; set; }
    }
}
