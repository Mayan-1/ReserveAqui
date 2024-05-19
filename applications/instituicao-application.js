class InstituicaoApplication {
  constructor(instituicaoRepository) {
    this.instituicaoRepository = instituicaoRepository;
  }

  create = async (instituicao) => {
    this.instituicaoRepository.create(instituicao);
  };

  get = async (codigo) => {
    return await this.instituicaoRepository.get(codigo);
  };

  getAll = async () => {
    return await this.instituicaoRepository.getAll();
  };
}

module.exports = InstituicaoApplication;
