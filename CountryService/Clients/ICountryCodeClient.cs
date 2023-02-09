
using src.CountryService.CountryDemo.Models.Dtos;

namespace src.CountryService.CountryDemo.Clients
{
    public interface ICountryCodeClient
    {
        Task<CountryDto> GetCountryCode(string countryCode);
    }
}
