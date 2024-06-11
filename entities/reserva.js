class Reserva {
  constructor(reserva) {
    this.reserva = reserva;
    this.reservado = false;
  }

  seReservado() {
    if (!this.reserva) {
      this.reservado = true;
    }

    this.reservado = false;

    return this.reserva;
  }
}
module.exports = Reserva;
