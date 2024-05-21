class FaltaApplication {
  constructor(faltaRepository) {
    this.faltaRepository = faltaRepository;
  }

  create = async (falta) => {
    this.faltaRepository.create(falta);
  };

  get = async (codigo) => {
    return await this.faltaRepository.get(codigo);
  };

  getAll = async () => {
    return await this.faltaRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.faltaRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.faltaRepository.remove(codigo);
  };
}

module.exports = FaltaApplication;
