const { timeStamp } = require("console");
const { type } = require("os");
const { DataTypes } = require("sequelize");

module.exports = (sequelize, DataTypes) => {
  const Instituicao = sequelize.define(
    "instituicao",
    {
      codigo: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        alowNull: false,
        autoIncrement: true,
        unique: true,
      },
      nome: {
        type: DataTypes.STRING,
        alowNull: false,
      },
      endereco: {
        type: DataTypes.STRING,
        alowNull: false,
      },
    },
    { freezeTableName: true, timestamps: false }
  );
  return Instituicao;
};
