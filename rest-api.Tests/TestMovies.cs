using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using rest_api.Controllers;
using rest_api.services;
using rest_api.interfaces;
using rest_api.models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Tests
{
    public class MovieControllerTests
    {
        private readonly MovieController _controller;
        private readonly Mock<IHttpService> _httpServiceMock = new Mock<IHttpService>();
        private readonly Mock<IConfiguration> _configurationMock = new Mock<IConfiguration>();
        private readonly Mock<IWebHostEnvironment> _environmentMock = new Mock<IWebHostEnvironment>();
        private readonly Mock<FileStorageService> _fileStorageServiceMock = new Mock<FileStorageService>("fakePath");

        public MovieControllerTests()
        {
            // Mock configuration to setup OMDB_URL
            _configurationMock.SetupGet(m => m[It.Is<string>(s => s == "OMDB_API:API_KEY")]).Returns("fakeApiKey");
            _configurationMock.SetupGet(m => m[It.Is<string>(s => s == "OMDB_API:URL")]).Returns("fakeUrl");

            _environmentMock.Setup(m => m.ContentRootPath).Returns("fakeRoot");

            // Initialize the controller with the mocked services
            _controller = new MovieController(_configurationMock.Object, _httpServiceMock.Object, _environmentMock.Object)
            {
                // Inject mocked FileStorageService
                _fileStorageService = _fileStorageServiceMock.Object
            };
        }

        [Fact]
        public void GetList_ReturnsExpectedMovies()
        {
            /*
            String MoviePosterUrl, String MovieDescription,  int MovieIMDB_Score, String MovieYear, String MovieTitle, String MovieImdbID
            */

            // Arrange
            var movies = new List<Movie> { new Movie("https://localhost:5000", "Test Movie", 1, "2022", "Inception", "movieId")};
            _fileStorageServiceMock.Setup(fs => fs.ReadMoviesFromFile()).Returns(movies);

            // Act
            var result = _controller.getList();

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<Movie>>>(result);
            var model = Assert.IsType<List<Movie>>(actionResult.Value);
            Assert.Single(model);
            Assert.Equal("Inception", model.First().Title);
        }

        [Fact]
        public async Task GetFromQueryAsync_ReturnsMovieFromLocal()
        {
            // Arrange
            var movies = new List<Movie> {  new Movie("https://localhost:5000", "Test Movie", 1, "2022", "Inception", "movieId") };
            _fileStorageServiceMock.Setup(fs => fs.ReadMoviesFromFile()).Returns(movies);

            // Act
            var result = await _controller.getFromQueryAsync("Inception");

            // Assert
            var actionResult = Assert.IsType<ActionResult<MovieSearchResult>>(result);
            var model = Assert.IsType<MovieSearchResult>(actionResult.Value);
            Assert.Single(model.Search);
            Assert.Equal("Inception", model.Search.First().Title);
        }

       
    }
}
