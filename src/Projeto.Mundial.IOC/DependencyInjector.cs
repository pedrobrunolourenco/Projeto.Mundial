using Microsoft.Extensions.DependencyInjection;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Services;

namespace Projeto.Mundial.IOC
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Perfil
            services.AddScoped<IAppPerfil, AppPerfil>();


            //services.AddScoped<IServicePessoa, ServicePessoa>();
            //services.AddScoped<IAppPessoa, AppPessoa>();
            //// telefone
            //services.AddScoped<IRepositoryTelefone, RepositoryTelefone>();
            //services.AddScoped<DataContext>();
        }
    }
}
