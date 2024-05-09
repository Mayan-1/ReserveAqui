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
}

module.exports = MaterialRepositoryMySql;
