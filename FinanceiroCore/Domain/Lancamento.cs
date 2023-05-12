using System;

namespace FinanceiroCore.Domain
{
    public class Lancamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public char Tipo { get; set; }

        internal decimal GetValor()
        {
            if (Tipo == 'c')
            {
                return Valor;
            }
            else
            {
                return Valor * -1;
            }
        }
    }
}
