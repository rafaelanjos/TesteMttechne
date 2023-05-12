using FinanceiroCore.Domain;
using FinanceiroCore.Infrasctructure.Persistance;
using System.Collections.Generic;

namespace FinanceiroCore.Application.CadastrarLancamento
{
    public class CadastrarLancamentoCommand : ICadastrarLancamentoCommand
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public CadastrarLancamentoCommand(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public List<string> Execute(Lancamento lancamento)
        {
            lancamento.Valor = lancamento.GetValor();
            _lancamentoRepository.Cadastrar(lancamento);
            return null;
        }
    }
}
