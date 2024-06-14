class Reserva {
  constructor(reserva, sala, material) {
    this.reserva = reserva;
    this.sala = sala;
    this.material = material;
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
