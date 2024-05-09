const InstituicaoRepositoryMySql = require("./repository/instituicao-repository-mysql");
const AdministradorRepositoryMySql = require("./repository/administrador-repository-mysql");

let instituicao = new InstituicaoRepositoryMySql();
let administrador = new AdministradorRepositoryMySql();

instituicao.create({ nome: "Senai", endereco: "Rua A, 78" });

administrador.create({
  nome: "Mayan",
  email: "mayan@gmail.com",
  senha: "123456",
  codigo_instituicao_fk: 1,
});
