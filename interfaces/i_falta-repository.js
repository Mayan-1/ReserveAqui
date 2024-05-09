class IFaltaRepository {
  constructor() {
    if (new.target === IFaltaRepository) {
      throw new Error("A interface IFaltaRepository não pode ser instanciada.");
    }
  }

  create = async (falta) => {
    throw new Error("Esse método não pode ser chamado");
  };

  get = async (codigo) => {
    throw new Error("Esse método não pode ser chamado");
  };

  getAll = async () => {
    throw new Error("Esse método não pode ser chamado");
  };
}

module.exports = IFaltaRepository;
