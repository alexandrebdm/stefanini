using Microsoft.EntityFrameworkCore;
using Stefanini.Core.Domain;
using Stefanini.Data.Context;
using Stefanini.Manager.Interfaces;

namespace Stefanini.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly StefaniniContext _context;

        public PedidoRepository(StefaniniContext context)
        {
            _context = context;
        }

        public async Task<Pedido> InserirPedido(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<IList<Pedido>> GetAll()
        {
            return await _context.Pedidos.Include(p => p.ItensPedido).ThenInclude(p => p.Produto).ToListAsync();
        }

        public async Task<Pedido?> GetById(int id)
        {
            return await _context.Pedidos.Include(p => p.ItensPedido).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pedido> AtualizarPedido(Pedido pedido)
        {
            var pedidoDB = await _context.Pedidos
                                 .Include(p => p.ItensPedido)
                                 .ThenInclude(p => p.Produto)
                                 .SingleOrDefaultAsync(p => p.Id == pedido.Id);

            if (pedidoDB == null)
            {
                return null;
            }

            _context.Entry(pedidoDB).CurrentValues.SetValues(pedido);

            pedidoDB.ItensPedido.Clear();

            pedidoDB.ItensPedido = pedido.ItensPedido;

            await _context.SaveChangesAsync();
            return pedidoDB;
        }

        public async Task<bool> DeletarPedido(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
