using BlogApi.Services;
using BlogApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("v1/login")]
        public IActionResult Login([FromServices] TokenService _tokenService)
        {
            try{
                var token = _tokenService.GeneratedToken(null);

                return Ok(token);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("Falha interna no servidor"));
            }
        }
    }
}