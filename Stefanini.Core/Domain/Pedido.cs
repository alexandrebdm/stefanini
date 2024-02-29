namespace Stefanini.Core.Domain
{
    public class Pedido
    {
        public int Id { get; set; } 
        public string NomeCliente { get; set; } 
        public string EmailCliente { get; set; } 
        public DateTime DataCadastro { get; set; }
        public bool Pago { get; set; } 

        public IList<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
        
    }
}
