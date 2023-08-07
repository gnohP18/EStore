const { json } = require('express');
const Shoes = require('../models/Shoes');
const ItemImages = require('../models/ItemImages');
const {
    arrayMongooseToObjects,
    mongooseToObject,
} = require('../../util/mongoose');

class ItemsController {
    // [GET] /items
    index(req, res, next) {
        Shoes.find({})
            .then((listShoes) => {
                console.log(listShoes);
                res.render('items', {
                    listShoes: arrayMongooseToObjects(listShoes),
                });
            })
            .catch((err) => next(err));
    }

    // [GET] /items/create
    create(req, res, next) {
        res.render('items/create');
    }

    // [POST] /items/store
    store(req, res, next) {
        var newShoes = new Shoes(req.body);
        console.log(newShoes);
        //newShoes.save();
        res.render('items');
    }

    // [GET] /items/:slug
    detail(req, res, next) {
        Shoes.findOne({ slug: req.params.slug })
            .then((shoes) => {
                shoes: mongooseToObject(shoes);
                console.log(shoes.id);
                res.render('items/detailItem', {
                    shoes: mongooseToObject(shoes),
                });
            })
            .catch((err) => next(err));

        // ItemImages.find({})
        //     .then((listImageItems) => {
        //         listImageItems: arrayMongooseToObjects(listImageItems);
        //         console.log(listImageItems);
        //         res.render('detailItem');
        //     })
        //     .catch((err) => next(err));
    }
}

module.exports = new ItemsController();
