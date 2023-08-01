class ItemsController {
    // [GET] /items
    index(req, res) {
        res.render('items');
    }

    // [GET] /items/:slug
    detail(req, res) {
        res.send('Item detail');
    }
}

module.exports = new ItemsController();
