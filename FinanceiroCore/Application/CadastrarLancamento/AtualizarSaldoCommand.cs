using FinanceiroCore.Domain;
using FinanceiroCore.Infrasctructure.Persistance;
using System;

namespace FinanceiroCore.Application.CadastrarLancamento
{
    public class AtualizarSaldoCommand : ICadastrarLancamentoCommand
    {
        private readonly ISaldoRepository _saldoRepository;
        private readonly ICadastrarLancamentoCommand _cadastrarLancamentoCommand;

        public AtualizarSaldoCommand(ISaldoRepository saldoRepository, ICadastrarLancamentoCommand cadastrarLancamentoCommand)
        {
            _saldoRepository = saldoRepository;
            _cadastrarLancamentoCommand = cadastrarLancamentoCommand;
        }
        public void Execute(Lancamento lancamento)
        {
            _cadastrarLancamentoCommand.Execute(lancamento); //Decorator Pattern

            var saldo = _saldoRepository.ObterSaldo(DateOnly.FromDateTime(lancamento.Data));
            if (saldo == null)
            {
                saldo = Saldo.NovoSaldoDe(lancamento);
                var ultimoSaldo = _saldoRepository.ObterUltimoSaldo(); 
                
                //Saldo do dia de hoje é somado com o saldo do dia de ontem
                if (ultimoSaldo != null && saldo.Dia > ultimoSaldo.Dia)
                    saldo.SaldoDia += ultimoSaldo.SaldoDia;

                _saldoRepository.Cadastrar(saldo);
            }
            else
            {
                saldo.SaldoDia += lancamento.Valor;
                _saldoRepository.Atualizar(saldo);
            }
        }
    }
}
