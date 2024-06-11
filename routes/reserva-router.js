const express = require("express");
const reservaController = require("../controllers/reserva-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, reservaController.findAll);
router.get("/:codigo", isAuth, reservaController.findById);
router.get("/:data", isAuth, reservaController.findById);
router.post("/", isAuth, reservaController.create);
router.put("/:codigo", isAuth, reservaController.update);
router.delete("/:codigo", isAuth, reservaController.delete);

module.exports = router;
