namespace Stefanini.Core.Shared.ViewModels
{
    public class ResponseListaPedidoViewModel
    {
        public int Id {  get; set; }
        public string NomeCliente {  get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public decimal ValorTotal { get; set; }

        public IList<ResponseItemPedidoViewModel> ItensPedido { get; set; } = new List<ResponseItemPedidoViewModel>();
    }
}
