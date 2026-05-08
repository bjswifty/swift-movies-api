using Microsoft.EntityFrameworkCore;
using SwiftMoviesApi.Models;

namespace SwiftMoviesApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;
}