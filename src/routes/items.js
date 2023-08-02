const express = require('express');
const router = express.Router();

const itemsController = require('../app/controllers/ItemsController');

router.get('/:slug', itemsController.detail);
router.get('/', itemsController.index);

module.exports = router;
