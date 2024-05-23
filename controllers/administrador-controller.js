const { administradorFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let administradores = await administradorFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(administradores);
};
