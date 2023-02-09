namespace Overview.Services
{
    public interface IOverviewRepository
    {
        Task<List<OverviewDto>?> Get(string url);
    }
}
