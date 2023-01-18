using BlogApi.Data;
using BlogApi.Extensions;
using BlogApi.Models;
using BlogApi.Services;
using BlogApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace BlogApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost("v1/accounts")]
        public async Task<IActionResult> Post( [FromBody] RegisterViewModel model,
         [FromServices] BlogDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };
            
            var password = PasswordGenerator.Generate(length:25);
            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new {
                    user = user.Email, password
                }));
            }
            catch(DbUpdateException e)
            {
                return StatusCode(400, new ResultViewModel<string>("05X99 - Este email já está cadastrado"));
            }
        }

        [HttpPost("v1/accounts/login")]
        public async Task<IActionResult> Login([FromServices] TokenService _tokenService,
        [FromBody] LoginViewModel model,
        [FromServices] BlogDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = await context
            .Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
                return BadRequest(new ResultViewModel<string>("Usuario ou senha invalida"));
            
            if(!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return StatusCode(401, new ResultViewModel<string>("Usuario ou senha invalido"));

            try
            {
                var token = _tokenService.GeneratedToken(user);
                return Ok(new ResultViewModel<string>(token, null));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("Falha interna do servidor"));
            }
        }

    }
}