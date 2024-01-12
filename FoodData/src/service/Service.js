const database = require('../models');

class Service {
    constructor(model){
        this.model = model;
    }
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