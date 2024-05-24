const express = require("express");

const instituicaoRouter = require("./routes/instituicao-router");
const administradorRouter = require("./routes/administrador-router");
const alunoRouter = require("./routes/aluno-router");
const faltaRouter = require("./routes/falta-router");
const materialRouter = require("./routes/material-router");
const presencaRouter = require("./routes/presenca-router");
const professorRouter = require("./routes/professor-router");
const reservaRouter = require("./routes/reserva-router");
const salaRouter = require("./routes/sala-router");
const routerAuth = require("./routes/auth_router");

const app = express();
const port = 3000;

app.use(express.json());

app.use("/api/instituicao", instituicaoRouter);
app.use("/api/administrador", administradorRouter);
app.use("/api/aluno", alunoRouter);
app.use("/api/falta", faltaRouter);
app.use("/api/material", materialRouter);
app.use("/api/presenca", presencaRouter);
app.use("/api/professor", professorRouter);
app.use("/api/reserva", reservaRouter);
app.use("/api/sala", salaRouter);
app.use("/api/auth", routerAuth);

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});
