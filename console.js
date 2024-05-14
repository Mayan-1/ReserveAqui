const InstituicaoRepositoryMySql = require("./repository/instituicao-repository-mysql");
const AdministradorRepositoryMySql = require("./repository/administrador-repository-mysql");
const AlunoRepositoryMySql = require("./repository/aluno-repository-mysql");
const FaltaRepositoryMySql = require("./repository/falta-repository-mysql");
const MaterialRepositoryMySql = require("./repository/material-repository-mysql");
const PresencaRepositoryMySql = require("./repository/presenca-repository-mysql");
const ProfessorRepositoryMySql = require("./repository/professor-repository-mysql");
const ReservaRepositoryMySql = require("./repository/reserva-repository-mysql");
const SalaRepositoryMySql = require("./repository/sala-repository-mysql");

let instituicao = new InstituicaoRepositoryMySql();
let administrador = new AdministradorRepositoryMySql();
let aluno = new AlunoRepositoryMySql();
let falta = new FaltaRepositoryMySql();
let material = new MaterialRepositoryMySql();
let presenca = new PresencaRepositoryMySql();
let professor = new ProfessorRepositoryMySql();
let reserva = new ReservaRepositoryMySql();
let sala = new SalaRepositoryMySql();

//instituicao.create({ nome: "Senai", endereco: "Rua A, 78" });

// administrador.create({
//   nome: "Mayan",
//   email: "mayan@gmail.com",
//   senha: "123456",
//   codigo_instituicao_fk: 1,
// });

// aluno.create({
//   nome: "João",
//   email: "joao@aluno.com",
//   senha: "12345678",
//   serie: "3º ano",
//   nascimento: "01/01/2001",
//   matricula: 1589,
//   codigo_instituicao_fk: 1,
// });

// professor.create({
//   nome: "Pedro",
//   email: "pedro@professor.com",
//   senha: "321",
//   matricula: 5489,
//   materia: "História",
//   codigo_instituicao_fk: 1,
// });

// falta.create({
//   quantidade: 4,
// });

// material.create({
//   nome: "Béquer",
//   quantidade: 2,
// });

// presenca.create({
//   codigo_reserva_fk: 1,
//   codigo_aluno_fk: 1
// });

// reserva.create({
//   codigo_sala_fk: 1,
//   codigo_material_fk: 1,
//   codigo_professor_fk: 1
// });

// sala.create({
//   nome: "Laboratório de química",
//   disponibilidade: 1,
// });
