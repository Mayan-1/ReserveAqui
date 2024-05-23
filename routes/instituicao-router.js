const express = require("express");
const instituicaoController = require("../controllers/instituicao-controller");
const router = express.Router();

router.get("/", instituicaoController.findAll);

module.exports = router;

