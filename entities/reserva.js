class Reserva {
  constructor(reserva, sala) {
    this.reserva = reserva;
    this.sala = sala;
    this.reservado = false;
  }

  seReservado() {
    if (!this.reserva) {
      this.reservado = true;
      return this;
    }

    this.reservado = false;

    return this;
  }
}
module.exports = Reserva;
