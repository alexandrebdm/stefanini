using AutoMapper;
using Stefanini.Core.Domain;
using Stefanini.Core.Shared.ViewModels;

namespace Stefanini.Manager.Mappings
{
    public class NovoPedidoMappingProfile : Profile
    {
        public NovoPedidoMappingProfile()
        {
            CreateMap<PedidoViewModel, Pedido>()
                .ForMember(x => x.DataCadastro, t => t.MapFrom(src => DateTime.Now)).ReverseMap();

            CreateMap<ItemPedidoViewModel, ItemPedido>().ReverseMap();

            CreateMap<ResponseListaPedidoViewModel, Pedido>().ReverseMap()
                .ForMember(x => x.ValorTotal, opt => opt
                            .MapFrom(scr => scr.ItensPedido.Sum(x => x.Produto.Valor * x.Quantidade)));

            CreateMap<ItemPedido, ResponseItemPedidoViewModel>()
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.Produto.NomeProduto))
                .ForMember(dest => dest.ValorUnitario, opt => opt.MapFrom(src => src.Produto.Valor)).ReverseMap();
                
        }
    }
}
