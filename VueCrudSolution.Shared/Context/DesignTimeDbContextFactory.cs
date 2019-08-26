using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VueCrudSolution.Shared.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyAppContext>
    {
        public MyAppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile("appsettings.Development.json", optional: true)
               .Build();

            var builder = new DbContextOptionsBuilder();
            builder.EnableSensitiveDataLogging(true);

            var connectionString = configuration["ConnectionStrings:MyAppConnection"];
            //builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(this.GetType().Assembly.FullName));
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("VueCrudSolution.Shared"));
            return new MyAppContext(builder.Options);
        }
    }
}
