using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace TodoApp.ContextFactory
{

    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        //Implementing The Interface CreateDbContext method
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            // Set the culture for the current thread
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("TodoAppAPIDbConnectionString")
                    , b => b.MigrationsAssembly("TodoApp"));

            return new RepositoryContext(builder.Options);
        }
    }
}
