class IReservaRepository {
  constructor() {
    if (new.target === IReservaRepository) {
      throw new Error(
        "A interface IReservaRepository não pode ser instanciada."
      );
    }
  }

  create = async (reserva) => {
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

  buscarPorData = async (data) => {
    throw new Error("Esse método não pode ser chamado")
  };
}

module.exports = IReservaRepository;
