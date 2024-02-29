using Stefanini.Core.Shared.ViewModels;

namespace Stefanini.Manager.Interfaces
{
    public interface IProdutoManager
    {
        Task<ProdutoViewModel> InserirProduto(ProdutoViewModel produto);
        Task<UpdateProdutoViewModel> AtualizarProduto(UpdateProdutoViewModel produtoModel);
        Task<bool> DeletarProduto(int id);
    }
}
