class IAdministradorRepository {
  constructor() {
    if (new.target === IAdministradorRepository) {
      throw new Error(
        "A interface IAdministradorRepository não pode ser instanciada."
      );
    }
  }

  create = async (administrador) => {
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

module.exports = IAdministradorRepository;
