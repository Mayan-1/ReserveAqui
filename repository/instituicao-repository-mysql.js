const IInstituicaoRepository = require("../interfaces/i_instituicao-repository");
const { Instituicao } = require("../data/dbContext");
const { where } = require("sequelize");

class InstituicaoRepositoryMySql extends IInstituicaoRepository {
  constructor() {
    super();
  }

  create = async (instituicao) => {
    await Instituicao.create({
      nome: instituicao.nome,
      endereco: instituicao.endereco,
    });
  };

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

  update = async (codigo, valoresNovos) => {
    let instituicaoAtualizada = await Instituicao.update(valoresNovos, {
      where: { codigo: codigo },
    });
    return instituicaoAtualizada;
  };

  remove = async (codigo) => {
    let instituicao = await Instituicao.findOne({
      where: { codigo: codigo },
    });
    await instituicao.destroy();
  };
}

module.exports = InstituicaoRepositoryMySql;
