export default function MoviePanel(film) {
    return (
    <div className="flmotv">
        <div className="img-container">
            <img alt="" src={film.posterImage} />
        </div>
        <div className="infos">
            <h4>{film.titre}</h4>
            <p class="details">
                <span className="date">{film.annee}</span>
                <span className="duree">{film.duree}</span>
            </p>
            <p className="synopsis">{film.synopsis}</p>
        </div>
    </div>
    );
}