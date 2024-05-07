module.exports = (sequelize, DataTypes) => {
  const Presenca = sequelize.define(
    "presenca",
    {
      codigo: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        allowNull: false,
        autoIncrement: true,
        unique: true,
      },
      codigo_reserva_fk: {},

      codigo_aluno_fk: {},
    },
    { freezeTableName: true, timestamps: false }
  );

  return Presenca;
};
