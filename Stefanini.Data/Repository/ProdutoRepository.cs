using Microsoft.EntityFrameworkCore;
using Stefanini.Core.Domain;
using Stefanini.Data.Context;
using Stefanini.Manager.Interfaces;

namespace Stefanini.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StefaniniContext _context;

        public ProdutoRepository(StefaniniContext context)
        {
            _context = context;
        }
        public async Task<Produto> InserirProduto(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto?> GetById(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            var ProsutoDB = await _context.Produtos
                                 .SingleOrDefaultAsync(p => p.Id == produto.Id);

            if (ProsutoDB == null)
            {
                return null;
            }

            _context.Entry(ProsutoDB).CurrentValues.SetValues(produto);

            await _context.SaveChangesAsync();
            return ProsutoDB;
        }

        public async Task<bool> DeletarProduto(Produto produto)
        {
            try
            {
                _context.Produtos.Remove(produto);
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
