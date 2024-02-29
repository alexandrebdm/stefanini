using AutoMapper;
using Stefanini.Core.Domain;
using Stefanini.Core.Shared.ViewModels;

namespace Stefanini.Manager.Mappings
{
    public class NovoProdutoMappingProfile : Profile
    {
        public NovoProdutoMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}
