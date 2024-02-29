namespace Stefanini.Core.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }

        public IList<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
    }
}
