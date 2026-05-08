using Microsoft.AspNetCore.Mvc;
using SwiftMoviesApi.Models;
using System.Collections.Generic;

namespace SwiftMoviesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Year = 2010 },
            new Movie { Id = 2, Title = "The Matrix", Year = 1999 },
            new Movie { Id = 3, Title = "Interstellar", Year = 2014 },
            new Movie { Id = 4, Title = "The Dark Knight", Year = 2008 },
            new Movie { Id = 5, Title = "Parasite", Year = 2019 }
        };

        return Ok(movies);
    }
}
