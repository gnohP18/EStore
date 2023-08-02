const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const Shoes = new Schema({
    name: { type: String, default: '' },
    image: { type: String, default: '' },
    color: { type: String, default: '' },
    size: { type: Number, default: 0 },
    quantity: { type: Number, default: 0 },
    createAt: { type: Date, default: new Date() },
    createBy: { type: String, default: 'admin' },
    updateAt: { type: Date, default: new Date() },
    updateBy: { type: String, default: 'admin' },
});

module.exports = mongoose.model('Shoes', Shoes);
