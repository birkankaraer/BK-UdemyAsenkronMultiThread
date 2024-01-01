using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("istek basladi");

                await Task.Delay(5000, token);

                var mytask = new HttpClient().GetStringAsync("http://www.google.com");

                var data = await mytask;

                _logger.LogInformation("istek bitti");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("istek iptal edildi:" + ex.Message);
                return BadRequest();
            }
            
        }
    }
}
