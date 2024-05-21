class ReservaFacade {
  constructor(reservaApplication) {
    this.reservaApplication = reservaApplication;
  }

  create = async (reserva) => {
    this.reservaApplication.create(reserva);
  };

  get = async (codigo) => {
    return await this.reservaApplication.get(codigo);
  };

  getAll = async () => {
    return await this.reservaApplication.getAll();
  };

  update = async (codigo, valoresNovos) => {
    return await this.reservaApplication.update(codigo, valoresNovos);
  };

  remove = async (codigo) => {
    return await this.reservaApplication.remove(codigo);
  };
}

module.exports = ReservaFacade;
