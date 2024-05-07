class IReservaRepository {
  constructor() {
    if (new.target === IReservaRepository) {
      throw new Error(
        "A interface IReservaRepository não pode ser instanciada."
      );
    }
  }

  adicionarProduto = async (reserva) => {
    throw new Error("Esse método não pode ser chamado");
  };

  get = async (codigo) => {
    throw new Error("Esse método não pode ser chamado");
  };

  getAll = async () => {
    throw new Error("Esse método não pode ser chamado");
  };
}

module.exports = IReservaRepository;
