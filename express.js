const express = require("express");

const InstituicaoRepositoryMySql = require("./repository/instituicao-repository-mysql");
const InstituicaoApplication = require("./applications/instituicao-application");
const InstituicaoFacade = require("./facade/instituicao-facade");

const AdministradorRepositoryMySql = require("./repository/administrador-repository-mysql");
const AdministradorApplication = require("./applications/administrador-application");
const AdministradorFacade = require("./facade/administrador-facade");

const AlunoRepositoryMySql = require("./repository/aluno-repository-mysql");
const AlunoApplication = require("./applications/aluno-application");
const AlunoFacade = require("./facade/aluno-facade");

const FaltaRepositoryMySql = require("./repository/falta-repository-mysql");
const FaltaApplication = require("./applications/falta-application");
const FaltaFacade = require("./facade/falta-facade");

const MaterialRepositoryMySql = require("./repository/material-repository-mysql");
const MaterialApplication = require("./applications/material-application");
const MaterialFacade = require("./facade/material-facade");

const PresencaRepositoryMySql = require("./repository/presenca-repository-mysql");
const PresencaApplication = require("./applications/presenca-application");
const PresencaFacade = require("./facade/presenca-facade");

const ProfessorRepositoryMySql = require("./repository/professor-repository-mysql");
const ProfessorApplication = require("./applications/professor-application");
const ProfessorFacade = require("./facade/professor-facade");

const ReservaRepositoryMySql = require("./repository/reserva-repository-mysql");
const ReservaApplication = require("./applications/reserva-application");
const ReservaFacade = require("./facade/reserva-facade");

const SalaRepositoryMySql = require("./repository/sala-repository-mysql");
const SalaApplication = require("./applications/sala-application");
const SalaFacade = require("./facade/sala-facade");

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

const app = express();
const port = 3000;

app.use(express.json());

// ===========================INSTITUIÇÃO===========================
// get
app.get("/api/GetInstituicao/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let instituicao = await instituicaoFacade.get(codigo);
    res.json(instituicao);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

// getAll instituicao
app.get("/api/GetInstituicoes", async (req, res) => {
  let instituicao = await instituicaoFacade.getAll();
  res.json(instituicao);
});

// createInsituicao
app.post("/api/CreateInstituicao", async (req, res) => {
  let request = {
    nome: req.body.nome,
    endereco: req.body.endereco,
  };

  const instituicao = await instituicaoFacade.create(request);
  res.status(201).send(instituicao);
});

// update instituicao
app.put("/api/UpdateInstituicao/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    nome: req.body.nome,
    endereco: req.body.endereco,
  };

  const instituicaoAtualizada = await instituicaoFacade.update(
    codigo,
    novosValores
  );
  res.status(200).send(instituicaoAtualizada);
});

// delete instituicao
app.delete("/api/RemoveInstituicao/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await instituicaoFacade.remove(codigo);
  res.status(200).send({ message: "Insituicao removida com sucesso" });
});

//============================================================================================================

// ADMINISTRADOR
app.get("/api/GetAdministrador/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let administrador = await administradorFacade.get(codigo);
    res.json(administrador);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetAdministradores", async (req, res) => {
  let administrador = await instituicaoFacade.getAll();
  res.json(administrador);
});

app.post("/api/CreateAdministrador", async (req, res) => {
  let request = {
    nome: req.body.nome,
    email: req.body.email,
    senha: req.body.senha,
    codigo_instituicaocls_fk: administrador.codigo_instituicao_fk,
  };

  const administrador = await administradorFacade.create(request);
  res.status(201).send(administrador);
});

app.put("/api/UpdateAdministrador/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    nome: req.body.nome,
    email: req.body.email,
    senha: req.body.senha,
    codigo_instituicaocls_fk: administrador.codigo_instituicao_fk,
  };

  const administradorAtualizado = await administradorFacade.update(
    codigo,
    novosValores
  );
  res.status(200).send(administradorAtualizado);
});

app.delete("/api/RemoveAdministrador/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await administradorFacade.remove(codigo);
  res.status(200).send({ message: "Administrador removido com sucesso" });
});

//============================================================================================================

// ALUNO
app.get("/api/GetAluno/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let aluno = await alunoFacade.get(codigo);
    res.json(aluno);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetAlunos", async (req, res) => {
  let aluno = await instituicaoFacade.getAll();
  res.json(aluno);
});

app.post("/api/CreateAluno", async (req, res) => {
  let request = {
    nome: aluno.nome,
    email: aluno.email,
    senha: aluno.senha,
    serie: aluno.senha,
    nascimento: aluno.nascimento,
    matricula: aluno.matricula,
    codigo_instituicao_fk: aluno.codigo_instituicao_fk,
  };

  const aluno = await alunoFacade.create(request);
  res.status(201).send(aluno);
});

app.put("/api/UpdateAluno/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    nome: aluno.nome,
    email: aluno.email,
    senha: aluno.senha,
    serie: aluno.senha,
    nascimento: aluno.nascimento,
    matricula: aluno.matricula,
    codigo_instituicao_fk: aluno.codigo_instituicao_fk,
  };

  const alunoAtualizado = await alunoFacade.update(codigo, novosValores);
  res.status(200).send(alunoAtualizado);
});

app.delete("/api/RemoveAluno/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await alunoFacade.remove(codigo);
  res.status(200).send({ message: "Aluno removido com sucesso" });
});

//============================================================================================================

// FALTA
app.get("/api/GetFalta/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let falta = await faltaFacade.get(codigo);
    res.json(falta);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetFaltas", async (req, res) => {
  let falta = await faltaFacade.getAll();
  res.json(falta);
});

app.post("/api/CreateFalta", async (req, res) => {
  let request = {
    quantidade: falta.quantidade,
  };

  const falta = await faltaFacade.create(request);
  res.status(201).send(falta);
});

app.put("/api/UpdateFalta/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    quantidade: falta.quantidade,
  };

  const faltaAtualizada = await faltaFacade.update(codigo, novosValores);
  res.status(200).send(alunoAtualizado);
});

app.delete("/api/RemoveFalta/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await faltaFacade.remove(codigo);
  res.status(200).send({ message: "Falta removida com sucesso" });
});

//============================================================================================================

// MATERIAL
app.get("/api/GetMaterial/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let material = await faltaFacade.get(codigo);
    res.json(material);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetMateriais", async (req, res) => {
  let material = await faltaFacade.getAll();
  res.json(material);
});

app.post("/api/CreateMaterial", async (req, res) => {
  let request = {
    nome: material.nome,
    quantidade: material.quantidade,
  };

  const material = await materialFacade.create(request);
  res.status(201).send(material);
});

app.put("/api/UpdateMaterial/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    nome: material.nome,
    quantidade: material.quantidade,
  };

  const materialAtualizado = await materialFacade.update(codigo, novosValores);
  res.status(200).send(materialAtualizado);
});

app.delete("/api/RemoveMaterial/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await materialFacade.remove(codigo);
  res.status(200).send({ message: "Material removido com sucesso" });
});

//============================================================================================================

// PRESENCA
app.get("/api/GetPresenca/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let presenca = await faltaFacade.get(codigo);
    res.json(presenca);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetPresencas", async (req, res) => {
  let presenca = await faltaFacade.getAll();
  res.json(presenca);
});

app.post("/api/CreatePresenca", async (req, res) => {
  let request = {
    codigo_reserva_fk: presenca.codigo_reserva_fk,
    codigo_aluno_fk: presenca.codigo_aluno_fk,
  };

  const presenca = await presencaFacade.create(request);
  res.status(201).send(presenca);
});

app.put("/api/UpdatePresenca/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    codigo_reserva_fk: presenca.codigo_reserva_fk,
    codigo_aluno_fk: presenca.codigo_aluno_fk,
  };

  const presencaAtualizada = await presencaFacade.update(codigo, novosValores);
  res.status(200).send(presencaAtualizada);
});

app.delete("/api/RemovePresenca/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await presencaFacade.remove(codigo);
  res.status(200).send({ message: "Presença removida com sucesso" });
});

//============================================================================================================

// PROFESSOR
app.get("/api/GetProfessor/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let professor = await professorFacade.get(codigo);
    res.json(professor);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetProfessores", async (req, res) => {
  let professor = await professorFacade.getAll();
  res.json(professor);
});

app.post("/api/CreateProfessor", async (req, res) => {
  let request = {
    nome: professor.nome,
    email: professor.email,
    senha: professor.senha,
    matricula: professor.matricula,
    materia: professor.materia,
    codigo_instituicao_fk: professor.codigo_instituicao_fk,
  };

  const professor = await professorFacade.create(request);
  res.status(201).send(professor);
});

app.put("/api/UpdateReserva/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    nome: professor.nome,
    email: professor.email,
    senha: professor.senha,
    matricula: professor.matricula,
    materia: professor.materia,
    codigo_instituicao_fk: professor.codigo_instituicao_fk,
  };

  const professorAtualizada = await professorFacade.update(
    codigo,
    novosValores
  );
  res.status(200).send(professorAtualizada);
});

app.delete("/api/RemoveProfessor/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await professorFacade.remove(codigo);
  res.status(200).send({ message: "Professor removido com sucesso" });
});

//============================================================================================================

// RESERVA
app.get("/api/GetReserva/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let reserva = await reservaFacade.get(codigo);
    res.json(reserva);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetReserva", async (req, res) => {
  let reserva = await reservaFacade.getAll();
  res.json(reserva);
});

app.post("/api/CreateReserva", async (req, res) => {
  let request = {
    codigo_sala_fk: reserva.codigo_sala_fk,
    codigo_material_fk: reserva.codigo_material_fk,
    codigo_professor_fk: reserva.codigo_professor_fk,
  };

  const reserva = await reservaFacade.create(request);
  res.status(201).send(reserva);
});

app.put("/api/UpdateReserva/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    codigo_sala_fk: reserva.codigo_sala_fk,
    codigo_material_fk: reserva.codigo_material_fk,
    codigo_professor_fk: reserva.codigo_professor_fk,
  };

  const reservaAtualizada = await reservaFacade.update(codigo, novosValores);
  res.status(200).send(reservaAtualizada);
});

app.delete("/api/RemoveReserva/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await reservaFacade.remove(codigo);
  res.status(200).send({ message: "Reserva removida com sucesso" });
});

//============================================================================================================

// SALA
app.get("/api/GetSala/:codigo", async (req, res) => {
  try {
    const codigo = req.params.codigo;
    let sala = await salaFacade.get(codigo);
    res.json(sala);
  } catch (error) {
    res.status(500).send({ error: error.message });
  }
});

app.get("/api/GetSala", async (req, res) => {
  let sala = await salaFacade.getAll();
  res.json(sala);
});

app.post("/api/CreateSala", async (req, res) => {
  let request = {
    nome: sala.nome,
    disponibilidade: sala.disponibilidade,
  };

  const sala = await salaFacade.create(request);
  res.status(201).send(sala);
});

app.put("/api/UpdateSala/:codigo", async (req, res) => {
  const codigo = req.params.codigo;
  const novosValores = {
    nome: sala.nome,
    disponibilidade: sala.disponibilidade,
  };

  const salaAtualizada = await salaFacade.update(codigo, novosValores);
  res.status(200).send(salaAtualizada);
});

app.delete("/api/RemoveSala/:codigo", async (req, res) => {
  const codigo = req.params.codigo;

  await salaFacade.remove(codigo);
  res.status(200).send({ message: "Sala removida com sucesso" });
});

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});
