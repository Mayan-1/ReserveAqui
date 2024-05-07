module.exports = (sequelize, DataTypes) => {
  const Reserva = sequelize.define(
    "reserva",
    {
      codigo: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        allowNull: false,
        autoIncrement: true,
        unique: true,
      },
      codigo_sala_fk: {},

      codigo_material_fk: {},

      codigo_professor_fk: {},
    },
    { freezeTableName: true, timestamps: false }
  );

  return Presenca;
};
