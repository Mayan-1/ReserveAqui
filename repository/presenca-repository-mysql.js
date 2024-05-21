const IPresencaRepository = require("../interfaces/i_presenca-repository");
const { Presenca } = require("../data/dbContext");
const presenca = require("../data/presenca");

class PresencaRepositoryMySql extends IPresencaRepository {
  constructor() {
    super();
  }

  create = async (presenca) => {
    await Presenca.create({
      codigo_reserva_fk: presenca.codigo_reserva_fk,
      codigo_aluno_fk: presenca.codigo_aluno_fk,
    });
  };

  get = async (codigo) => {
    let presenca = await Presenca.findOne({
      where: { codigo: codigo },
    });

    return presenca;
  };

  getAll = async () => {
    let presencas = await Presenca.findAll({});
    return presencas;
  };

  update = async (codigo, valoresNovos) => {
    let presenca = await Presenca.update(valoresNovos, {
      where: { codigo: codigo },
    });
    return presenca;
  };

  remove = async (codigo) => {
    let presenca = await Presenca.findOne({
      where: { codigo: codigo },
    });
    await presenca.destroy();
  };
}

module.exports = PresencaRepositoryMySql;
