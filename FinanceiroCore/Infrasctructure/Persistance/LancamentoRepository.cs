using FinanceiroCore.Domain;

namespace FinanceiroCore.Infrasctructure.Persistance
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly FinanceiroContext _context;

        public LancamentoRepository(FinanceiroContext context)
        {
            _context = context;
        }

        public Lancamento Cadastrar(Lancamento lancamento)
        {
            _context.Add(lancamento);
            _context.SaveChanges();
            return lancamento;
        }
    }
}
