using Microsoft.AspNetCore.Mvc;
using Overview.Response;
using Overview.Services;

namespace Overview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OverviewController : ControllerBase
    {
        private readonly IOverviewRepository _overviewRepository;
        private readonly ILogger<OverviewController> _logger;

        public OverviewController(ILogger<OverviewController> logger, IOverviewRepository overviewRepository)
        {
            _logger = logger;
            _overviewRepository = overviewRepository ?? throw new ArgumentNullException(nameof(overviewRepository));
        }

        [HttpGet(Name = "GetOverview")]
        public async Task<IActionResult> Get()
        {
            //Calling Exchange url and Country  and map here to list all
          
          
            var response = new ListResponse<OverviewDto>();
            try
            {
                var res = await _overviewRepository.Get("");
                if (res == null)
                {
                    response.DidError = false;
                    response.ErrorMessage = "Data not found";
                }
                else
                {

                    response.DidError = false;
                    response.Model = res;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stopped program because of exception");
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return response.ToHttpResponse();
        }
    }
}