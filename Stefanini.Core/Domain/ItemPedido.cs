namespace Stefanini.Core.Domain
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; } = new Pedido();
        public Produto Produto { get; set; } = new Produto();
    }
}
