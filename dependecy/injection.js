//const express = require("express");

const InstituicaoRepositoryMySql = require("../repository/instituicao-repository-mysql");
const InstituicaoApplication = require("../applications/instituicao-application");
const InstituicaoFacade = require("../facade/instituicao-facade");

const AdministradorRepositoryMySql = require("../repository/administrador-repository-mysql");
const AdministradorApplication = require("../applications/administrador-application");
const AdministradorFacade = require("../facade/administrador-facade");

const AlunoRepositoryMySql = require("../repository/aluno-repository-mysql");
const AlunoApplication = require("../applications/aluno-application");
const AlunoFacade = require("../facade/aluno-facade");

const FaltaRepositoryMySql = require("../repository/falta-repository-mysql");
const FaltaApplication = require("../applications/falta-application");
const FaltaFacade = require("../facade/falta-facade");

const MaterialRepositoryMySql = require("../repository/material-repository-mysql");
const MaterialApplication = require("../applications/material-application");
const MaterialFacade = require("../facade/material-facade");

const PresencaRepositoryMySql = require("../repository/presenca-repository-mysql");
const PresencaApplication = require("../applications/presenca-application");
const PresencaFacade = require("../facade/presenca-facade");

const ProfessorRepositoryMySql = require("../repository/professor-repository-mysql");
const ProfessorApplication = require("../applications/professor-application");
const ProfessorFacade = require("../facade/professor-facade");

const ReservaRepositoryMySql = require("../repository/reserva-repository-mysql");
const ReservaApplication = require("../applications/reserva-application");
const ReservaFacade = require("../facade/reserva-facade");

const SalaRepositoryMySql = require("../repository/sala-repository-mysql");
const SalaApplication = require("../applications/sala-application");
const SalaFacade = require("../facade/sala-facade");
//const { where } = require("sequelize");

const instituicaoRepository = new InstituicaoRepositoryMySql();
const instituicaoApplication = new InstituicaoApplication(
  instituicaoRepository
);
const instituicaoFacade = new InstituicaoFacade(instituicaoApplication);

const administradorRepository = new AdministradorRepositoryMySql();
const administradorApplication = new AdministradorApplication(
  administradorRepository
);
const administradorFacade = new AdministradorFacade(administradorApplication);

const alunoRepository = new AlunoRepositoryMySql();
const alunoApplication = new AlunoApplication(alunoRepository);
const alunoFacade = new AlunoFacade(alunoApplication);

const faltaRepository = new FaltaRepositoryMySql();
const faltaApplication = new FaltaApplication(faltaRepository);
const faltaFacade = new FaltaFacade(faltaApplication);

const materialRepository = new MaterialRepositoryMySql();
const materialApplication = new MaterialApplication(materialRepository);
const materialFacade = new MaterialFacade(materialApplication);

const presencaRepository = new PresencaRepositoryMySql();
const presencaApplication = new PresencaApplication(presencaRepository);
const presencaFacade = new PresencaFacade(presencaApplication);

const professorRepository = new ProfessorRepositoryMySql();
const professorApplication = new ProfessorApplication(professorRepository);
const professorFacade = new ProfessorFacade(professorApplication);

const reservaRepository = new ReservaRepositoryMySql();
const reservaApplication = new ReservaApplication(reservaRepository);
const reservaFacade = new ReservaFacade(reservaApplication);

const salaRepository = new SalaRepositoryMySql();
const salaApplication = new SalaApplication(salaRepository);
const salaFacade = new SalaFacade(salaApplication);



module.exports = { instituicaoFacade,
administradorFacade,
alunoFacade,
faltaFacade,
materialFacade,
presencaFacade,
professorFacade,
reservaFacade,
salaFacade };