class InstituicaoFacade {
    constructor(instituicaoApplication) {
      this.instituicaoApplication = instituicaoApplication;
    }
  
    create = async (instituicao) => {
        this.instituicaoApplication.create(instituicao);
    };
  
    get = async (codigo) => {
      return await this.instituicaoApplication.get(codigo);
    };
  
    getAll = async () => {
      return await this.instituicaoApplication.getAll();
    };
  }
  
  module.exports = InstituicaoFacade;
  