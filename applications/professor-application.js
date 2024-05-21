class ProfessorApplication {
  constructor(professorRepository) {
    this.professorRepository = professorRepository;
  }

  create = async (professor) => {
    this.professorRepository.create(professor);
  };

  get = async (codigo) => {
    return await this.professorRepository.get(codigo);
  };

  getAll = async () => {
    return await this.professorRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.professorRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.professorRepository.remove(codigo);
  };
}

module.exports = ProfessorApplication;
