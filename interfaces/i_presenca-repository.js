class IPresencaRepository {
  constructor() {
    if (new.target === IPresencaRepository) {
      throw new Error(
        "A interface IPresencaRepository não pode ser instanciada."
      );
    }
  }

  adicionarProduto = async (presenca) => {
    throw new Error("Esse método não pode ser chamado");
  };

  get = async (codigo) => {
    throw new Error("Esse método não pode ser chamado");
  };

  getAll = async () => {
    throw new Error("Esse método não pode ser chamado");
  };
}

module.exports = IPresencaRepository;
