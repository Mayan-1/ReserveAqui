const IAdministradorRepository = require("../interfaces/i_administrador-repository");
const { Administrador } = require("../data/dbContext");

class AdministradorRepositoryMySql extends IAdministradorRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (administrador) => {};

  get = async (codigo) => {
    let administrador = await Administrador.findOne({
      where: { codigo: codigo },
    });

    return administrador;
  };

  getAll = async () => {
    let administradores = await Administrador.findAll({});
    return administradores;
  };
}

module.exports = AdministradorRepositoryMySql;
