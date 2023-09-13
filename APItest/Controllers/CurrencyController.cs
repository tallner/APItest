
using APItest.Services.External;
using Microsoft.AspNetCore.Mvc;

namespace APItest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
       // private readonly CurrencyService currencyService;

        public CurrencyController()
        {
            //this.currencyService = _currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrency()
        {
            // Create an instance of CurrencyService
            using (var httpClient = new HttpClient())
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var currencyService = new CurrencyService(httpClient, configuration);

                // Call the external API to get additional data
                string currencyLiveData = await currencyService.GetLiveData();

                return Ok(currencyLiveData);
            }
        }
    }
}
