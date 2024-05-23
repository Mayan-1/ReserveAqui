const express = require("express");
const administradorController = require("../controllers/administrador-controller");
const router = express.Router();

router.get("/", administradorController.findAll);

module.exports = router;
