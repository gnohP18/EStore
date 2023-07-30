const express = require('express')
const { engine } = require ('express-handlebars');
const morgan = require('morgan')
const path = require('path')
const app = express()
const port = 1804

//config static file
app.use(express.static(path.join(__dirname, '/public')))

//Logger morgan
app.use(morgan('combined'))

//Template engine
app.engine('hbs', engine({
    //Config engine
    //change extend name to shorter name
    extname: '.hbs'
}))
app.set('view engine', 'hbs')

app.set('views', path.join(__dirname, 'resources/views'))

app.get('/', (req, res) => res.render('home'))

app.listen(port, () => console.log(`Listening port http://localhost:${port}`))