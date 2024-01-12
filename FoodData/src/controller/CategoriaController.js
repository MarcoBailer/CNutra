const Controller = require('./Controller.js');
const CategoriaService = require('../service/CategoriaService.js');

const cetegoriaService = new CategoriaService();

class CategoriaController extends Controller{
    constructor(){
        super(cetegoriaService);
    }
}

module.exports = CategoriaController;