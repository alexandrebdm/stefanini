using AutoMapper;
using Stefanini.Core.Domain;
using Stefanini.Core.Shared.ViewModels;

namespace Stefanini.Manager.Mappings
{
    public class UpdatePedidoMappingProfile : Profile
    {
        public UpdatePedidoMappingProfile()
        {
            CreateMap<UpdatePedidoViewModel, Pedido>().ReverseMap();
        }
    }
}
