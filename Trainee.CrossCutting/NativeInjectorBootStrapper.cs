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
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<TraineeContext>();

            
        }
    }
}
