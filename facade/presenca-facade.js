class PresencaFacade {
  constructor(presencaApplication) {
    this.presencaApplication = presencaApplication;
  }

  create = async (presenca) => {
    this.presencaApplication.create(presenca);
  };

  get = async (codigo) => {
    return await this.presencaApplication.get(codigo);
  };

  getAll = async () => {
    return await this.presencaApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.presencaApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.presencaApplication.remove(codigo);
  };
}

module.exports = PresencaFacade;
