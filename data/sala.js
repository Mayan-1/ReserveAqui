module.exports = (sequelize, DataTypes) => {
  const Sala = sequelize.define(
    "sala",
    {
      codigo: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        allowNull: false,
        autoIncrement: true,
        unique: true,
      },

      nome: {
        type: DataTypes.STRING,
        allowNull: false,
      },

      disponibilidade: {
        type: DataTypes.BOOLEAN,
        allowNull: false,
      },
    },
    { freezeTableName: true, timestamps: false }
  );

  return Sala;
};
