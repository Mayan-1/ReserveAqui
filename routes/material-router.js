const express = require("express");
const materialController = require("../controllers/material-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, materialController.findAll);
router.get("/:codigo", isAuth, materialController.findById);
router.post("/", isAuth, materialController.create);
router.put("/:codigo", isAuth, materialController.update);
router.delete("/:codigo", isAuth, materialController.delete);

module.exports = router;
