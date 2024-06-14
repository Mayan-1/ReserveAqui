const ReservaFactory = require("../factories/reservaFactory");

class ReservaApplication {
  constructor(reservaRepository, salaRepository) {
    this.reservaRepository = reservaRepository;
    this.salaRepository = salaRepository;
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

  novaReserva = async (data) => {
    let reservaDb = await this.reservaRepository.buscarPorData(
      data.dataReserva
    );
    let salaDb = await this.salaRepository.get(data.codigo_sala_fk);
    let factory = new ReservaFactory(reservaDb, salaDb);
    let reserva = factory.novaReserva();
    return reserva;
  };
}

module.exports = ReservaApplication;
