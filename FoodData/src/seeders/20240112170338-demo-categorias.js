'use strict';

/** @type {import('sequelize-cli').Migration} */
module.exports = {
  async up (queryInterface, Sequelize) {
    await queryInterface.bulkInsert('categorias', [
      {
        nome: 'Fruits and Fruit Juices',
        createdAt: new Date(),
        updatedAt: new Date()
      },
      {
        nome: 'Vegetables and Vegetable Products',
        createdAt: new Date(),
        updatedAt: new Date()
      },
  ], {});
  },

  async down (queryInterface, Sequelize) {
    await queryInterface.bulkDelete('categorias', null, {});
  }
};
