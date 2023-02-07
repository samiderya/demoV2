
using System.Collections.Generic;

namespace demo.Response
{
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string? Message { get; set; }

        public bool DidError { get; set; }

        public string? ErrorMessage { get; set; }

        public List<TModel>? Model { get; set; }
    }
}
