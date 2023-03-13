import { useEffect, useState } from "react";
import MoviePanel from "./_film_panel";

export default function FilmPage() {
    const [films, setFilms] = useState([]);
    useEffect(() => {
        fetch('http://localhost:1312/films').then(
            response => {
                response.json().then(films => {
                    setFilms(films);
                });
            });
    }, []);

    return (
        <div className="container">
            {films.length > 0 && films.map(film => (
                <MoviePanel {...film} />
            ))}
        </div>
    );
}