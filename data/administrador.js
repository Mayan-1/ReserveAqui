const { timeStamp } = require("console");
const { type } = require("os");
const { DataTypes } = require("sequelize");

module.exports = (sequelize, DataTypes) => {
  const Administrador = sequelize.define(
    "administrador",
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
      email: {
        type: DataTypes.STRING,
        alowNull: false,
      },
      senha: {
        type: DataTypes.STRING,
        alowNull: false,
      },
      codigo_instituicao_fk: {
        type: DataTypes.INTEGER,
        alowNull: false,
      },
    },
    { freezeTableName: true, timestamps: false }
  );
  return Administrador;
};
    
