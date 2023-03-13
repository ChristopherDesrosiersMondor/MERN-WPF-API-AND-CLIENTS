const mongoose = require("mongoose");

// On etablie le format du schema mondoDB pour l'objet Article
const serieSchema = new mongoose.Schema({
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
  },
  productionStatus: {
    type: String,
    required: true,
    default: 'Returning',
  },
  nombreSaisons: {
    type: Number,
    required: true,
  }
});

const Serie = mongoose.model("Serie", serieSchema);

module.exports = Serie;