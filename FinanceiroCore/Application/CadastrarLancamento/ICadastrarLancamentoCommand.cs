using FinanceiroCore.Domain;
using System.Collections.Generic;

namespace FinanceiroCore.Application.CadastrarLancamento
{
    public interface ICadastrarLancamentoCommand
    {
        /// <summary>
        /// Executa o lancamento ou retorna a lista de erros se houver.
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Business error list</returns>
        List<string> Execute(Lancamento lancamento);
    }
}