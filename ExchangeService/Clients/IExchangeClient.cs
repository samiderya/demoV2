using src.ExchangeService.ExchangeDemo.Models.Dtos;

namespace src.ExchangeService.ExchangeDemo.Clients
{
    public interface IExchangeClient
    {
        Task<List<ExchangeDto>?> Get();
    }
}
