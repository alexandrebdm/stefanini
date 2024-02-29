using Stefanini.Data.Repository;
using Stefanini.Manager.Implementation;
using Stefanini.Manager.Interfaces;

namespace Stefanini.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IPedidoManager, PedidoManager>();
            services.AddScoped<IProdutoManager, ProdutoManager>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
