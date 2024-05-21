class ProfessorFacade {
  constructor(professorApplication) {
    this.professorApplication = professorApplication;
  }

  create = async (professor) => {
    this.professorApplication.create(professor);
  };

  get = async (codigo) => {
    return await this.professorApplication.get(codigo);
  };

  getAll = async () => {
    return await this.professorApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.professorApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.professorApplication.remove(codigo);
  };
}

module.exports = ProfessorFacade;
