const Reserva = require("../entities/reserva.js");

class ReservaFactory {
  constructor(reserva, sala) {
    this.reserva = reserva;
    this.sala = sala;
  }

  novaReserva(comMaterial) {
    if (comMaterial)
      return new Reserva(this.reserva, this.sala).seReservado();
    else
      return new Reserva(this.reserva, this.sala).seReservadoComMaterial();
  }
}
module.exports = ReservaFactory;
