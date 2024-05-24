const { presencaFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let presencas = await presencaFacade.getAll();
  res.status(200).json(presencas);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let presenca = await presencaFacade.get(codigo);
  res.json(presenca);
};

module.exports.create = async (req, res) => {
  let presenca = req.body;
  await presencaFacade.create(presenca);
  res.json(presenca);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let presenca = await presencaFacade.update(codigo, novosValores);
  res.json(presenca);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await presencaFacade.delete(codigo);
  res.status(200).json({ status: "Presença deletada!" });
};
