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

  update = async (codigo, valoresNovos) => {
    return await this.instituicaoRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.instituicaoRepository.remove(codigo);
  };
}

module.exports = InstituicaoApplication;
