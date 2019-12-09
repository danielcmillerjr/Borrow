using Microsoft.EntityFrameworkCore;
using Jokes.WebApi.Models;

namespace Jokes.WebApi.Data
{
    public class JokesDbContext : DbContext
    {
        public JokesDbContext(DbContextOptions<JokesDbContext> dbContextOptions) :
            base(dbContextOptions)
        { }

        public DbSet<Joke> Jokes { get; set; }
    }
}
