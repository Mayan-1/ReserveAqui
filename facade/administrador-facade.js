class AdministradorFacade {
  constructor(administradorApplication) {
    this.administradorApplication = administradorApplication;
  }

  create = async (administrador) => {
    this.administradorApplication.create(administrador);
  };

  get = async (codigo) => {
    return await this.administradorApplication.get(codigo);
  };

  getAll = async () => {
    return await this.administradorApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.administradorApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.administradorApplication.remove(codigo);
  };
}

module.exports = AdministradorFacade;
