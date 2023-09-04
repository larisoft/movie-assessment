using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using rest_api.interfaces;
using rest_api.models;
using rest_api.services;
using Newtonsoft.Json;
using System.Diagnostics;

namespace rest_api.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    public class MovieController : ControllerBase
    {
        private readonly string OMDB_URL;
        private readonly IHttpService _httpService;
        internal FileStorageService _fileStorageService;

        public MovieController(
            IConfiguration configuration,
            IHttpService httpService,
            IWebHostEnvironment environment)
        {
            this._httpService = httpService;
            string api_key = configuration["OMDB_API:API_KEY"];
            string omdb_url = configuration["OMDB_API:URL"];

            this.OMDB_URL = omdb_url + "?apiKey=" + api_key;
            string filePath = Path.Combine(environment.ContentRootPath, "movies.json");
            this._fileStorageService = new FileStorageService(filePath);
        }

        [HttpGet("list-saved-movies")]
        public ActionResult<List<Movie>> getList()
        {
            var lastSearchedMovies = _fileStorageService.ReadMoviesFromFile();
            return lastSearchedMovies;
        }

      
        [HttpGet("search-movie")]
        public async Task<ActionResult<MovieSearchResult>> getFromQueryAsync([FromQuery(Name = "search")] string query)
        {
            // Check if the query exists in lastSearchedMovies
            var lastSearchedMovies = _fileStorageService.ReadMoviesFromFile();
            var offlineResult = lastSearchedMovies
                .Where(movie => movie.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();


            MovieSearchResult searchResult;
            if (offlineResult.Any())
            {
                searchResult = new MovieSearchResult(); 
                searchResult.Search = offlineResult; 
                return searchResult;
            }
            else
            {
                // Query the OMDB API and update lastSearchedMovies
                string searchMovieUrl = OMDB_URL + "&s=" + query;
                string jsonData = await _httpService.GetJsonDataAsync(searchMovieUrl);

                // Deserialize the JSON data into a list of movies
                var apiResult = JsonConvert.DeserializeObject<MovieSearchResult>(jsonData);

                var movies = apiResult.Search;
                // Update lastSearchedMovies with the API result
                lastSearchedMovies.AddRange(movies);

                // Trim lastSearchedMovies to the last 10 searched movies
                if (lastSearchedMovies.Count > 10)
                {
                    lastSearchedMovies.RemoveRange(0, lastSearchedMovies.Count - 10);
                }

                // Write the updated list to the file
                _fileStorageService.WriteMoviesToFile(lastSearchedMovies);

                return apiResult;
            }
        }
    }
}
