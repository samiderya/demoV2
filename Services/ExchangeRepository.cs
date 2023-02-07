using Newtonsoft.Json;

namespace demo.Services
{
    public class ExchangeRepository : IExchangeRepository
    {
        public  async Task<List<ExchangeDto>?> GetAll(string url)
        {
                using var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                    return await response.Content.ReadFromJsonAsync<List<ExchangeDto>>();
                    }
                    catch (NotSupportedException) // When content type is not valid
                    {
                        Console.WriteLine("The content type is not supported.");
                    }
                    catch (JsonException) // Invalid JSON
                    {
                        Console.WriteLine("Invalid JSON.");
                    }


                }
                    return null;
            }
          

    }
}
