const { salaFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let salas = await salaFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(salas);
};

