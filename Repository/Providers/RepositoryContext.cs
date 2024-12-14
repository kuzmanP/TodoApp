using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository.Providers
{
    public class RepositoryContext(DbContextOptions<RepositoryContext> options) : DbContext(options)
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }



}
