using FinanceiroApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace FinanceiroApiTest
{
    public class Tests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            var application = new WebApplicationFactory<Startup>();
            _httpClient = application.CreateClient();
        }

        [Test]
        public void DeveCadastrarLancamento()
        {
            var bodyData = new LancamentoBuilder('c', 10).Build();
            var response = _httpClient.PostAsync("/api/Lancamento", TestHelpers.GetJsonStringContent(bodyData)).GetAwaiter().GetResult();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void DeveValidarTipoInvalidoValorMenorQueZeroCadastrarLancamento()
        {
            var bodyData = new LancamentoBuilder('c', 10).Build();

            var response = _httpClient.PostAsync("/api/Lancamento", TestHelpers.GetJsonStringContent(bodyData)).GetAwaiter().GetResult();
            var responseBody = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.True(responseBody.Contains("Tipo deve ser: c,d"));
            Assert.True(responseBody.Contains("Valor deve ser maior que Zero (0)"));
        }

        [Test]
        public void DeveSaldoInsulficiente()
        {
            var bodyData = new LancamentoBuilder('d', 1000).Build();

            var response = _httpClient.PostAsync("/api/Lancamento", TestHelpers.GetJsonStringContent(bodyData)).GetAwaiter().GetResult();
            var responseBody = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.True(responseBody.Contains("Saldo insulficiente para realizar este lancamento"));
        }
    }
}