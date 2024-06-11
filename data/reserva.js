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
      data: {
        type: DataTypes.DATE,
        allowNull: false,
      },
      codigo_sala_fk: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },

      codigo_material_fk: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },

      codigo_professor_fk: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
    },
    { freezeTableName: true, timestamps: false }
  );

  return Reserva;
};
