const mongoose = require("mongoose");

// On etablie le format du schema mondoDB pour l'objet Article
const filmSchema = new mongoose.Schema({
  titre: {
    type: String,
    required: true,
  },
  synopsis: {
    type: String,
    required: true,
  },
  annee: {
    type: String,
    required: true,
  },
  duree: {
    type: String,
    required: true,
  },
  posterImage: {
    type: String,
    required: true,
  }
});

const Film = mongoose.model("Film", filmSchema);

module.exports = Film;