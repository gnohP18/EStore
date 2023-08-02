const mongoose = require('mongoose');
const connectionString = 'mongodb://localhost:27017/estore_dev';

async function connectToDB() {
    try {
        await mongoose.connect(connectionString, {
            useNewUrlParser: true,
            useUnifiedTopology: true,
        });

        console.log(`Connect Successfully to ${connectionString}`);
    } catch (error) {
        console.log(`Connect Unsuccessfully to ${connectionString}`);
    }
}

module.exports = { connectToDB };
