using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> context) : base(context)
    {
    }

    public DbSet<Filme> Filmes { get; set; }
}