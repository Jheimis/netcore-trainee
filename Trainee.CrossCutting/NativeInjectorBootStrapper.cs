using Microsoft.Extensions.DependencyInjection;
using System;
using Trainee.Application.Interfaces;
using Trainee.Application.Services;
using Trainee.Domain.Interfaces;
using Trainee.Infra.Data.Context;
using Trainee.Infra.Data.Repository;

namespace Trainee.CrossCutting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Application
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            // Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<TraineeContext>();

            
        }
    }
}
