const IFaltaRepository = require("../interfaces/i_falta-repository");
const { Falta } = require("../data/dbContext");

class FaltaRepositoryMySql extends IFaltaRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (falta) => {};

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
}

module.exports = FaltaRepositoryMySql;
