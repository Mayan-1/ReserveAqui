class MaterialApplication {
  constructor(materialRepository) {
    this.materialRepository = materialRepository;
  }

  create = async (material) => {
    this.materialRepository.create(material);
  };

  get = async (codigo) => {
    return await this.materialRepository.get(codigo);
  };

  getAll = async () => {
    return await this.materialRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.materialRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.materialRepository.remove(codigo);
  };
}

module.exports = MaterialApplication;
