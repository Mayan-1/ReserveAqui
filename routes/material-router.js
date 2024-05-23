const express = require("express");
const materialController = require("../controllers/material-controller");
const router = express.Router();

router.get("/", materialController.findAll);

module.exports = router;
