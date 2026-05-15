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

    public async Task<Movie?> GetMovieByIdAsync(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie?> UpdateMovieAsync(Movie movie)
    {
        if (movie == null || movie.Id <= 0)
        {
            return null;
        }

        var existing = await _context.Movies.FindAsync(movie.Id);
        if (existing == null)
        {
            return null;
        }

        existing.Title = movie.Title;
        existing.Year = movie.Year;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteMovieAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return false;
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return true;
    }
}