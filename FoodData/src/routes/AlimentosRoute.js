const { Router } = require('express'); 
const AlimentoController = require('../controller/AlimentoController.js');

const alimentoController = new AlimentoController();

const router = Router();

router.get('/alimentos', (req, res) => alimentoController.getAll(req, res));
router.put('/alimentos/:id', (req, res) => alimentoController.update(req, res));

module.exports = router;