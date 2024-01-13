//servicos com metodos responsaveis por fazer a comunicacao com o banco de dados

const database = require('../models');
const Vitaminas = require('../models/otherObjects/Vitaminas.js');
class Service {
    constructor(model){
        this.model = model;
    }
    async getAllService(){
        try{
            const entities = await database[this.model].findAll({
            });
            const entityList = entities.map(entity => {
                if(entity && entity.vitaminas){
                    entity.vitaminas = Vitaminas.parseVitaminasString(entity.vitaminas);
                }
                return entity;
            });
            return entityList;
        }catch(error){
            throw error;
        }
    }
    async getByIdService(id) {
        try {
            const entity = await database[this.model].findOne({
                where: { id: Number(id) },
            });
    
            if (entity && entity.vitaminas) {
                entity.vitaminas = Vitaminas.parseVitaminasString(entity.vitaminas);
            }
    
            return entity;
        } catch (error) {
            throw error;
        }
    }
    async createService(entity){
        try{
            return await database[this.model].create(entity);
        }catch(error){
            throw error;
        }
    }
    //recebe um array de entidades
    async createManyService(entities){
        try{
            return await database[this.model].bulkCreate(entities);
        }catch(error){
            throw error;
        }
    }
    async updateService(id, entity){
        try{
            const updatedEntity = await database[this.model].update(entity, {
                where: { id: Number(id) }
            });
            if(updatedEntity[0] === 0){
                return false;
            }
            return entity;
        }catch(error){
            throw error;
        }
    }
    async deleteService(id){
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