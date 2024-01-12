'use strict';

/** @type {import('sequelize-cli').Migration} */
module.exports = {
  async up (queryInterface, Sequelize) {
    
    await queryInterface.bulkInsert('alimentos',  [
      {
        categoria_id: 1,
        nome: "Abacate",
        carboidratos: 8.5,
        proteinas: 2,
        lipidios: 14.6,
        calorias: 96.4,
        vitaminas: "A: 81,C: 8.7,E: 2.3",
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        categoria_id: 1,
        nome: "Abacaxi",
        carboidratos: 11.8,
        proteinas: 0.5,
        lipidios: 0.1,
        calorias: 48.4,
        vitaminas: "A: 58,C: 36.4,B1: 0.08",
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        categoria_id: 1,
        nome: "Açaí",
        carboidratos: 6.2,
        proteinas: 1.6,
        lipidios: 12.2,
        calorias: 58.1,
        vitaminas: "A: 750,C: 45,E: 35",
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        categoria_id: 1,
        nome: "Acerola",
        carboidratos: 7.7,
        proteinas: 0.9,
        lipidios: 0.2,
        calorias: 32.5,
        vitaminas: "A: 767,C: 1677.6,B1: 0.02",
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        categoria_id: 1,
        nome: "Banana",
        carboidratos: 22.3,
        proteinas: 1.2,
        lipidios: 0.2,
        calorias: 92.4,
        vitaminas: "A: 64,C: 10.2,6: 0.37",
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        categoria_id: 1,
        nome: "Caju",
        carboidratos: 9.2,
        proteinas: 0.8,
        lipidios: 0.3,
        calorias: 40.6,
        vitaminas: "A: 66,C: 219.7,B1: 0.05",
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        categoria_id: 1,
        nome: "Laranja",
        carboidratos: 11.8,
        proteinas: 0.9,
        lipidios: 0.1,
        calorias: 46.4,
        vitaminas: "A: 225,C: 53.2,B1: 0.09",
        createdAt: new Date(),
        updatedAt: new Date(),
      }
    ]
  , {});
    
  },

  async down (queryInterface, Sequelize) {
    await queryInterface.bulkDelete('alimentos', null, {});
  }
};
