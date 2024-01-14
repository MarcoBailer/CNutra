'use strict';
const {
  Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
  class Alimento extends Model {
    static associate(models) {
      Alimento.belongsTo(models.Categoria, {
        foreignKey: 'categoria_id'
      })
    }
  }
  Alimento.init({
    grupo: DataTypes.STRING,
    nome: DataTypes.STRING,
    carboidratos: DataTypes.DOUBLE,
    proteinas: DataTypes.DOUBLE,
    lipidios: DataTypes.DOUBLE,
    calorias: DataTypes.DOUBLE,
    vitaminas: DataTypes.STRING,
    minerais: DataTypes.STRING,
  }, {
    sequelize,
    modelName: 'Alimento',
    tableName: 'alimentos',
  });
  return Alimento;
};