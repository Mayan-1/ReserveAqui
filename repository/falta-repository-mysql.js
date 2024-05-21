const IFaltaRepository = require("../interfaces/i_falta-repository");
const { Falta } = require("../data/dbContext");

class FaltaRepositoryMySql extends IFaltaRepository {
  constructor() {
    super();
  }

  create = async (falta) => {
    await Falta.create({
      quantidade: falta.quantidade,
    });
  };

  get = async (codigo) => {
    let falta = await Falta.findOne({
      where: { codigo: codigo },
    });

    return falta;
  };

  getAll = async () => {
    let faltas = await Falta.findAll({});
    return faltas;
  };

  update = async (codigo, valoresNovos) => {
    let falta = await Falta.update(valoresNovos, {
      where: { codigo: codigo },
    });
    return falta;
  };

  remove = async (codigo) => {
    let falta = await Falta.findOne({
      where: { codigo: codigo },
    });
    await falta.destroy();
  };
}

module.exports = FaltaRepositoryMySql;
