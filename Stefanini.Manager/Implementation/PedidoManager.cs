using AutoMapper;
using Microsoft.Extensions.Logging;
using Stefanini.Core.Domain;
using Stefanini.Core.Shared.ViewModels;
using Stefanini.Manager.Interfaces;

namespace Stefanini.Manager.Implementation
{
    public class PedidoManager : IPedidoManager
    {
        private readonly ILogger<PedidoManager> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        public PedidoManager(IPedidoRepository repository, IProdutoRepository produtoRepository, IMapper mapper, ILogger<PedidoManager> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public async Task<PedidoViewModel> InserirPedido(PedidoViewModel pedidoModel)
        {
            _logger.LogInformation("Chamada de negócio para inserir um pedido.");

            var pedido = _mapper.Map<Pedido>(pedidoModel);

            foreach (var it in pedido.ItensPedido)
            {
                var produto = await _produtoRepository.GetById(it.IdProduto);

                if (produto is null)
                    throw new Exception("Produto não encontrado");
                
                it.Produto = produto;
            }

            var pedidoDB = await _repository.InserirPedido(pedido);

            return _mapper.Map<PedidoViewModel>(pedidoDB);
        }

        public async Task<IEnumerable<ResponseListaPedidoViewModel>> GetAll()
        {
            var lista = await _repository.GetAll();
            var retorno = _mapper.Map<IList<ResponseListaPedidoViewModel>>(lista);

            return retorno;
        }

        public async Task<UpdatePedidoViewModel> AtualizarPedido(UpdatePedidoViewModel pedidoModel)
        {
            var pedido = _mapper.Map<Pedido>(pedidoModel);

            foreach (var it in pedido.ItensPedido)
            {
                it.Produto = await _produtoRepository.GetById(it.IdProduto);
            }

            var pedidoDb = await _repository.AtualizarPedido(pedido);

            return _mapper.Map<UpdatePedidoViewModel>(pedidoDb);
        }

        public async Task<bool> DeletarPedido(int id)
        {
            var pedido = await _repository.GetById(id);

            if (pedido is null)
                return false;

            return await _repository.DeletarPedido(pedido);
        }
    }
}
