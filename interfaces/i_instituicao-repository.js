class IInstituicaoRepository {
  constructor() {
    if (new.target === IInstituicaoRepository) {
      throw new Error(
        "A interface IInstituicaoRepository não pode ser instanciada."
      );
    }
  }

  create = async (instituicao) => {
    throw new Error("Esse método não pode ser chamado");
  };

  get = async (codigo) => {
    throw new Error("Esse método não pode ser chamado");
  };

  getAll = async () => {
    throw new Error("Esse método não pode ser chamado");
  };

  update = async () => {
    throw new Error("Esse método não pode ser chamado");
  };

  remove = async () => {
    throw new Error("Esse método não pode ser chamado");
  };
}

module.exports = IInstituicaoRepository;
