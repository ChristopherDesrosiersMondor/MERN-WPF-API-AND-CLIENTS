// Importer le fichier de configuration
// dotenv est un module qui enregistre les information du fichier .env dans lenvironnement dexecution nous y donnant acces en dehors du code.
require('dotenv').config()
const cors = require("cors");
const express = require("express");
const FilmRouter = require("./Server/Routes/FilmRouter")
const SerieRouter = require("./Server/Routes/SerieRouter")

// Documentation
const swaggerUi = require('swagger-ui-express')
const swaggerFile = require('./swagger_output.json')

// mongoDb connection
const databaseObject = require('./Server/Database/connection')

const PORT = process.env.PORT || 1312

// Instancier l'application express
// Configuer l'application avec les middlewares comme cors
// définir le type d'objet pour les communications (json)
// ajouter un Router. Router défini dans ./routes/articles
const app = express()
app.use(cors())
app.use(express.json())
// /articles représente le endpoint commun entre toutes les requetes
// pour l'api présente.
app.use('/films', FilmRouter)
app.use('/series', SerieRouter)

app.use('/doc', swaggerUi.serve, swaggerUi.setup(swaggerFile))

databaseObject.connectToServer();

app.listen(PORT, () => {
    console.log('Le serveur fonctionne sur le port:', PORT)
})