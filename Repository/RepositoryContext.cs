using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class RepositoryContext(DbContextOptions<RepositoryContext> options) : DbContext(options)
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }

   

}
