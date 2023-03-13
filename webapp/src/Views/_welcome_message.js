export default function WelcomePanel() {
    return (
    <div className="flmotv">
        <img alt="" src="https://images.unsplash.com/photo-1576836165612-8bc9b07e7778?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTh8fGNvZGV8ZW58MHx8MHx8&w=1000&q=80" />
        <div className="infos">
            <h4>Bienvenu sur notre site de démo</h4>
            <p class="details">
                <span className="auteurs">Christopher Desrosiers Mondor - Charlie - Robert</span>
                <span className="published">
                <time datetime="2023-03-05">2023-03-05</time>
                </span>
            </p>
            <p className="welcome-message">Sur le site vous verrez le résultat du développement de ce client web pour notre API restful utilisant MongoDB et étant updater par un client bureau en wpf c#!</p>
        </div>
    </div>
    );
}