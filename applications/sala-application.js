class SalaApplication {
  constructor(salaRepository) {
    this.salaRepository = salaRepository;
  }

  create = async (sala) => {
    this.salaRepository.create(sala);
  };

  get = async (codigo) => {
    return await this.salaRepository.get(codigo);
  };

  getAll = async () => {
    return await this.salaRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.salaRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.salaRepository.remove(codigo);
  };
}

module.exports = SalaApplication;
