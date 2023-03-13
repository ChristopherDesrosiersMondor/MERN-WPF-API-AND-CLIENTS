const express = require('express')
const router = express.Router()
const Film = require('../Models/films')

// Tous les films
router.get('/', async (req, res) => {
    /*
        #swagger.tags = ['Film']
        #swagger.description = 'Endpoint to get all films'
    */
    try {
        /*
            #swagger.responses[200] = {
                schema: { "$ref: "#/definitions/Film" },
                description: "Film added successfully."
            }
        */
        const films = await Film.find()
        res.status(200).send(films)
    } catch (err){
        // Erreur au niveau du serveur - 500
        res.status(500).json({ message: err.message })
    }
})


// Un film par id
router.get('/:id', getFilm,  (req, res) => {
    /*
        #swagger.tags = ['Film']
        #swagger.description = 'Endpoint to get film by id'
    */
    /*   #swagger.parameters['obj'] = {
            in: 'body',
            description: 'Getting a film by id',
            schema: { $ref: '#/definitions/Film' }
        }
    */
    try {
        /* #swagger.responses[200] = {
            description: 'Getting a film successfully',
            schema: { $ref: '#/definitions/Film' }
        */
        res.status(200).send(res.film)
    } catch (err) {
        /* #swagger.responses[400] = {
            description: 'Failed to find film',
            schema: { 
                message: "Le film ne se trouve pas dans la base de donnees."
             }
        */
        return res.status(404).json({ message: "Le film ne se trouve pas dans la base de donnees."})
    }
})


// Creer un film dans la base de donnees
router.post('/', async (req, res) => {
    /*
        #swagger.tags = ['Film']
        #swagger.description = 'Endpoint to add a new film'
    */
   /*   #swagger.parameters['obj'] = {
        in: 'body',
        description: 'Adding new film.',
        schema: { $ref: '#/definitions/Film' }
   }
   */
    const film = new Film({
        titre: req.body.titre,
        synopsis: req.body.synopsis,
        annee: req.body.annee,
        duree: req.body.duree,
        posterImage: req.body.posterImage
    })

    try {
        const nouveauFilm = await film.save()
        /* #swagger.responses[201] = {
            description: 'Film successfully created',
            schema: { $ref: '#/definitions/someDefinition' }
        */
        res.status(201).json(nouveauFilm)
    } catch (err) {
        /* #swagger.responses[400] = {
            description: 'Bad data from client',
            schema: { $ref: '#/definitions/someDefinition' }
        */
        res.status(400).json({ message: err.message })
    }
})


// Changer un film en utilisant patch au lieu de put pour ne pas changer toute linformation si seulement certaines sont changees
router.patch('/:id', getFilm, async (req, res) => {
    /*
        #swagger.tags = ['Film']
        #swagger.description = 'Endpoint to patch a film'
    */
   /*   #swagger.parameters['obj'] = {
        in: 'body',
        description: 'Getting confirmation of updated film',
        schema: { $ref: '#/definitions/Film' }
   }
   */
    if (req.body.titre != null && res.film.titre != req.body.titre) {
        res.film.titre = req.body.titre
    }

    if (req.body.synopsis != null && res.film.synopsis != req.body.synopsis) {
        res.film.synopsis = req.body.synopsis
    }

    if (req.body.annee != null && res.film.annee != req.body.annee) {
        res.film.annee = req.body.annee
    }

    if (req.body.duree != null && res.film.duree != req.body.duree) {
        res.film.duree = req.body.duree
    }

    if (req.body.posterImage != null && res.film.posterImage != req.body.posterImage) {
        res.film.posterImage = req.body.posterImage
    }

    try {
        const filmChanger = await res.film.save()
        res.status(200).json(filmChanger)
    } catch (err) {
        // Erreur au niveau des donnees entrees par le client - 400
        res.status(400).json({ message: err.message })
    }
})


// Supprimer un film
router.delete('/:id', getFilm, async (req, res) => {
    /*
        #swagger.tags = ['Film']
        #swagger.description = 'Endpoint to delete a film by its id.'
    */
    try {
        await res.film.remove()
        res.status(200).json({ message: 'Film retirer de la base de donnees.'})
    } catch (err) {
        // Erreur au niveau du serveur - 500
        res.status(500).json({ message:err.message })
    }
})


// Fonction partagee par plusieurs routes
// next fera reference a la prochaine section de code
async function getFilm(req, res, next) {
    let film
    try {
        film = await Film.findById(req.params.id)
        if (film == null) {
            // On ne trouve pas l'article dans la base donnees - 404
            return res.status(404).json({ message: "Le film ne se trouve pas dans la base de donnees."})
        }
    } catch (err) {
        // Erreur au niveau du serveur - 500
        return res.status(500).json({ message: err.message })
    }

    res.film = film
    next()
}

module.exports = router