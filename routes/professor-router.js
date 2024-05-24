const express = require("express");
const professorController = require("../controllers/professor-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, professorController.findAll);
router.get("/:codigo", isAuth, professorController.findById);
router.post("/", isAuth, professorController.create);
router.put("/:codigo", isAuth, professorController.update);
router.delete("/:codigo", isAuth, professorController.delete);

module.exports = router;
