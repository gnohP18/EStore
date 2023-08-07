const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const ItemImages = new Schema({
    itemId: { type: String },
    image: { type: String, default: '' },
    createAt: { type: Date, default: new Date() },
    createBy: { type: String, default: 'admin' },
    updateAt: { type: Date, default: new Date() },
    updateBy: { type: String, default: 'admin' },
});

module.exports = mongoose.model('ItemImages', ItemImages);
