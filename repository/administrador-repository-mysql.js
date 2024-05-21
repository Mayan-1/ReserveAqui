const IAdministradorRepository = require("../interfaces/i_administrador-repository");
const { Administrador } = require("../data/dbContext");

class AdministradorRepositoryMySql extends IAdministradorRepository {
  constructor() {
    super();
  }

  create = async (administrador) => {
    await Administrador.create({
      nome: administrador.nome,
      email: administrador.email,
      senha: administrador.senha,
      codigo_instituicaocls_fk: administrador.codigo_instituicao_fk,
    });
  };

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

  update = async (codigo, valoresNovos) => {
    let administradorAtualizado = await Administrador.update(valoresNovos, {
      where: { codigo: codigo },
    });
    return administradorAtualizado;
  };

  remove = async (codigo) => {
    let administrador = await Administrador.findOne({
      where: { codigo: codigo },
    });
    await administrador.destroy();
  };
}

module.exports = AdministradorRepositoryMySql;
