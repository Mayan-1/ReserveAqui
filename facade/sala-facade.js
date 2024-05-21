class SalaFacade {
  constructor(salaApplication) {
    this.salaApplication = salaApplication;
  }

  create = async (sala) => {
    this.salaApplication.create(sala);
  };

  get = async (codigo) => {
    return await this.salaApplication.get(codigo);
  };

  getAll = async () => {
    return await this.salaApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.salaApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.salaApplication.remove(codigo);
  };
}

module.exports = SalaFacade;
