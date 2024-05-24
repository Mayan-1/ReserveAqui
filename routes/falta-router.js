const express = require("express");
const faltaController = require("../controllers/falta-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, faltaController.findAll);
router.get("/:codigo", isAuth, faltaController.findById);
router.post("/", isAuth, faltaController.create);
router.put("/:codigo", isAuth, faltaController.update);
router.delete("/:codigo", isAuth, faltaController.delete);

module.exports = router;
