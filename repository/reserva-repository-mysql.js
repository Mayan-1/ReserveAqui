const IReservaRepository = require("../interfaces/i_reserva-repository");
const { Reserva } = require("../data/dbContext");

class ReservaRepositoryMySql extends IReservaRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (reserva) => {};

  get = async (codigo) => {
    let reserva = await Reserva.findOne({
      where: { codigo: codigo },
    });

    return reserva;
  };

  getAll = async () => {
    let reservas = await Reserva.findAll({});
    return reservas;
  };
}

module.exports = ReservaRepositoryMySql;
