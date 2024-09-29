using Microsoft.Extensions.DependencyInjection;
using Projento.Mundial.Domain.Interfaces.Repository;
using Projento.Mundial.Domain.Interfaces.Service;
using Projento.Mundial.Domain.Services;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Services;
using Projeto.Mundial.Data;
using Projeto.Mundial.Data.Repositories;

namespace Projeto.Mundial.IOC
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Perfil
            services.AddScoped<IAppPerfil, AppPerfil>();
            services.AddScoped<IServicePerfil, ServicePerfil>();
            services.AddScoped<IRepositoryPerfil, RepositoryPerfil>();

            // Usuario
            services.AddScoped<IAppUsuario, AppUsuario>();
            services.AddScoped<IServiceUsuario, ServiceUsuario>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();

            // outros
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataContext>();
        }
    }
}
