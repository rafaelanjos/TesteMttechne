using FinanceiroCore.Application.Consolidado;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsolidadoController : ControllerBase
    {
        private readonly IConsolidadoQuery _consolidadoQuery;

        public ConsolidadoController(IConsolidadoQuery consolidadoQuery)
        {
            _consolidadoQuery = consolidadoQuery;
        }

        /// <summary>
        /// Lista o saldo dos ultimos 30 e apresenta o total do periodo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() => Ok(_consolidadoQuery.Execute());
        
    }
}
