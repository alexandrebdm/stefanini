using Stefanini.Manager.Mappings;

namespace Stefanini.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoPedidoMappingProfile), typeof(UpdatePedidoMappingProfile));
        }
    }
}
