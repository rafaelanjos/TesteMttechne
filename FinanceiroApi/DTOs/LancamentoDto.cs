using FinanceiroCore.Domain;
using System;

namespace FinanceiroApi.DTOs
{
    public class LancamentoDto
    {
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public char Tipo { get; set; }

        public Lancamento MapperToDomain()
        {
            return new Lancamento
            {
                Data = Data,
                Valor = Valor,
                Tipo = Tipo
            };
        }
    }
}
