const express = require('express')
const router = express.Router()
const Serie = require('../Models/series')

// Tous les series
router.get('/', async (req, res) => {
    /*
        #swagger.tags = ['Serie']
        #swagger.description = 'Endpoint to get all series'
    */
    try {
        const series = await Serie.find()
        res.status(200).send(series)
    } catch (err){
        // Erreur au niveau du serveur - 500
        res.status(500).json({ message: err.message })
    }
})


// Une serie par id
router.get('/:id', getSerie,  (req, res) => {
    /*
        #swagger.tags = ['Serie']
        #swagger.description = 'Endpoint to get serie by id.'
    */
   /*   #swagger.parameters['obj'] = {
        in: 'body',
        description: 'Getting serie by id.',
        schema: { $ref: '#/definitions/Serie' }
   }
   */
    try {
        res.status(200).send(res.serie)
    } catch (err) {
        // On ne trouve pas la serie dans la base donnees - 404
        return res.status(404).json({ message: "Le serie ne se trouve pas dans la base de donnees."})
    }
})


// Creer un serie dans la base de donnees
router.post('/', async (req, res) => {
    /*
        #swagger.tags = ['Serie']
        #swagger.description = 'Endpoint to add new serie.'
    */
   /*   #swagger.parameters['obj'] = {
        in: 'body',
        description: 'Adding new serie',
        schema: { $ref: '#/definitions/Serie' }
   }
   */
    const serie = new Serie({
        titre: req.body.titre,
        synopsis: req.body.synopsis,
        annee: req.body.annee,
        duree: req.body.duree,
        posterImage: req.body.posterImage,
        productionStatus: req.body.productionStatus,
        nombreSaisons: req.body.nombreSaisons
    })

    try {
        const nouvelleSerie = await serie.save()
        // Reussite de creation dobjet - 201
        res.status(201).json(nouvelleSerie)
    } catch (err) {
        // Erreur au niveau des donnees entrees par le client - 400
        res.status(400).json({ message: err.message })
    }
})


// Changer un serie en utilisant patch au lieu de put pour ne pas changer toute linformation si seulement certaines sont changees
router.patch('/:id', getSerie, async (req, res) => {
    /*
        #swagger.tags = ['Serie']
        #swagger.description = 'Endpoint to patch a serie'
    */
   /*   #swagger.parameters['obj'] = {
        in: 'body',
        description: 'Patching serie.',
        schema: { $ref: '#/definitions/Serie' }
   }
   */
    if (req.body.titre != null) {
        res.serie.titre = req.body.titre
    }

    if (req.body.synopsis != null) {
        res.serie.synopsis = req.body.synopsis
    }

    if (req.body.annee != null) {
        res.serie.annee = req.body.annee
    }

    if (req.body.duree != null) {
        res.serie.duree = req.body.duree
    }

    if (req.body.posterImage != null) {
        res.serie.posterImage = req.body.posterImage
    }

    if (req.body.productionStatus != null) {
        res.serie.productionStatus = req.body.productionStatus
    }

    if (req.body.nombreSaisons != null) {
        res.serie.nombreSaisons = req.body.nombreSaisons
    }

    try {
        const serieChanger = await res.serie.save()
        res.status(200).json(serieChanger)
    } catch (err) {
        // Erreur au niveau des donnees entrees par le client - 400
        res.status(400).json({ message: err.message })
    }
})


// Supprimer un serie
router.delete('/:id', getSerie, async (req, res) => {
    /*
        #swagger.tags = ['Serie']
        #swagger.description = 'Endpoint delete serie by id.'
    */
    try {
        await res.serie.remove()
        res.status(200).json({ message: 'Serie retirer de la base de donnees.'})
    } catch (err) {
        // Erreur au niveau du serveur - 500
        res.status(500).json({ message:err.message })
    }
})


// Fonction partagee par plusieurs routes
// next fera reference a la prochaine section de code
async function getSerie(req, res, next) {
    let serie
    try {
        serie = await Serie.findById(req.params.id)
        if (serie == null) {
            // On ne trouve pas l'article dans la base donnees - 404
            return res.status(404).json({ message: "Le serie ne se trouve pas dans la base de donnees."})
        }
    } catch (err) {
        // Erreur au niveau du serveur - 500
        return res.status(500).json({ message: err.message })
    }

    res.serie = serie
    next()
}

module.exports = router