class MaterialFacade {
  constructor(materialApplication) {
    this.materialApplication = materialApplication;
  }

  create = async (material) => {
    this.materialApplication.create(material);
  };

  get = async (codigo) => {
    return await this.materialApplication.get(codigo);
  };

  getAll = async () => {
    return await this.materialApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.materialApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.materialApplication.remove(codigo);
  };
}

module.exports = MaterialFacade;
