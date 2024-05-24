const express = require("express");
const presencaController = require("../controllers/presenca-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, presencaController.findAll);
router.get("/:codigo", isAuth, presencaController.findById);
router.post("/", isAuth, presencaController.create);
router.put("/:codigo", isAuth, presencaController.update);
router.delete("/:codigo", isAuth, presencaController.delete);

module.exports = router;
