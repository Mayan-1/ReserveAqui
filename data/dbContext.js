const dbConfig = require("../config/dbConfig");

const { Sequelize, DataTypes } = require("sequelize");
const aluno = require("./aluno");

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
const Aluno = require("./aluno")(sequelize, DataTypes);
const Falta = require("./falta")(sequelize, DataTypes);
const Material = require("./material")(sequelize, DataTypes);
const Presenca = require("./presenca")(sequelize, DataTypes);
const Professor = require("./professor")(sequelize, DataTypes);
const Reserva = require("./reserva")(sequelize, DataTypes);
const Sala = require("./sala")(sequelize, DataTypes);

sequelize
  .sync({ alter: true })
  .then(() => {
    console.log("Tabelas criadas com sucesso!");
  })
  .catch((erro) => {
    console.log("Erros: " + erro);
  });

Instituicao.hasMany(Professor, {
  foreignKey: "codigo_instituicao_fk",
});

Instituicao.hasMany(Aluno, {
  foreignKey: "codigo_instituicao_fk",
});

Instituicao.hasMany(Administrador, {
  foreignKey: "codigo_instituicao_fk",
});

Sala.hasMany(Reserva, {
  foreignKey: "codigo_sala_fk",
});

Material.hasMany(Reserva, {
  foreignKey: "codigo_material_fk",
});

Professor.hasMany(Reserva, {
  foreignKey: "codigo_professor_fk",
});

Reserva.hasMany(Presenca, {
  foreignKey: "codigo_reserva_fk",
});

Aluno.hasMany(Presenca, {
  foreignKey: "codigo_aluno_fk",
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
