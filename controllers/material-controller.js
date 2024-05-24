const { materialFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let materiais = await materialFacade.getAll();
  res.status(200).json(materiais);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let material = await materialFacade.get(codigo);
  res.json(material);
};

module.exports.create = async (req, res) => {
  let material = req.body;
  await materialFacade.create(material);
  res.json(material);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let material = await materialFacade.update(codigo, novosValores);
  res.json(material);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await materialFacade.delete(codigo);
  res.status(200).json({ status: "Material deletado!" });
};
