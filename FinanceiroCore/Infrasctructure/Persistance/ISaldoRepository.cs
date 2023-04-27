using FinanceiroCore.Domain;
using System;
using System.Collections.Generic;

namespace FinanceiroCore.Infrasctructure.Persistance
{
    public interface ISaldoRepository
    {
        Saldo Atualizar(Saldo saldo);
        Saldo Cadastrar(Saldo saldo);
        Saldo ObterSaldo(DateOnly date);
        Saldo ObterUltimoSaldo();
        IEnumerable<Saldo> Obter30Saldos();
    }
}