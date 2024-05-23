const express = require("express");
const reservaController = require("../controllers/reserva-controller");
const router = express.Router();

router.get("/", reservaController.findAll);

module.exports = router;
