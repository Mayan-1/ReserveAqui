class AlunoApplication {
  constructor(alunoRepository) {
    this.alunoRepository = alunoRepository;
  }

  create = async (aluno) => {
    this.alunoRepository.create(aluno);
  };

  get = async (codigo) => {
    return await this.alunoRepository.get(codigo);
  };

  getAll = async () => {
    return await this.alunoRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.alunoRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.alunoRepository.remove(codigo);
  };
}

module.exports = AlunoApplication;
