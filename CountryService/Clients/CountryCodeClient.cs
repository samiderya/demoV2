using Newtonsoft.Json;
using src.CountryService.CountryDemo.Models.Dtos;

namespace src.CountryService.CountryDemo.Clients
{
    public class CountryCodeClient: ICountryCodeClient
    {
        private readonly HttpClient _httpClient;
  
        public CountryCodeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CountryDto> GetCountryCode(string countryCode)
        {
            var responseString = await _httpClient.GetStringAsync($"wpgp?iso3={countryCode}");
            var str1= (responseString.Trim().Remove(0,8));
            var  str2 = str1.Remove(str1.Length - 1, 1);
            var _Resp = JsonConvert.DeserializeObject<List<CountryDto>>(str2);
            return _Resp.FirstOrDefault();
        }
    }
}
