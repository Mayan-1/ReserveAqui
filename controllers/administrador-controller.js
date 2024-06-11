const { administradorFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let administradores = await administradorFacade.getAll();
  res.status(200).json(administradores);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let administrador = await administradorFacade.get(codigo);
  res.json(administrador);
};

module.exports.create = async (req, res) => {
  let administrador = req.body;
  await administradorFacade.create(administrador);
  res.json(administrador);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let administrador = await administradorFacade.update(codigo, novosValores);
  res.json(administrador);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await administradorFacade.delete(codigo);
  res.status(200).json({ status: "Administrador deletado!" });
};
