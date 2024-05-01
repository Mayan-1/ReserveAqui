module.exports = (sequelize, DataTypes) => {
    const Falta = sequelize.define(
      "falta",
      {
        codigo: {
          type: DataTypes.INTEGER,
          primaryKey: true,
          allowNull: false,
          autoIncrement: true,
          unique: true,
        },
        
        quantidade: {
          type: DataTypes.INTEGER,
          allowNull: false,
        },
      },
      { freezeTableName: true, timestamps: false }
    );
  
    return Falta;
  };