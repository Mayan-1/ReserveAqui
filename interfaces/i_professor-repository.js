class IProfessorRepository {
  constructor() {
    if (new.target === IProfessorRepository) {
      throw new Error(
        "A interface IProfessorRepository não pode ser instanciada."
      );
    }
  }

  create = async (professor) => {
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

module.exports = IProfessorRepository;
