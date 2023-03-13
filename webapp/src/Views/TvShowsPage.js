import { useEffect, useState } from "react";
import TvShowPanel from "./_tv_show_panel";

export default function FilmPage() {
    const [series, setSeries] = useState([]);
    useEffect(() => {
        fetch('http://localhost:1312/series').then(
            response => {
                response.json().then(series => {
                    setSeries(series);
                });
            });
    }, []);

    return (
        <div>
            {series.length > 0 && series.map(serie => (
                <TvShowPanel {...serie} />
            ))}
        </div>
    );
}