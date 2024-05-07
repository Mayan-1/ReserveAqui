const { timeStamp } = require("console");
const { type } = require("os");
const { DataTypes } = require("sequelize");

module.exports = (sequelize, DataTypes) => {
    const Professor = sequelize.define(
        "professor",
        {
            codigo:{
                type: DataTypes.INTEGER,
                primaryKey: true,
                alowNull: false,
                autoIncrement: true,
                unique: true,
            },
            nome:{
                type: DataTypes.STRING,
                alowNull: false,
            },
            email:{
                type: DataTypes.STRING,
                alowNull: false,
            },
            senha:{
                type: DataTypes.STRING,
                alowNull: false
            },
            serie:{
                type: DataTypes.STRING,
                alowNull: false,
            },
            nascimento:{
                type: DataTypes.TIMESTAMP,
                alowNull: false
            },
            matricula:{
                type: DataTypes.INTEGER,
                alowNull: false
            },
            codigo_instituicao_fk:{
            }
        },
        { freezeTableName: true, timeStamps: false }
    );
    return Professor;
}