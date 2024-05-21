class AlunoFacade {
  constructor(alunoApplication) {
    this.alunoApplication = alunoApplication;
  }

  create = async (aluno) => {
    this.alunoApplication.create(aluno);
  };

  get = async (codigo) => {
    return await this.alunoApplication.get(codigo);
  };

  getAll = async () => {
    return await this.alunoApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.alunoApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.alunoApplication.remove(codigo);
  };
}

module.exports = AlunoFacade;
