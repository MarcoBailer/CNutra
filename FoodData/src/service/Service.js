const database = require('../models');

class Service {
    constructor(model){
        this.model = model;
    }
    // vitaminas e uma string com as vitaminas separadas por virgula e seus valores sao double
    // exemplo: "A: 767,C: 1677.6,B1: 0.02"
    //deve ser convertido para um objetos
    // exemplo: {A: 767,C: 1677.6,B1: 0.02}
    // getAll e getById devem retornar um objeto com as vitaminas
    
    async getAll(){
        try{
            return await database[this.model].findAll();
        }catch(error){
            throw error;
        }
    }
    async getById(id){
        try{
            return await database[this.model].findOne({
                where: { id: Number(id) }
            });
        }catch(error){
            throw error;
        }
    }
    async create(entity){
        try{
            return await database[this.model].create(entity);
        }catch(error){
            throw error;
        }
    }
    async update(id, entity){
        try{
            await database[this.model].update(entity, {
                where: { id: Number(id) }
            });
            return entity;
        }catch(error){
            throw error;
        }
    }
    async delete(id){
        try{
            await database[this.model].destroy({
                where: { id: Number(id) }
            });
            return { message: 'Deleted' };
        }catch(error){
            throw error;
        }
    }
}

module.exports = Service;