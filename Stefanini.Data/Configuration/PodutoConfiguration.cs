using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Core.Domain;

namespace Stefanini.Data.Configuration
{
    public class PodutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeProduto).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Valor).IsRequired().HasPrecision(10,2);
            builder.HasMany(p => p.ItensPedido).WithOne(x => x.Produto).HasForeignKey(x => x.IdProduto);

            builder.HasData(new Produto() {Id = 1, NomeProduto = "produto 1", Valor = new decimal(10.5) });
            builder.HasData(new Produto() {Id = 2, NomeProduto = "produto 2", Valor = new decimal(7.5) });
            builder.HasData(new Produto() {Id = 3, NomeProduto = "produto 3", Valor = new decimal(11) });
            builder.HasData(new Produto() {Id = 4, NomeProduto = "produto 4", Valor = new decimal(15) });
            builder.HasData(new Produto() {Id = 5, NomeProduto = "produto 5", Valor = new decimal(2.5) });
        }
    }
}
