const Reserva = require("../entities/reserva.js");

class ReservaFactory {
  constructor(reserva, sala, material) {
    this.reserva = reserva;
    this.sala = sala;
    this.material = material;
  }

  novaReserva() {
    return new Reserva(this.reserva, this.sala, this.material).seReservado();
  }
}
module.exports = ReservaFactory;
