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

  update = async (codigo, valoresNovos) => {
    let sala = await Sala.update({
      valoresNovos,
      where: { codigo: codigo },
    });
    return sala;
  };

  remove = async (codigo) => {
    let sala = await Sala.findOne({
      where: { codigo: codigo },
    });
    await sala.destroy();
  };
}

module.exports = SalaRepositoryMySql;
