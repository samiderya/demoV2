using src.ExchangeService.ExchangeDemo.Clients;
using Microsoft.AspNetCore.Mvc;

namespace src.ExchangeService.ExchangeDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeClient _exchangeClient;
        private readonly ILogger<ExchangeController> _logger;

        public ExchangeController(ILogger<ExchangeController> logger, IExchangeClient exchangeClient)
        {
            _logger = logger;
            _exchangeClient = exchangeClient ?? throw new ArgumentNullException(nameof(exchangeClient));
        }

        [HttpGet(Name = "GetExchange")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _exchangeClient.Get();
                return result is not null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
            }
            return BadRequest();
            
        }
    
    
    }
}