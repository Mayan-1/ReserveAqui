const IAlunoRepository = require("../interfaces/i_aluno-repository");
const { Aluno } = require("../data/dbContext");

class AlunoRepositoryMySql extends IAlunoRepository {
  constructor() {
    super();
  }

  create = async (aluno) => {
    await Aluno.create({
      nome: aluno.nome,
      email: aluno.email,
      senha: aluno.senha,
      serie: aluno.senha,
      nascimento: aluno.nascimento,
      matricula: aluno.matricula,
      codigo_instituicao_fk: aluno.codigo_instituicao_fk,
    });
  };

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

  update = async (codigo, valoresNovos) => {
    let aluno = await Aluno.update({
      valoresNovos,
      where: { codigo: codigo },
    });
    return aluno;
  };

  remove = async (codigo) => {
    let aluno = await Aluno.findOne({
      where: { codigo: codigo },
    });
    await aluno.destroy();
  };
}

module.exports = AlunoRepositoryMySql;
