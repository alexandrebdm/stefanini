using AutoMapper;
using Microsoft.Extensions.Logging;
using Stefanini.Core.Domain;
using Stefanini.Core.Shared.ViewModels;
using Stefanini.Manager.Interfaces;

namespace Stefanini.Manager.Implementation
{
    public class ProdutoManager : IProdutoManager
    {
        private readonly ILogger<ProdutoManager> _logger;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _repository;
        public ProdutoManager(IProdutoRepository repository, IMapper mapper, ILogger<ProdutoManager> logger)
        {
            _repository = repository;
            _mapper = mapper;  
            _logger = logger;
        }
        public async Task<ProdutoViewModel> InserirProduto(ProdutoViewModel produtoModel)
        {
            _logger.LogInformation("Chamada de negócio para inserir um produto.");

            var produto = _mapper.Map<Produto>(produtoModel);

            var produtoDB = await _repository.InserirProduto(produto);

            return _mapper.Map<ProdutoViewModel>(produtoDB);
        }

        public async Task<UpdateProdutoViewModel> AtualizarProduto(UpdateProdutoViewModel produtoModel)
        {
            _logger.LogInformation("Chamada de negócio para inserir um produto.");

            var produto = _mapper.Map<Produto>(produtoModel);

            var produtoDB = await _repository.AtualizarProduto(produto);

            return _mapper.Map<UpdateProdutoViewModel>(produtoDB);
        }

        public async Task<bool> DeletarProduto(int id)
        {
            var produto = await _repository.GetById(id);

            if (produto is null)
                return false;

            return await _repository.DeletarProduto(produto);
        }

    }
}
