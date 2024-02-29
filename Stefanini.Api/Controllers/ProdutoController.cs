using Microsoft.AspNetCore.Mvc;
using Stefanini.Core.Shared.ViewModels;
using Stefanini.Manager.Interfaces;

namespace Stefanini.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoManager _manager;
        private readonly ILogger _logger;
        public ProdutoController(IProdutoManager maneger, ILogger<ProdutoController> logger)
        {
            _manager = maneger;
            _logger = logger;   
        }

        /// <summary>
        /// Insere um novo Produto
        /// </summary>
        /// <param name="produto"></param>
        [HttpPost]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ProdutoViewModel produto)
        {
            _logger.LogInformation("Objeto recebido {@produto}", produto);

            _logger.LogInformation("requisitado a inserção de um novo produto");
            var produtoDB = await _manager.InserirProduto(produto);

            return Ok(produtoDB);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="produto"></param>
        [HttpPut]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(UpdateProdutoViewModel produto)
        {
            _logger.LogInformation("Atualizando {@produto}", produto);

            _logger.LogInformation("requisitado a alteração do produto");
            var produtoDb = await _manager.AtualizarProduto(produto);

            if (produtoDb is null) return NotFound();

            return Ok(produtoDb);
        }

        /// <summary>
        /// Deleta um produto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um produto o mesmo será removido permanentemente da base</remarks>
        //[HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Excluindo produto Id: {@id}", id);
            var produtoExcluido = await _manager.DeletarProduto(id);

            return Ok(produtoExcluido);
        }

    }
}
