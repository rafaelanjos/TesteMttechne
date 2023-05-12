using FinanceiroCore.Domain;
using FinanceiroCore.Infrasctructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroCore.Application.CadastrarLancamento
{
    public class ValidateCadastrarLancamentoCommand : ICadastrarLancamentoCommand
    {
        private readonly ISaldoRepository _saldoRepository;
        private readonly ICadastrarLancamentoCommand _atualizarSaldoCommand;

        public ValidateCadastrarLancamentoCommand(ISaldoRepository saldoRepository, ICadastrarLancamentoCommand atualizarSaldoCommand)
        {
            _saldoRepository = saldoRepository;
            _atualizarSaldoCommand = atualizarSaldoCommand;
        }

        public List<string> Execute(Lancamento lancamento)
        {
            List<string> errors = new List<string>();

            var valor = lancamento.GetValor();
            var novoSaldo = valor;
            
            var ultimoSaldo = _saldoRepository.ObterUltimoSaldo();
            if (ultimoSaldo != null)
            {
                novoSaldo = ultimoSaldo.SaldoDia + valor;
            }

            if (novoSaldo < 0)
            {
                errors.Add("Saldo insulficiente para realizar este lancamento");
            }
            else
            {
                _atualizarSaldoCommand.Execute(lancamento);
            }
            return errors;
        }
    }
}
