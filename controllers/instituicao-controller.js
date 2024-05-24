const { instituicaoFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let instituicoes = await instituicaoFacade.getAll();
  res.status(200).json(instituicoes);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let instituicao = await instituicaoFacade.get(codigo);
  res.json(instituicao);
};

module.exports.create = async (req, res) => {
  let instituicao = req.body;
  await instituicaoFacade.create(instituicao);
  res.json(instituicao);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let instituicao = await instituicaoFacade.update(codigo, novosValores);
  res.json(instituicao);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await instituicaoFacade.delete(codigo);
  res.status(200).json({ status: "Instituição deletada!" });
};
