const express = require('express');
const alimentos = require('./AlimentosRoute.js');

module.exports = app => {
    app.use(
        express.json(), 
        alimentos,
    );
};