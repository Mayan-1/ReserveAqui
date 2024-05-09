const ISalaRepository = require("../interfaces/i_sala-repository");
const { Sala } = require("../data/dbContext");

class SalaRepositoryMySql extends ISalaRepository {
  constructor() {
    super();
  }

  create = async (sala) => {
    await Sala.create({
      nome: sala.nome,
      disponibilidade: sala.disponibilidade,
    });
  };

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
