using AutoMapper;
using Stefanini.Core.Domain;
using Stefanini.Core.Shared.ViewModels;

namespace Stefanini.Manager.Mappings
{
    public class UpdateProdutoMappingProfile : Profile
    {
        public UpdateProdutoMappingProfile()
        {
            CreateMap<UpdateProdutoViewModel, Produto>().ReverseMap();
        }
    }
}
