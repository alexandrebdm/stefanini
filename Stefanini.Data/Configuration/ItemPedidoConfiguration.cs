using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Core.Domain;

namespace Stefanini.Data.Configuration
{
    internal class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantidade).IsRequired().HasPrecision(10,2);
            builder.Property(x => x.IdProduto).IsRequired();
            builder.Property(x => x.IdPedido).IsRequired();
            builder.HasOne(x => x.Pedido).WithMany(p => p.ItensPedido).HasForeignKey(x => x.IdPedido);
            builder.HasOne(x => x.Produto).WithMany(p => p.ItensPedido).HasForeignKey(x => x.IdProduto);
        }
    }
}
