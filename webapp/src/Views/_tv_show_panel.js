export default function TvShowPanel(tvShow) {
    return (
    <div className="flmotv">
        <div className="img-container">
            <img alt="" src={tvShow.posterImage} />
        </div>
        <div className="infos">
            <h4>{tvShow.titre}</h4>
            <p class="details">
                <span className="date">{tvShow.annee}</span>
                <span className="duree">{tvShow.duree}</span>
                <span className="nb-saisons">{tvShow.nombreSaisons}</span>
                <span className="prod-status">{tvShow.productionStatus}</span>
            </p>
            <p className="synopsis">{tvShow.synopsis}</p>
        </div>
    </div>
    );
}