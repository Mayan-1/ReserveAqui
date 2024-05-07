const IProfessorRepository = require("../interfaces/i_professor-repository");
const { Professor } = require("../data/dbContext");

class ProfessorRepositoryMySql extends IProfessorRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (professor) => {};

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
}

module.exports = ProfessorRepositoryMySql;
