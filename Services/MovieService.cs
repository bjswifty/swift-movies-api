using Microsoft.EntityFrameworkCore;
using SwiftMoviesApi.Data;
using SwiftMoviesApi.Models;
using SwiftMoviesApi.Services.Interfaces;

namespace SwiftMoviesApi.Services;

public class MovieService : IMovieService
{
    private readonly AppDbContext _context;

    public MovieService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }
}