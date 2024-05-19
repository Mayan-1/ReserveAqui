const express = require("express");

const InstituicaoRepositoryMySql = require("./repository/instituicao-repository-mysql");
const InstituicaoApplication = require("./applications/instituicao-application");
const InstituicaoFacade = require("./facade/instituicao-facade");

const instituicaoRepository = new InstituicaoRepositoryMySql();
const instituicaoApplication = new InstituicaoApplication(instituicaoRepository);
const instituicaoFacade = new InstituicaoFacade(instituicaoApplication);


const app = express();
const port = 3000;


app.get("/api/instituicao", async (req, res) => {
    let instituicao = await instituicaoFacade.getAll();
    res.json(instituicao);
});

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});
