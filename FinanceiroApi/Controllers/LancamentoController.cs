using FinanceiroApi.DTOs;
using FinanceiroCore.Application.CadastrarLancamento;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        public ICadastrarLancamentoCommand _cadastrarLancamentoCommand { get; }

        public LancamentoController(ICadastrarLancamentoCommand cadastrarLancamentoCommand)
        {
            _cadastrarLancamentoCommand = cadastrarLancamentoCommand;
        }

        /// <summary>
        /// Cadastra lancamento e atualiza saldo do dia atual
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(LancamentoDto dto)
        {
            _cadastrarLancamentoCommand.Execute(dto.MapperToDomain());
            return Ok();
        }
        
    }
}
