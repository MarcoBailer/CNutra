class Controller {
    constructor(entityService){
        this.entityService = entityService;
    }
    async getAll(req,res){
        try{
            const allEntities = await this.entityService.getAll();
            return res.status(200).json(allEntities);
        }catch(error){
            return res.status(500).json(error.message);
        }
    }
    async getById(req,res){
        const { id } = req.params;
        try{
            const entity = await this.entityService.getById(id);
            return res.status(200).json(entity);
        }catch(error){
            return res.status(500).json(error.message);
        }
    }
    async create(req,res){
        const entity = req.body;
        try{
            const createdEntity = await this.entityService.create(entity);
            return res.status(201).json(createdEntity);
        }catch(error){
            return res.status(500).json(error.message);
        }
    }
    async update(req,res){
        const { id } = req.params;
        const entity = req.body;
        try{
            const updatedEntity = await this.entityService.update(id, entity);
            return res.status(200).json(updatedEntity);
            if(!updatedEntity){
                return res.status(404).json({message: 'Not found'});
            }
        }catch(error){
            return res.status(500).json(error.message);
        }
    }
    async delete(req,res){
        const { id } = req.params;
        try{
            await this.entityService.delete(id);
            return res.status(200).json({message: 'Deleted'});
        }catch(error){
            return res.status(500).json(error.message);
        }
    }
}

module.exports = Controller;