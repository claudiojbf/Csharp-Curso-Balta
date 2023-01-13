using BlogApi.Data;
using BlogApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    ;
builder.Services.AddDbContext<BlogDataContext>();

builder.Services.AddTransient<TokenService>(); //Sempre criar um novo
// builder.Services.AddScoped(); //Requisição
// builder.Services.AddSingleton(); // Singleton -> 1 por App!

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
