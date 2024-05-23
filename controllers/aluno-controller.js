const { alunoFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let alunos = await alunoFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(alunos);
};
