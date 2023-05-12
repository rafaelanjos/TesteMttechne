using FinanceiroApi.DTOs;

namespace FinanceiroApiTest
{
    public class LancamentoBuilder
    {
        private readonly char tipo;
        private readonly decimal valor;

        public LancamentoBuilder(char tipo, decimal valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }

        public LancamentoDto Build()
        {
            return new LancamentoDto()
            {
                Data = DateTime.Now,
                Tipo = tipo,
                Valor = valor
            };
        }
    }
}
