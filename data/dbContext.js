const dbConfig = require("../config/dbConfig");

const { Sequelize, DataTypes } = require("sequelize");

const sequelize = new Sequelize(
  dbConfig.DB,
  dbConfig.USERNAME,
  dbConfig.PASSWORD,
  {
    host: dbConfig.HOST,
    dialect: dbConfig.DIALECT,
    port: dbConfig.PORT,
  }
);

sequelize
  .authenticate()
  .then(() => {
    console.log("Conectado com sucesso!");
  })
  .catch((erro) => {
    console.log("Erro ao tentar conectar " + erro);
  });

const Instituicao = require("./instituicao")(sequelize, DataTypes);
const Administrador = require("./administrador")(sequelize, DataTypes);

sequelize
  .sync({ alter: true })
  .then(() => {
    console.log("Tabelas criadas com sucesso!");
  })
  .catch((erro) => {
    console.log("Erros: " + erro);
  });

module.exports = {
  Instituicao,
  Administrador,
  Aluno,
  Falta,
  Material,
  Presenca,
  Professor,
  Reserva,
  Sala,
};
