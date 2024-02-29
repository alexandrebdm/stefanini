using Microsoft.AspNetCore.Mvc;
using Stefanini.Core.Shared.ViewModels;
using Stefanini.Manager.Interfaces;

namespace Stefanini.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoManager _manager;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(IPedidoManager manager, ILogger<PedidoController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        /// <summary>
        /// Insere um novo cliente
        /// </summary>
        /// <param name="client"></param>
        [HttpPost]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(PedidoViewModel pedido)
        {
            try
            {
                _logger.LogInformation("Objeto recebido {@pedido}", pedido);
            
                _logger.LogInformation("requisitado a inserção de um novo pedido");
                var pedidoDb = await _manager.InserirPedido(pedido);

                return Ok(pedidoDb);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ResponseListaPedidoViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            //throw new Exception("Erro teste");
            return Ok(await _manager.GetAll());
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="client"></param>
        [HttpPut]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(UpdatePedidoViewModel pedido)
        {
            try
            {
                _logger.LogInformation("Atualizando {@pedido}", pedido);

                _logger.LogInformation("requisitado a alteração do pedido");
                var clientDb = await _manager.AtualizarPedido(pedido);

                if (clientDb is null) return NotFound();

                return Ok(clientDb);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deleta um cliente pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Excluindo pedido Id: {@id}", id);
                var clienteExcluido = await _manager.DeletarPedido(id);

                return Ok(clienteExcluido);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
