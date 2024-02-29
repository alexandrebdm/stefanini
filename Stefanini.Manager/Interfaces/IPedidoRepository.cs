using Stefanini.Core.Domain;

namespace Stefanini.Manager.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> InserirPedido(Pedido pedido);
        Task<IList<Pedido>> GetAll();
        Task<Pedido?> GetById(int id);
        Task<Pedido> AtualizarPedido(Pedido pedido);
        Task<bool> DeletarPedido(Pedido pedido);
    }
}
