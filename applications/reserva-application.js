class ReservaApplication {
  constructor(reservaRepository) {
    this.reservaRepository = reservaRepository;
  }

  create = async (reserva) => {
    this.reservaRepository.create(reserva);
  };

  get = async (codigo) => {
    return await this.reservaRepository.get(codigo);
  };

  getAll = async () => {
    return await this.reservaRepository.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.reservaRepository.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.reservaRepository.remove(codigo);
  };

  buscarPorData = async (data) => {
    return await this.reservaRepository.buscarPorData(data);
  };
}

module.exports = ReservaApplication;
