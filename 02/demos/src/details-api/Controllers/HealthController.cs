using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookInfo.Details.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        protected readonly IConfiguration _configuration;

        public HealthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "Details is healthy" });
        }
    }
}