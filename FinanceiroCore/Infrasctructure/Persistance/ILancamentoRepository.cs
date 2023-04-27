using FinanceiroCore.Domain;

namespace FinanceiroCore.Infrasctructure.Persistance
{
    public interface ILancamentoRepository
    {
        Lancamento Cadastrar(Lancamento lancamento);
    }
}