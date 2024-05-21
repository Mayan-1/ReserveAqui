class AdministradorApplication {
  constructor(administradorRepository) {
    this.administradorRepository = administradorRepository;
  }

  create = async (administrador) => {
    this.administradorRepository.create(administrador);
  };

  get = async (codigo) => {
    return await this.administradorRepository.get(codigo);
  };

  getAll = async () => {
    return await this.administradorRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.administradorRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.administradorRepository.remove(codigo);
  };
}

module.exports = AdministradorApplication;
