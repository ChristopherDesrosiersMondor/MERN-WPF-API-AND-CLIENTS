# API

Nous verrons ici toutes les étapes nécessaires à l'utilisation de cette API qui est le backbone du projet en entier!

- [API](#api)
  - [Installation](#installation)
  - [Documentation](#documentation)
  - [Utilisation et tests](#utilisation-et-tests)
    - [Get - All films](#get---all-films)
    - [Get - All tv shows](#get---all-tv-shows)
    - [Get - film by id](#get---film-by-id)
      - [Succès (Get - film by id)](#succès-get---film-by-id)
      - [Échec (Get - film by id)](#échec-get---film-by-id)
    - [Get - Tv show by id](#get---tv-show-by-id)
      - [Succès (Get - Tv show by id)](#succès-get---tv-show-by-id)
      - [Échec (Get - Tv show by id)](#échec-get---tv-show-by-id)
    - [Post - Film](#post---film)
      - [Succès (Post - Film)](#succès-post---film)
      - [Échec (Post - Film)](#échec-post---film)
    - [Post - Tv show](#post---tv-show)
      - [Succès (Post - Tv show)](#succès-post---tv-show)
      - [Échec (Post - Tv show)](#échec-post---tv-show)
    - [Patch - Film](#patch---film)
      - [Succès (Patch - Film)](#succès-patch---film)
      - [Échec (Patch - Film)](#échec-patch---film)
    - [Patch - Tv show](#patch---tv-show)
      - [Succès (Patch - Tv show)](#succès-patch---tv-show)
      - [Échec (Patch - Tv show)](#échec-patch---tv-show)
    - [Delete - Film](#delete---film)
      - [Succès (Delete - Film)](#succès-delete---film)
      - [Échec (Delete - Film)](#échec-delete---film)
    - [Delete - Tv show](#delete---tv-show)
      - [Succès (Delete - Tv show)](#succès-delete---tv-show)
      - [Échec (Delete - Tv show)](#échec-delete---tv-show)
  - [Les sources d'inspirations et d'apprentissage](#les-sources-dinspirations-et-dapprentissage)
  - [Support](#support)
  - [Auteurs et reconnaissances](#auteurs-et-reconnaissances)
    - [Les membres de l'équipe](#les-membres-de-léquipe)
  - [État du projet](#état-du-projet)

## Installation

Le déploiement de l'api dans un environnement de développement inclus plusieurs étapes de mise en place, mais rien de trop compliqué. Voici les étapes à suivre.  

1. Télécharger le projet sur votre machine.
2. Installer mangodb community server - Pendant l'installation conservez les configurations par default.
    <https://www.mongodb.com/try/download/community>

3. Ouvrir MongoDBCompass et vous connecter à l'adresse de la base de donnée proposée (ce devrait être : mongodb://localhost:27017).
4. Dans VScode, ouvrez le projet et lancer un terminal. Si vous ne l'avez pas déja, vous aurez aussi besoin de l'extension: rest client
5. Positionnez vous dans le dossier API à l'aide de la commande suivante

    ```terminal
    cd '.\Évaluation finale\API'
    ```

6. Lancer la commande suivante pour installer les dépendances du projet

    ```terminal
    npm install
    ```

7. Lancer l'api avec la commande suivante

    ```terminal
    npm run developement
    ```

## Documentation

Vous pouvez consulter la documentation swagger à l'adresse suivante après avoir suivit les étapes d'installation : <http://localhost:1312/doc/>

## Utilisation et tests

Tous les tests peuvent être trouvés dans le fichier tests.rest

Pour faire vos propres tests, vous devez toujours vous assurer d'avoir les bon id en utilisant les méthodes get all sur les films et séries, à moins de vouloir tester les erreurs! Voici des exemples de tous les tests avec leurs requêtes et leurs réponses selon les situations.

### Get - All films

Requête:

```rest
GET http://localhost:1312/films/ HTTP/1.1
```

Réponse:

```json
[
  {
    "_id": "63ff8f35e5eb1b8693c08659",
    "titre": "Dune",
    "synopsis": "In the distant future, Duke Leto of House Atreides, ruler of the ocean planet Caladan, is assigned by the Padishah Emperor Shaddam IV of House Corrino to replace House Harkonnen as the fiefholder of Arrakis, a harsh desert planet and the only source of \"spice\", a valuable psychotropic drug that imparts heightened vitality and awareness to its users.",
    "annee": "2021",
    "duree": "155",
    "posterImage": "https://upload.wikimedia.org/wikipedia/en/8/8e/Dune_%282021_film%29.jpg",
    "__v": 0
  },
  {
    "_id": "6401fb33362a47615b7427e9",
    "titre": "Avatar",
    "synopsis": "In 2154, the natural resources of the Earth have been depleted. The Resources Development Administration (RDA) mines the valuable mineral unobtanium on Pandora, a moon in the Alpha Centauri star system. Pandora, whose atmosphere is inhospitable to humans, is inhabited by the Na'vi, 10-foot-tall (3.0 m), blue-skinned, sapient humanoids that live in harmony with nature. To explore Pandora, genetically matched human scientists use Na'vi-human hybrids called \"avatars.\"",
    "annee": "2009",
    "duree": "162",
    "posterImage": "https://upload.wikimedia.org/wikipedia/en/thumb/d/d6/Avatar_%282009_film%29_poster.jpg/220px-Avatar_%282009_film%29_poster.jpg",
    "__v": 0
  },
  {
    "_id": "6401fd46362a47615b7427f3",
    "titre": "Collateral Damage",
    "synopsis": "A bomb detonates in the plaza of the Colombian Consulate building in Los Angeles, killing nine people, including a caravan of Colombian officials and American intelligence agents. Among the civilians killed are the wife and son of an LAFD firefighter, Captain Gordon \"Gordy\" Brewer, who was injured in the explosion.",
    "annee": "2002",
    "duree": "109",
    "posterImage": "https://upload.wikimedia.org/wikipedia/en/thumb/d/d0/Collateral_Damage_film.jpg/220px-Collateral_Damage_film.jpg",
    "__v": 0
  }
]

```

### Get - All tv shows

Requête:

```rest
GET http://localhost:1312/series/ HTTP/1.1
```

Réponse:

```json
[
  {
    "_id": "63ff8e79e5eb1b8693c08652",
    "titre": "The magicians",
    "synopsis": "Quentin Coldwater enrolls at Brakebills University for Magical Pedagogy to be trained as a magician, where he discovers that the magical world from his favorite childhood book is real and poses a danger to humanity. Meanwhile, the life of his childhood friend Julia is derailed when she is denied entry, and she searches for magic elsewhere outside of the school.",
    "annee": "2015-2020",
    "duree": "41-52",
    "posterImage": "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQk7-HgsnULrB_996llKozoJF_sHR3OLRc8GchfYsv3Y6qj7Gai",
    "productionStatus": "Ended",
    "nombreSaisons": 5,
    "__v": 0
  },
  {
    "_id": "63ff8fdfe5eb1b8693c08666",
    "titre": "Prison break",
    "synopsis": "The first season follows the rescue of Lincoln Burrows, who is accused of murdering Terrence Steadman, the brother of Vice President of the United States, Caroline Reynolds. Lincoln is sentenced to death and is incarcerated in Fox River State Penitentiary where he awaits his execution.",
    "annee": "2005-2009",
    "duree": "42-44",
    "posterImage": "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F6%2F2017%2F02%2Fprison-break-2000.jpg",
    "productionStatus": "Ended",
    "nombreSaisons": 5,
    "__v": 0
  }
]
```

### Get - film by id

#### Succès (Get - film by id)

En utilisant un ID qui est dans la base de données.

```rest
GET http://localhost:1312/films/63ff8f35e5eb1b8693c08659 HTTP/1.1
```

Réponse:

```json
{
  "_id": "63ff8f35e5eb1b8693c08659",
  "titre": "Dune",
  "synopsis": "In the distant future, Duke Leto of House Atreides, ruler of the ocean planet Caladan, is assigned by the Padishah Emperor Shaddam IV of House Corrino to replace House Harkonnen as the fiefholder of Arrakis, a harsh desert planet and the only source of \"spice\", a valuable psychotropic drug that imparts heightened vitality and awareness to its users.",
  "annee": "2021",
  "duree": "155",
  "posterImage": "https://upload.wikimedia.org/wikipedia/en/8/8e/Dune_%282021_film%29.jpg",
  "__v": 0
}
```

#### Échec (Get - film by id)

En utilisant un ID qui n'est pas dans la base de données.

```rest
GET http://localhost:1312/films/63ff8f35e5eb1b8693c08659 HTTP/1.1
```

Réponse:

```json
{
  "message": "Le film ne se trouve pas dans la base de donnees."
}
```

### Get - Tv show by id

#### Succès (Get - Tv show by id)

En utilisant un Id qui est dans la base de données.

Requête:

```rest
GET http://localhost:1312/series/63ff8e79e5eb1b8693c08652 HTTP/1.1
```

Réponse:

```json
{
  "_id": "63ff8e79e5eb1b8693c08652",
  "titre": "The magicians",
  "synopsis": "Quentin Coldwater enrolls at Brakebills University for Magical Pedagogy to be trained as a magician, where he discovers that the magical world from his favorite childhood book is real and poses a danger to humanity. Meanwhile, the life of his childhood friend Julia is derailed when she is denied entry, and she searches for magic elsewhere outside of the school.",
  "annee": "2015-2020",
  "duree": "41-52",
  "posterImage": "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQk7-HgsnULrB_996llKozoJF_sHR3OLRc8GchfYsv3Y6qj7Gai",
  "productionStatus": "Ended",
  "nombreSaisons": 5,
  "__v": 0
}
```

#### Échec (Get - Tv show by id)

En utilisant un ID qui n'est pas dans la base de données.

Requête:

```rest
GET http://localhost:1312/series/63ff8e79e5eb1b8693c08657 HTTP/1.1
```

Réponse:

```json
{
  "message": "Le serie ne se trouve pas dans la base de donnees."
}
```

### Post - Film

#### Succès (Post - Film)

Requête:

```rest
POST http://localhost:1312/films/ HTTP/1.1
Content-Type: application/json

{
  "titre": "Dune -2",
  "synopsis": "In the distant future, Duke Leto of House Atreides, ruler of the ocean planet Caladan, is assigned by the Padishah Emperor Shaddam IV of House Corrino to replace House Harkonnen as the fiefholder of Arrakis, a harsh desert planet and the only source of \"spice\", a valuable psychotropic drug that imparts heightened vitality and awareness to its users.",
  "annee": "2021",
  "duree": "155",
  "posterImage": "https://upload.wikimedia.org/wikipedia/en/8/8e/Dune_%282021_film%29.jpg"
}
```

Réponse:

```json
{
  "titre": "Dune -2",
  "synopsis": "In the distant future, Duke Leto of House Atreides, ruler of the ocean planet Caladan, is assigned by the Padishah Emperor Shaddam IV of House Corrino to replace House Harkonnen as the fiefholder of Arrakis, a harsh desert planet and the only source of \"spice\", a valuable psychotropic drug that imparts heightened vitality and awareness to its users.",
  "annee": "2021",
  "duree": "155",
  "posterImage": "https://upload.wikimedia.org/wikipedia/en/8/8e/Dune_%282021_film%29.jpg",
  "_id": "640220e3362a47615b742814",
  "__v": 0
}
```

#### Échec (Post - Film)

Requête:

```rest
POST http://localhost:1312/films/ HTTP/1.1
Content-Type: application/json

{
  "titre": "Dune -2",
  "synopsis": "In the distant future, Duke Leto of House Atreides, ruler of the ocean planet Caladan, is assigned by the Padishah Emperor Shaddam IV of House Corrino to replace House Harkonnen as the fiefholder of Arrakis, a harsh desert planet and the only source of \"spice\", a valuable psychotropic drug that imparts heightened vitality and awareness to its users.",
  "posterImage": "https://upload.wikimedia.org/wikipedia/en/8/8e/Dune_%282021_film%29.jpg"
}
```

Réponse:

```json
{
  "message": "Film validation failed: annee: Path `annee` is required., duree: Path `duree` is required."
}
```

### Post - Tv show

#### Succès (Post - Tv show)

Requête:

```rest
POST http://localhost:1312/series/ HTTP/1.1
Content-Type: application/json

{
  "titre": "The magicians - 2",
  "synopsis": "Quentin Coldwater enrolls at Brakebills University for Magical Pedagogy to be trained as a magician, where he discovers that the magical world from his favorite childhood book is real and poses a danger to humanity. Meanwhile, the life of his childhood friend Julia is derailed when she is denied entry, and she searches for magic elsewhere outside of the school.",
  "annee": "2015-2020",
  "duree": "41-52",
  "posterImage": "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQk7-HgsnULrB_996llKozoJF_sHR3OLRc8GchfYsv3Y6qj7Gai",
  "productionStatus": "Ended",
  "nombreSaisons": 5
}
```

Réponse:

```json
{
  "titre": "The magicians - 2",
  "synopsis": "Quentin Coldwater enrolls at Brakebills University for Magical Pedagogy to be trained as a magician, where he discovers that the magical world from his favorite childhood book is real and poses a danger to humanity. Meanwhile, the life of his childhood friend Julia is derailed when she is denied entry, and she searches for magic elsewhere outside of the school.",
  "annee": "2015-2020",
  "duree": "41-52",
  "posterImage": "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQk7-HgsnULrB_996llKozoJF_sHR3OLRc8GchfYsv3Y6qj7Gai",
  "productionStatus": "Ended",
  "nombreSaisons": 5,
  "_id": "6402217e362a47615b742817",
  "__v": 0
}
```

#### Échec (Post - Tv show)

Requête:

```rest
POST http://localhost:1312/series/ HTTP/1.1
Content-Type: application/json

{
  "titre": "The magicians",
  "synopsis": "Quentin Coldwater enrolls at Brakebills University for Magical Pedagogy to be trained as a magician, where he discovers that the magical world from his favorite childhood book is real and poses a danger to humanity. Meanwhile, the life of his childhood friend Julia is derailed when she is denied entry, and she searches for magic elsewhere outside of the school.",
  "posterImage": "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQk7-HgsnULrB_996llKozoJF_sHR3OLRc8GchfYsv3Y6qj7Gai",
  "productionStatus": "Ended",
  "nombreSaisons": 5
}
```

Réponse:

```json
{
  "message": "Serie validation failed: annee: Path `annee` is required., duree: Path `duree` is required."
}
```

### Patch - Film

#### Succès (Patch - Film)

Requête:

```rest
PATCH http://localhost:1312/films/640220e3362a47615b742814 HTTP/1.1
Content-Type: application/json

{
  "titre": "Dune - 2 - patch test"
}
```

Réponse:

```json
{
  "_id": "640220e3362a47615b742814",
  "titre": "Dune - 2 - patch test",
  "synopsis": "In the distant future, Duke Leto of House Atreides, ruler of the ocean planet Caladan, is assigned by the Padishah Emperor Shaddam IV of House Corrino to replace House Harkonnen as the fiefholder of Arrakis, a harsh desert planet and the only source of \"spice\", a valuable psychotropic drug that imparts heightened vitality and awareness to its users.",
  "annee": "2021",
  "duree": "155",
  "posterImage": "https://upload.wikimedia.org/wikipedia/en/8/8e/Dune_%282021_film%29.jpg",
  "__v": 0
}
```

#### Échec (Patch - Film)

Requête:

```rest
PATCH http://localhost:1312/films/640220e3362a47615b742817 HTTP/1.1
Content-Type: application/json

{
  "titre": "Dune - 2 - patch test fail"
}
```

Réponse:

```json
{
  "message": "Le film ne se trouve pas dans la base de donnees."
}
```

### Patch - Tv show

#### Succès (Patch - Tv show)

Requête:

```rest
PATCH http://localhost:1312/series/6402217e362a47615b742817 HTTP/1.1
Content-Type: application/json

{
  "titre": "The magicians - 2 - patch test"
}
```

Réponse:

```json
{
  "_id": "6402217e362a47615b742817",
  "titre": "The magicians - 2 - patch test",
  "synopsis": "Quentin Coldwater enrolls at Brakebills University for Magical Pedagogy to be trained as a magician, where he discovers that the magical world from his favorite childhood book is real and poses a danger to humanity. Meanwhile, the life of his childhood friend Julia is derailed when she is denied entry, and she searches for magic elsewhere outside of the school.",
  "annee": "2015-2020",
  "duree": "41-52",
  "posterImage": "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQk7-HgsnULrB_996llKozoJF_sHR3OLRc8GchfYsv3Y6qj7Gai",
  "productionStatus": "Ended",
  "nombreSaisons": 5,
  "__v": 0
}
```

#### Échec (Patch - Tv show)

Requête:

```rest
PATCH http://localhost:1312/series/6402217e362a47615b742815 HTTP/1.1
Content-Type: application/json

{
  "titre": "The magicians - 2 - patch test"
}
```

Réponse:

```json
{
  "message": "Le serie ne se trouve pas dans la base de donnees."
}
```

### Delete - Film

#### Succès (Delete - Film)

Requête:

```rest
DELETE http://localhost:1312/films/640220e3362a47615b742814 HTTP/1.1
```

Réponse:

```json
{
  "message": "Film retirer de la base de donnees."
}
```

#### Échec (Delete - Film)

Requête:

```rest
DELETE http://localhost:1312/films/640220e3362a47615b742814 HTTP/1.1
```

Réponse:

```json
{
  "message": "Le film ne se trouve pas dans la base de donnees."
}
```

### Delete - Tv show

#### Succès (Delete - Tv show)

Requête:

```rest
DELETE http://localhost:1312/series/6402217e362a47615b742817 HTTP/1.1
```

Réponse:

```json
{
  "message": "Serie retirer de la base de donnees."
}
```

#### Échec (Delete - Tv show)

Requête:

```rest
DELETE http://localhost:1312/series/6402217e362a47615b742817 HTTP/1.1
```

Réponse:

```json
{
  "message": "Le serie ne se trouve pas dans la base de donnees."
}
```

## Les sources d'inspirations et d'apprentissage

1. Pour l'utilisation de swagger auto-gen
   - Source: <https://github.com/davibaltar/example-swagger-autogen-with-router>

## Support

Pour toutes questions, vous pouvez contacter un membre de l'équipe de développement:

1. Christopher Desrosiers Mondor : desrosch@gmail.com

## Auteurs et reconnaissances

### Les membres de l'équipe

1. Christopher Desrosiers Mondor

## État du projet

Le projet à été remis pour évaluation pour le projet final combiné entre Services Web et Développement d'applications de bureau dans le cadre d'un AEC en développement de logiciels.
