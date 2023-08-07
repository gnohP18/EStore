module.exports = {
    arrayMongooseToObjects: function (arrayMongoose) {
        return arrayMongoose.map((mongoose) => mongoose.toObject());
    },

    mongooseToObject: function (mongoose) {
        return mongoose ? mongoose.toObject() : mongoose;
    },
};
