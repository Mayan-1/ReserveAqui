const { faltaFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let faltas = await faltaFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(faltas);
};

