const ReservaFacade = require("./facade/reserva-facade.js");

class ReservaFactory {
  constructor(reserva) {
    this.reserva = reserva;
  }

  novaReserva(reserva) {
    const reservaFacade = new ReservaFacade();
    if (this.reserva.seReservado()) {
      reservaFacade.create(reserva);
    } else {
      console.log("Já existe agendamento para essa data!");
    }
  }
}
module.exports = ReservaFactory;
