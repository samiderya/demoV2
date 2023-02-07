namespace demo.Response
{
    public interface IListResponse<TModel> : IResponse
    {
        List<TModel> Model { get; set; }
    }
}