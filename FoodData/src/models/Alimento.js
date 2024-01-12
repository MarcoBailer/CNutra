'use strict';
const {
  Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
  class Alimento extends Model {
    /**
     * Helper method for defining associations.
     * This method is not a part of Sequelize lifecycle.
     * The `models/index` file will call this method automatically.
     */
    static associate(models) {
      // define association here
    }
  }
  Alimento.init({
    nome: DataTypes.STRING,
    carboidratos: DataTypes.DOUBLE,
    proteinas: DataTypes.DOUBLE,
    lipidios: DataTypes.DOUBLE,
    calorias: DataTypes.DOUBLE,
    vitaminas: DataTypes.STRING
  }, {
    sequelize,
    modelName: 'Alimento',
    tableName: 'alimentos',
  });
  return Alimento;
};