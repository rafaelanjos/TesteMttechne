using FinanceiroCore.Domain;
using System.Collections.Generic;

namespace FinanceiroCore.Application.Consolidado
{
    public class ConsolidadoViewModel
    {
        public decimal TotalPeriodo { get; set; }
        public IEnumerable<Saldo> Saldos { get; set; }
    }
}
