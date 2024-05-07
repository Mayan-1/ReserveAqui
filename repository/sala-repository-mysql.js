const ISalaRepository = require("../interfaces/i_sala-repository");
const { Sala } = require("../data/dbContext");

class SalaRepositoryMySql extends ISalaRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (sala) => {};

  get = async (codigo) => {
    let sala = await Sala.findOne({
      where: { codigo: codigo },
    });

    return sala;
  };

  getAll = async () => {
    let salas = await Sala.findAll({});
    return salas;
  };
}

module.exports = SalaRepositoryMySql;
