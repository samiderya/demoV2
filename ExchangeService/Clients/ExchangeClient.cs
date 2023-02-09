using src.ExchangeService.ExchangeDemo.Models.Dtos;
using Newtonsoft.Json;

namespace src.ExchangeService.ExchangeDemo.Clients
{
    public class ExchangeClient : IExchangeClient
    {
        private readonly HttpClient _httpClient;
        public ExchangeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExchangeDto>?> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress);
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return await response.Content.ReadFromJsonAsync<List<ExchangeDto>>();
                }
                catch (NotSupportedException) // When content type is not valid
                {
                    throw new InvalidOperationException("The content type is not supported.");
                }
                catch (JsonException) // Invalid JSON
                {
                    throw new Exception("Invalid JSON.");
                }


            }
            throw new Exception("there is ");
        }
    }
}
