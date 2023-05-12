using System.Text;
using System.Text.Json;

namespace FinanceiroApiTest
{
    public static class TestHelpers
    {
        private const string _jsonMediaType = "application/json";
        private const int _expectedMaxElapsedMilliseconds = 1000;
        private static JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };


        public static StringContent GetJsonStringContent<T>(T model)
            => new(JsonSerializer.Serialize(model), Encoding.UTF8, _jsonMediaType);
    }
}
