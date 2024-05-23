const express = require("express");
const faltaController = require("../controllers/falta-controller");
const router = express.Router();

router.get("/", faltaController.findAll);

module.exports = router;
