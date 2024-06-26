const IReservaRepository = require("../interfaces/i_reserva-repository");
const { Reserva } = require("../data/dbContext");
const { where } = require("sequelize");

class ReservaRepositoryMySql extends IReservaRepository {
  constructor() {
    super();
  }

  create = async (reserva) => {
    await Reserva.create({
      data_reserva: reserva.data_reserva,
      codigo_sala_fk: reserva.codigo_sala_fk,
      codigo_material_fk: reserva.codigo_material_fk,
      codigo_professor_fk: reserva.codigo_professor_fk,
    });
  };

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

  update = async (codigo, valoresNovos) => {
    let reserva = await Reserva.update(valoresNovos, {
      where: { codigo: codigo },
    });
    return reserva;
  };

  remove = async (codigo) => {
    let reserva = await Reserva.findOne({
      where: { codigo: codigo },
    });
    await reserva.destroy();
  };

  buscarPorData = async (data) => {
    let reserva = await Reserva.findOne({
      where: { data_reserva: data },
    });

    return reserva;
  };
}

module.exports = ReservaRepositoryMySql;
