const express = require("express");
const instituicaoController = require("../controllers/instituicao-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, instituicaoController.findAll);
router.get("/:codigo", isAuth, instituicaoController.findById);
router.post("/", isAuth, instituicaoController.create);
router.put("/:codigo", isAuth, instituicaoController.update);
router.delete("/:codigo", isAuth, instituicaoController.delete);

module.exports = router;
