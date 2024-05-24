const { alunoFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let alunos = await alunoFacade.getAll();
  res.status(200).json(alunos);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let aluno = await instituicaoFacade.get(codigo);
  res.json(aluno);
};

module.exports.create = async (req, res) => {
  let aluno = req.body;
  await alunoFacade.create(aluno);
  res.json(aluno);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let aluno = await alunoFacade.update(codigo, novosValores);
  res.json(aluno);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await alunoFacade.delete(codigo);
  res.status(200).json({ status: "Aluno deletado!" });
};
