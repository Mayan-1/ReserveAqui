const IProfessorRepository = require("../interfaces/i_professor-repository");
const { Professor } = require("../data/dbContext");

class ProfessorRepositoryMySql extends IProfessorRepository {
  constructor() {
    super();
  }

  create = async (professor) => {
    await Professor.create({
      nome: professor.nome,
      email: professor.email,
      senha: professor.senha,
      matricula: professor.matricula,
      materia: professor.materia,
      codigo_instituicao_fk: professor.codigo_instituicao_fk,
    });
  };

  get = async (codigo) => {
    let professor = await Professor.findOne({
      where: { codigo: codigo },
    });

    return professor;
  };

  getAll = async () => {
    let professores = await Professor.findAll({});
    return professores;
  };

  update = async (codigo, valoresNovos) => {
    let professor = await Professor.update(valoresNovos, {
      where: { codigo: codigo },
    });
    return professor;
  };

  remove = async (codigo) => {
    let professor = await Professor.findOne({
      where: { codigo: codigo },
    });
    await professor.destroy();
  };
}

module.exports = ProfessorRepositoryMySql;
