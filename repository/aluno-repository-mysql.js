const IAlunoRepository = require("../interfaces/i_aluno-repository");
const { Aluno } = require("../data/dbContext");

class AlunoRepositoryMySql extends IAlunoRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (aluno) => {};

  get = async (codigo) => {
    let aluno = await Aluno.findOne({
      where: { codigo: codigo },
    });

    return aluno;
  };

  getAll = async () => {
    let alunos = await Aluno.findAll({});
    return alunos;
  };
}

module.exports = AlunoRepositoryMySql;
