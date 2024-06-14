const { reservaFacade } = require("../dependecy/injection");

module.exports.findAll = async (req, res) => {
  let reservas = await reservaFacade.getAll();
  res.status(200).json(reservas);
};

module.exports.findById = async (req, res) => {
  let codigo = req.params.codigo;
  let reserva = await reservaFacade.get(codigo);
  res.json(reserva);
};

module.exports.create = async (req, res) => {
  let reserva = req.body;
  await reservaFacade.create(reserva);
  res.json(reserva);
};

module.exports.update = async (req, res) => {
  let codigo = req.params.codigo;
  let novosValores = req.body;
  let reserva = await reservaFacade.update(codigo, novosValores);
  res.json(reserva);
};

module.exports.delete = async (req, res) => {
  let codigo = req.params.codigo;
  await reservaFacade.delete(codigo);
  res.status(200).json({ status: "Reserva deletada!" });
};

module.exports.novaReserva = async (req, res) => {
  let body = req.body;
  let reserva = await reservaFacade.novaReserva(body);
  res.status(200).json(reserva);
};
