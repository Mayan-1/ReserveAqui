class PresencaApplication {
  constructor(presencaRepository) {
    this.presencaRepository = presencaRepository;
  }

  create = async (presenca) => {
    this.presencaRepository.create(presenca);
  };

  get = async (codigo) => {
    return await this.presencaRepository.get(codigo);
  };

  getAll = async () => {
    return await this.presencaRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.presencaRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.presencaRepository.remove(codigo);
  };
}

module.exports = PresencaApplication;
