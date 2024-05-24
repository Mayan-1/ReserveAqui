const { faltaFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let faltas = await faltaFacade.getAll();
  res.status(200).json(faltas);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let falta = await faltaFacade.get(codigo);
  res.json(falta);
};

module.exports.create = async (req, res) => {
  let falta = req.body;
  await faltaFacade.create(falta);
  res.json(falta);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let falta = await faltaFacade.update(codigo, novosValores);
  res.json(falta);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await faltaFacade.delete(codigo);
  res.status(200).json({ status: "Falta deletada!" });
};
