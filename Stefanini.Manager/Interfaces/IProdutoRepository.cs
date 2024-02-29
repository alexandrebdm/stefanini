using Stefanini.Core.Domain;

namespace Stefanini.Manager.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> InserirProduto(Produto produto);
        Task<Produto?> GetById(int id);
        Task<Produto> AtualizarProduto(Produto produto);
        Task<bool> DeletarProduto(Produto produto);
    }
}
