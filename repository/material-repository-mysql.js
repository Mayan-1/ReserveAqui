const IMaterialRepository = require("../interfaces/i_material-repository");
const { Material } = require("../data/dbContext");

class MaterialRepositoryMySql extends IMaterialRepository {
  constructor() {
    super();
  }

  create = async (material) => {
    await Material.create({
      nome: material.nome,
      quantidade: material.quantidade,
    });
  };

  get = async (codigo) => {
    let material = await Material.findOne({
      where: { codigo: codigo },
    });

    return material;
  };

  getAll = async () => {
    let materiais = await Material.findAll({});
    return materiais;
  };

  update = async (codigo, valoresNovos) => {
    let material = await Material.update({
      valoresNovos,
      where: { codigo: codigo },
    });
    return material;
  };

  remove = async (codigo) => {
    let material = await Material.findOne({
      where: { codigo: codigo },
    });
    await material.destroy();
  };
}

module.exports = MaterialRepositoryMySql;
