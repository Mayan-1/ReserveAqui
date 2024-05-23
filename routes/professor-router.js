const express = require("express");
const professorController = require("../controllers/professor-controller");
const router = express.Router();

router.get("/", professorController.findAll);

module.exports = router;
