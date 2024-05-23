const express = require("express");
const alunoController = require("../controllers/aluno-controller");
const router = express.Router();

router.get("/", alunoController.findAll);

module.exports = router;
