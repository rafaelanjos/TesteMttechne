using FinanceiroCore.Domain;
using FinanceiroCore.Infrasctructure.Persistance;

namespace FinanceiroCore.Application.CadastrarLancamento
{
    public class CadastrarLancamentoCommand : ICadastrarLancamentoCommand
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public CadastrarLancamentoCommand(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public void Execute(Lancamento lancamento)
        {
            //Pode ter regras de validação ou outras regras de negocio
            _lancamentoRepository.Cadastrar(lancamento);
        }
    }
}
