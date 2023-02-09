using System.Text.Json;

namespace Overview.Services
{
    public class OverviewRepository : IOverviewRepository
    {
        public  async Task<List<OverviewDto>?> Get(string url)
        {
                using var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                    var res = response.Content.ReadAsStringAsync();
                  //  Console.WriteLine("data",((System.Text.Json.JsonElement)res).ValueKind);
                   
                    return await response.Content.ReadFromJsonAsync<List<OverviewDto>>();
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

        Task<List<OverviewDto>?> IOverviewRepository.Get(string url)
        {
            throw new NotImplementedException();
        }
    }
}
