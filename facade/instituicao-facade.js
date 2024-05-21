class InstituicaoFacade {
  constructor(instituicaoApplication) {
    this.instituicaoApplication = instituicaoApplication;
  }

  create = async (instituicao) => {
    this.instituicaoApplication.create(instituicao);
  };

  get = async (codigo) => {
    return await this.instituicaoApplication.get(codigo);
  };

  getAll = async () => {
    return await this.instituicaoApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.instituicaoApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.instituicaoApplication.remove(codigo);
  };
}

module.exports = InstituicaoFacade;
