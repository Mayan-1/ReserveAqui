const { instituicaoFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let instituicoes = await instituicaoFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(instituicoes);
};

