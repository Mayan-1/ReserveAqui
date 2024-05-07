const IInstituicaoRepository = require("../interfaces/i_instituicao-repository");
const { Instituicao } = require("../data/dbContext");

class InstituicaoRepositoryMySql extends IInstituicaoRepository {
  constructor() {
    super();
  }

  adicionarProduto = async (instituicao) => {};

  get = async (codigo) => {
    let instituicao = await Instituicao.findOne({
      where: { codigo: codigo },
    });

    return instituicao;
  };

  getAll = async () => {
    let instituicoes = await Instituicao.findAll({});
    return instituicoes;
  };
}

module.exports = InstituicaoRepositoryMySql;
