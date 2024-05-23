const { professorFacade } = require ("../dependecy/injection");

module.exports.findAll = async (req, res) => {
    let professores = await proffessorFacade.getAll();
    console.log("chegou aqui");
    res.status(200).json(professores);
};

