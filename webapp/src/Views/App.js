import { Route, Routes } from 'react-router-dom';
import Layout from '../Layout';
import './App.css';
import FilmPage from './FilmPage';
import TvShowsPage from './TvShowsPage';
import Index from './IndexPage';

function App() {
  return  (
    <Routes>
      <Route path="/" element={<Layout />}>
        
        <Route index 
              element={
                <Index />
              }
        />

        <Route path={'/films'} 
              element={
                <FilmPage />
              }
        />

        <Route path={'/tv-shows'}
              element={
                <TvShowsPage />
              }
        />

      </ Route>
    </Routes>

  );
}

export default App;
