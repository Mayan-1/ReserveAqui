const { salaFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let salas = await salaFacade.getAll();
  res.status(200).json(salas);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let sala = await salaFacade.get(codigo);
  res.json(sala);
};

module.exports.create = async (req, res) => {
  let sala = req.body;
  await salaFacade.create(sala);
  res.json(sala);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let sala = await salaFacade.update(codigo, novosValores);
  res.json(sala);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await salaFacade.delete(codigo);
  res.status(200).json({ status: "Sala deletada!" });
};
