using System.Text.RegularExpressions;
using BlogApi.Data;
using BlogApi.Extensions;
using BlogApi.Models;
using BlogApi.Services;
using BlogApi.ViewModels;
using BlogApi.ViewModels.Accounts;
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
         [FromServices] BlogDataContext context, [FromServices] EmailService emailService)
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

                emailService.Send(
                    user.Name, 
                    user.Email, 
                    "Bem vindo ao blog", 
                    $"Sua senha é <strong>{password}</strong>"
                    );

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

        [Authorize]
        [HttpPost("v1/accounts/upload-image")]
        public async Task<IActionResult> UploadImage([FromBody] UploadImageViewModel model,
         [FromServices] BlogDataContext context)
        {
            var filename = $"{Guid.NewGuid().ToString()}.jpg";
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(model.Base64Image, "");
            var bytes = Convert.FromBase64String(data);
        
            try
            {
                await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{filename}", bytes);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResultViewModel<string>("Falha Interna do Servidor"));
            }

            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

            if (user == null)
                return NotFound(new ResultViewModel<Category>("Usuario não encontrado"));

            user.Image = $"{Configuration.localhost}images/{filename}";
            
            try
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>("Falha interna do servidor"));
            }

            return Ok(new ResultViewModel<string>("Imagem alterada com sucesso", null));
            
        }
    }
}