class ISalaRepository {
  constructor() {
    if (new.target === ISalaRepository) {
      throw new Error("A interface ISalaRepository não pode ser instanciada.");
    }
  }

  adicionarProduto = async (sala) => {
    throw new Error("Esse método não pode ser chamado");
  };

  get = async (codigo) => {
    throw new Error("Esse método não pode ser chamado");
  };

  getAll = async () => {
    throw new Error("Esse método não pode ser chamado");
  };
}

module.exports = ISalaRepository;
