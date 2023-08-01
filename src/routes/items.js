const express = require('express')
const router = express.Router()

const itemsController = require('../app/controllers/ItemsController')

router.use('/:slug', itemsController.detail)
router.use('/', itemsController.index)

module.exports = router