class IAlunoRepository {
  constructor() {
    if (new.target === IAlunoRepository) {
      throw new Error("A interface IAlunoRepository não pode ser instanciada.");
    }
  }

  create = async (aluno) => {
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

module.exports = IAlunoRepository;
