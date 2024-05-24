const express = require("express");
const salaController = require("../controllers/sala-controller");
const router = express.Router();
const isAuth = require("../middleware/is-auth");

router.get("/", isAuth, salaController.findAll);
router.get("/:codigo", isAuth, salaController.findById);
router.post("/", isAuth, salaController.create);
router.put("/:codigo", isAuth, salaController.update);
router.delete("/:codigo", isAuth, salaController.delete);

module.exports = router;
