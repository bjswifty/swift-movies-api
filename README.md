# Swift Movies API

A simple ASP.NET Core Web API that provides movie data and health check endpoints.

## Description

This is a lightweight REST API built with .NET 6 that serves a collection of movies. It's designed for learning purposes and demonstrates basic ASP.NET Core Web API concepts including controllers, routing, and Swagger documentation.

## Features

- **Movies Endpoint**: Retrieve a list of movies with basic information
- **Health Check**: Monitor API availability
- **Swagger Documentation**: Interactive API documentation
- **Minimal API**: Built with ASP.NET Core minimal hosting

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- Your favorite code editor (VS Code, Visual Studio, etc.)

## Installation

1. Clone or download this repository
2. Navigate to the project directory:
   ```bash
   cd swift-movies-api
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

## Running the Application

Start the API server:

```bash
dotnet run
```

The API will be available at:
- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001

## API Endpoints

### Get Movies
**GET** `/api/movie`

Returns a list of movies.

**Example Request:**
```bash
curl http://localhost:5000/api/movie
```

**Example Response:**
```json
[
  {
    "id": 1,
    "title": "Inception",
    "year": 2010
  },
  {
    "id": 2,
    "title": "The Matrix",
    "year": 1999
  },
  {
    "id": 3,
    "title": "Interstellar",
    "year": 2014
  },
  {
    "id": 4,
    "title": "The Dark Knight",
    "year": 2008
  },
  {
    "id": 5,
    "title": "Parasite",
    "year": 2019
  }
]
```

### Health Check
**GET** `/health`

Returns the health status of the API.

**Example Request:**
```bash
curl http://localhost:5000/health
```

**Example Response:**
```
Healthy
```

## API Documentation

View interactive API documentation at:
- **Swagger UI**: http://localhost:5000/swagger

## Project Structure

```
swift-movies-api/
├── Controllers/
│   └── MovieController.cs    # Movies API endpoints
├── Models/
│   └── Movie.cs             # Movie data model
├── Program.cs               # Application entry point
├── swift-movies-api.csproj  # Project configuration
└── README.md               # This file
```

## Technologies Used

- **ASP.NET Core 6**: Web framework
- **C# 10**: Programming language
- **Swagger/OpenAPI**: API documentation
- **Health Checks**: Service monitoring

## Development

To modify the API:

1. Edit the controllers in the `Controllers/` folder
2. Update models in the `Models/` folder
3. Run `dotnet build` to compile
4. Run `dotnet run` to start the server

## Testing

Test the endpoints using:
- **Browser**: Navigate to the URLs
- **curl**: Command line HTTP client
- **Postman**: API testing tool
- **Swagger UI**: Interactive testing interface

## Future Enhancements

- Database integration
- Authentication and authorization
- Additional CRUD operations
- Movie search and filtering
- Pagination support