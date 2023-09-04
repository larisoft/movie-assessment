import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.min.css'
import MoviesList from './components/MoviesList/MoviesList'; 
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <MoviesList/>
         
      </header>
    </div>
  );
}

export default App;
