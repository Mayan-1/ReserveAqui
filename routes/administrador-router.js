const express = require("express");
const administradorController = require("../controllers/administrador-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, administradorController.findAll);
router.get("/:codigo", isAuth, administradorController.findById);
router.post("/", isAuth, administradorController.create);
router.put("/:codigo", isAuth, administradorController.update);
router.delete("/:codigo", isAuth, administradorController.delete);

module.exports = router;
