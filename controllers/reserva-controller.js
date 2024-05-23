const { reservaFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let reservas = await reservaFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(reservas);
};

