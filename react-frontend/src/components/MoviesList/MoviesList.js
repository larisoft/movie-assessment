import React, { useState, useEffect } from 'react';
import SearchBox from '../Searchbox/Searchbox';
import './MoviesList.css';

import DisplayMovie from '../DisplayMovie/DisplayMovie';

function MoviesList() {
  const [searchValue, setSearchValue] = useState('');
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(false); 
  const [selectedMovie, setSelectedMovie] = useState(null);

  const handleTextChange = (text) => {
    if (text && text.length > 3) {
      setSearchValue(text);
    }
  };

  const handleMovieClick = (movie) => {
    // Set the selected movie when a movie is clicked
    setSelectedMovie(movie);
  };

  const handleBackClick = () => {
    // Clear the selected movie to return to the list
    setSelectedMovie(null);
  };

  useEffect(() => {
    // Define a function to fetch movies based on the searchValue
    const fetchMovies = async () => {
      if (searchValue.trim() === '') {
        setMovies([]);
        return;
      }

      setLoading(true);

      try {
        let filteredSearchValue = searchValue.replace(' ', '+');
        const response = await fetch(`http://localhost:5000/search-movie?search=${filteredSearchValue}`);
       
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();

        const searchResult = data.search; 

        // Check if the data received is an array
        if (Array.isArray(searchResult)) {
          setMovies(searchResult); // Assuming the backend returns an array of movies
        } else {
          setMovies([]); // Set an empty array if the data is not an array
        }
      } catch (error) {
        console.error('Error fetching movies:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchMovies();
  }, [searchValue]);

  return (
    <div className="row">
      <div className="row justify-content-center align-items-center search-container">
        <SearchBox value={searchValue} setSearchValue={setSearchValue} onTextChange={handleTextChange} />
      </div>
      {selectedMovie ? (
        <div className="row">
          <div className="col-md-4 offset-md-4">
            <DisplayMovie movie={selectedMovie} onBackClick={handleBackClick} />
          </div>
        </div>
      ) : (
        <div className="row list-container">
          <div className='col-md-2'></div>
          <div className='col-md-8'>
            <div className='row text-center'>
              {loading ? (
                <p>Loading...</p>
              ) : (
                Array.isArray(movies) && movies.length > 0 ? (
                  movies.map((movie, index) => (
                    <div className='col-md-3 image-container d-flex justify-content-start m-3' key={movie.imdbID}>
                      <img src={movie.poster} alt={movie.title} onClick={() => handleMovieClick(movie)}></img>
                      <div className='overlay d-flex align-items-center justify-content-center'></div>
                    </div>
                  ))
                ) : (
                  <p>No movies found.</p>
                )
              )}
            </div>
          </div>
          <div className='col-md-2'></div>
        </div>
      )}
    </div>
  );
}

export default MoviesList;
