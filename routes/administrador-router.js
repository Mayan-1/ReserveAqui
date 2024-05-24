const express = require("express");
const administradorController = require("../controllers/administrador-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, administradorController.findAll);

module.exports = router;
