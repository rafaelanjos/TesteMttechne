using FinanceiroApi.DTOs;
using FinanceiroCore.Application.CadastrarLancamento;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).ToList());

            var errors = _cadastrarLancamentoCommand.Execute(dto.MapperToDomain());
            if (errors.Any())
            {
                ModelState.AddModelError("", string.Join(", ", errors));
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).ToList());
            }

            return Ok();
        }
        
    }
}
