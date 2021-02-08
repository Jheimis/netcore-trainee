using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Trainee.Infra.Data.Context;

namespace Trainee.Web.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<TraineeContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TraineeDotNetCoret;Trusted_Connection=True;MultipleActiveResultSets=true"));

      
        }
    }
}
