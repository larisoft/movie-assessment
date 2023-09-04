import React from 'react';
import './DisplayMovie.css';

function DisplayMovie({ movie, onBackClick }) {
  return (
    <div className="display-movie-container">
      <div className="poster-title-container">
        <div className="poster-container">
          <img src={movie.poster} alt={movie.title} />
        </div>
        <h2 className="movie-title">{movie.title}</h2> 
        <h2 className="movie-title">{movie.year}</h2>
      </div>
      <div className="back-button-container">
        <button className="back-button" onClick={onBackClick}>Back</button>
      </div>
    </div>
  );
}

export default DisplayMovie;
