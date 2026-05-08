using Microsoft.AspNetCore.Mvc;
using SwiftMoviesApi.Models;
using SwiftMoviesApi.Services.Interfaces;
using System.Collections.Generic;

namespace SwiftMoviesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var movies = await _movieService.GetMoviesAsync();
        return Ok(movies);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        if (movie == null)
        {
            return BadRequest("Movie data is required");
        }

        var addedMovie = await _movieService.AddMovieAsync(movie);
        return CreatedAtAction(nameof(Get), new { }, addedMovie);
    }
}
