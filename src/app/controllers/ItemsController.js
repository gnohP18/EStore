const { json } = require('express');
const Shoes = require('../models/Shoes');

class ItemsController {
    // [GET] /items
    index(req, res) {
        Shoes.find({ size: 40 }).then(function (listShoes) {
            if (listShoes) {
                res.json(listShoes);
                return;
            }
            res.status(400).json({ error: 'ERROR!' });
        });
    }

    // [GET] /items/:slug
    detail(req, res) {
        res.send('Item detail');
    }
}

module.exports = new ItemsController();
