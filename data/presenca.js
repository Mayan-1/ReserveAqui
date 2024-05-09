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
      codigo_reserva_fk: {
        type: DataTypes.INTEGER,
        allowNull: false
      },

      codigo_aluno_fk: {
        type: DataTypes.INTEGER,
        allowNull: false
      },
    },
    { freezeTableName: true, timestamps: false }
  );

  return Presenca;
};
