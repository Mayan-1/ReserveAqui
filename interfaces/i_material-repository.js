class IMaterialRepository {
  constructor() {
    if (new.target === IMaterialRepository) {
      throw new Error(
        "A interface IMaterialRepository não pode ser instanciada."
      );
    }
  }

  create = async (material) => {
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

module.exports = IMaterialRepository;
