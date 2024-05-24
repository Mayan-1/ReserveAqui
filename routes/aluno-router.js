const express = require("express");
const alunoController = require("../controllers/aluno-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, alunoController.findAll);
router.get("/:codigo", isAuth, alunoController.findById);
router.post("/", isAuth, alunoController.create);
router.put("/:codigo", isAuth, alunoController.update);
router.delete("/:codigo", isAuth, alunoController.delete);

module.exports = router;
