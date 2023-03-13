// On utilise un fichier env avec le module dotenv pour mettre les informations
// du serveur en dehors du fichier principal qui sera visible dans le cadre
// dun éventuel déploiement
require('dotenv').config()
const mongoose = require("mongoose");
// Ligne ajouter pour repondre a une erreur pendant le developpement
//[MONGOOSE] DeprecationWarning: Mongoose: the `strictQuery` option will be switched back to `false` by default in Mongoose 7. Use `mongoose.set('strictQuery', false);` if you want to prepare for this change. Or use `mongoose.set('strictQuery', true);` to suppress this warning.
mongoose.set('strictQuery', true);

// Connection à la base de données mongoDB avec mongoose
mongoose.connect(
    process.env.ATLAS_URI, 
    {
      useNewUrlParser: true,
      useUnifiedTopology: true
    }
  );
  
  

let dbConnection;

// On exporte les fonctions suivantes pour être utilisés ailleurs dans
// le projet.
module.exports = {
    // fonction pour tester la connection au serveur
    // initialise aussi un objet de connection qui pourra être utilisé
    // par getDB() pour le reste du projet.
    connectToServer: function (callback) {
        dbConnection = mongoose.connection;
        dbConnection.on("error", console.error.bind(console, "Connection error: "));
        dbConnection.once("open", function () {
            console.log("Connexion etablie.")
        })
    },

    getDb: function () {
        return dbConnection;
    },
}