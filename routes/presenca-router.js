const express = require("express");
const presencaController = require("../controllers/presenca-controller");
const router = express.Router();

router.get("/", presencaController.findAll);

module.exports = router;
