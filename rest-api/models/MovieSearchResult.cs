using System.Collections.Generic;

namespace rest_api.models
{
    public class MovieSearchResult
    {
        public List<Movie> Search { get; set; }
        // Add other properties as needed to match the OMDB API response structure
    }
}
