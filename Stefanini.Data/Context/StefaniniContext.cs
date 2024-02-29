using Microsoft.EntityFrameworkCore;
using Stefanini.Core.Domain;
using Stefanini.Data.Configuration;

namespace Stefanini.Data.Context
{
    public class StefaniniContext : DbContext
    {
        public StefaniniContext(DbContextOptions options): base(options) 
        { 
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PodutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
