const express = require("express");
const salaController = require("../controllers/sala-controller");
const router = express.Router();

router.get("/", salaController.findAll);

module.exports = router;
