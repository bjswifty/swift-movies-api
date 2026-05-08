using SwiftMoviesApi.Models;

namespace SwiftMoviesApi.Services.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMoviesAsync();
    Task<Movie> AddMovieAsync(Movie movie);
    Task<Movie?> UpdateMovieAsync(Movie movie);
}