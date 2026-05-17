using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SwiftMoviesApi.Data;
using SwiftMoviesApi.Models;
using SwiftMoviesApi.Services.Interfaces;

namespace SwiftMoviesApi.Services;

public class MovieService : IMovieService
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;
    private const string MovieListCacheKey = "MovieList";

    public MovieService(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        return await _cache.GetOrCreateAsync(MovieListCacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return await _context.Movies.ToListAsync();
        });
    }

    public async Task<Movie?> GetMovieByIdAsync(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        InvalidateMovieListCache();
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
        InvalidateMovieListCache();
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
        InvalidateMovieListCache();
        return true;
    }

    private void InvalidateMovieListCache()
    {
        _cache.Remove(MovieListCacheKey);
    }
}