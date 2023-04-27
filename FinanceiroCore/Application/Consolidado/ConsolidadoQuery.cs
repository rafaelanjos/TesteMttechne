using FinanceiroCore.Infrasctructure.Persistance;
using System.Linq;

namespace FinanceiroCore.Application.Consolidado
{
    public class ConsolidadoQuery : IConsolidadoQuery
    {
        private readonly ISaldoRepository _saldoRepository;

        public ConsolidadoQuery(ISaldoRepository saldoRepository)
        {
            _saldoRepository = saldoRepository;
        }

        public ConsolidadoViewModel Execute()
        {
            var saldos = _saldoRepository.Obter30Saldos();
            var viewModel = new ConsolidadoViewModel
            {
                Saldos = saldos
            };

            viewModel.TotalPeriodo = viewModel?.Saldos?.Sum(x => x.SaldoDia) ?? 0;


            return viewModel;


        }
    }
}
