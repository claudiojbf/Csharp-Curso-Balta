using BlogApi.Attributes;
using Microsoft.AspNetCore.Mvc;


namespace BlogApi.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        [ApiKey]
        public IActionResult Get([FromServices] IConfiguration config)
        {
            var env = config.GetValue<string>("Env");
            return Ok(new 
            {
                environment = env
            });
        }
    }
}
