using FinanceiroCore.Domain;

namespace FinanceiroCore.Application.CadastrarLancamento
{
    public interface ICadastrarLancamentoCommand
    {
        void Execute(Lancamento lancamento);
    }
}