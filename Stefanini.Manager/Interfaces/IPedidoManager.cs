using Stefanini.Core.Shared.ViewModels;

namespace Stefanini.Manager.Interfaces
{
    public interface IPedidoManager
    {
        Task<PedidoViewModel> InserirPedido(PedidoViewModel pedido);
        Task<IEnumerable<ResponseListaPedidoViewModel>> GetAll();
        Task<UpdatePedidoViewModel> AtualizarPedido(UpdatePedidoViewModel pedidoModel);
        Task<bool> DeletarPedido(int id);
    }
}
