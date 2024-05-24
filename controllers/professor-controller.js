const { professorFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let professores = await proffessorFacade.getAll();
  res.status(200).json(professores);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let professor = await professorFacade.get(codigo);
  res.json(professor);
};

module.exports.create = async (req, res) => {
  let professor = req.body;
  await professorFacade.create(professor);
  res.json(professor);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let professor = await professorFacade.update(codigo, novosValores);
  res.json(professor);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await professorFacade.delete(codigo);
  res.status(200).json({ status: "Professor deletado!" });
};
