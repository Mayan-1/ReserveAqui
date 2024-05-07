const IPresencaRepository = require("../interfaces/i_presenca-repository");
const { Presenca } = require("../data/dbContext");

class PresencaRepositoryMySql extends IPresencaRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (material) => {};

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
}

module.exports = PresencaRepositoryMySql;
