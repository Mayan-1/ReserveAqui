class FaltaFacade {
  constructor(faltaApplication) {
    this.faltaApplication = faltaApplication;
  }

  create = async (falta) => {
    this.faltaApplication.create(falta);
  };

  get = async (codigo) => {
    return await this.faltaApplication.get(codigo);
  };

  getAll = async () => {
    return await this.faltaApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.faltaApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.faltaApplication.remove(codigo);
  };
}

module.exports = FaltaFacade;
