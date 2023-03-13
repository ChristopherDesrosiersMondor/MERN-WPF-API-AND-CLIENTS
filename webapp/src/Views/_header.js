import { Link } from "react-router-dom";

export default function Header() {
    return (
        <header>
            <Link to="/" className="logo">Web client fake imdb</Link>
            <nav>
                <Link to={"/films"}>Films</Link>
                <Link to={"/tv-shows"}>Tv shows</Link>
            </nav>
        </header>
    );
}