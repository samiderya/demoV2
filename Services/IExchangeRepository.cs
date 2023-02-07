namespace demo.Services
{
    public interface IExchangeRepository
    {
        Task<List<ExchangeDto>?> GetAll(string url);
    }
}
