const { presencaFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let presencas = await presencaFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(presencas);
};

