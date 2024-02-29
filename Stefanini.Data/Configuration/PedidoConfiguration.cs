using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Core.Domain;

namespace Stefanini.Data.Configuration
{
    internal class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCliente).IsRequired().HasMaxLength(60);
            builder.Property(x => x.EmailCliente).IsRequired().HasMaxLength(60);
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Pago).IsRequired();
            builder.HasMany(x => x.ItensPedido).WithOne(y => y.Pedido).HasForeignKey(x => x.IdPedido);
        }
    }
}
