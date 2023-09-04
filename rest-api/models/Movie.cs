using System;
namespace rest_api.models
{
    public class Movie
    {
        public Movie(String MoviePosterUrl, String MovieDescription,  int MovieIMDB_Score, String MovieYear, String MovieTitle, String MovieImdbID)
        {
            this.Poster = MoviePosterUrl;
            this.Description = MovieDescription;
            this.IMDB_Score = MovieIMDB_Score;
            this.imdbID = MovieImdbID;
            this.Title = MovieTitle;
            this.Year = MovieYear;
        }
            


        public String Poster { get; set; }
        public String Description { get; set; }
        public int IMDB_Score { get; set; } 
        public String imdbID{get; set;}

        public String Year{get; set;}

        public String Title {get; set;}
    } 
}
