'use strict';

/** @type {import('sequelize-cli').Migration} */
module.exports = {
  async up (queryInterface, Sequelize) {
    await queryInterface.bulkInsert('alimentos', [
    
      {
        "nome": "Abacate",
        "carboidratos": 8.5,
        "proteinas": 2,
        "lipidios": 14.6,
        "calorias": 96.4,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Abacaxi",
        "carboidratos": 11.8,
        "proteinas": 0.5,
        "lipidios": 0.1,
        "calorias": 48.4,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Açaí",
        "carboidratos": 6.2,
        "proteinas": 1.6,
        "lipidios": 12.2,
        "calorias": 58.1,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Acerola",
        "carboidratos": 7.7,
        "proteinas": 0.9,
        "lipidios": 0.2,
        "calorias": 32.5,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Banana",
        "carboidratos": 22.3,
        "proteinas": 1.2,
        "lipidios": 0.2,
        "calorias": 92.4,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Caju",
        "carboidratos": 9.2,
        "proteinas": 0.8,
        "lipidios": 0.3,
        "calorias": 40.6,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Laranja",
        "carboidratos": 11.8,
        "proteinas": 0.9,
        "lipidios": 0.1,
        "calorias": 46.4,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Maçã",
        "carboidratos": 13.8,
        "proteinas": 0.3,
        "lipidios": 0.2,
        "calorias": 56.4,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Mamão",
        "carboidratos": 10.4,
        "proteinas": 0.6,
        "lipidios": 0.1,
        "calorias": 43.3,
        "vitaminas": 0,
        createdAt: new Date(),
        updatedAt: new Date(),
      },
      {
        "nome": "Manga",
        "carboidratos": 15.4,
        "proteinas": 0.5,
        "lipidios": 0.3,
        "calorias": 64.1,
        "vitaminas": 0,
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
