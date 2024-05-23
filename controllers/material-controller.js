const { materialFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let materiais = await materialFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(materiais);
};

