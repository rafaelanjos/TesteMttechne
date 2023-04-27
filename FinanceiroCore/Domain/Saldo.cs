using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceiroCore.Domain
{
    public class Saldo
    {
        [Key]
        public DateOnly Dia { get; set; }
        public Decimal SaldoDia { get; set; }

        public static Saldo NovoSaldoDe(Lancamento lancamento)
        {
            return new Saldo
            {
                Dia = DateOnly.FromDateTime(lancamento.Data),
                SaldoDia = lancamento.Valor
            };
        }
    }
}
