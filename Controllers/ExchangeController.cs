using demo.Response;
using demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : ControllerBase
    {

        private readonly IExchangeRepository _exchangeRepository;
        private readonly ILogger<ExchangeController> _logger;

        public ExchangeController(ILogger<ExchangeController> logger,IExchangeRepository exchangeRepository)
        {
            _logger = logger;
            _exchangeRepository = exchangeRepository ?? throw new ArgumentNullException(nameof(exchangeRepository));
        }

        [HttpGet(Name = "GetExchange")]
        public async Task<IActionResult> Get()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var url = MyConfig.GetValue<string>("ExchangeUrl");
            //_logger.LogInformation(string.Format($"email={email},password={password}"));
            var response = new ListResponse<ExchangeDto>();
            try
            {
                var res = await _exchangeRepository.GetAll(url);
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