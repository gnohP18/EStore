const itemsRouter = require('./items')
const sitesRoute = require('./sites')

function route(app){
    app.use('/items', itemsRouter)

    app.use('/', sitesRoute)
}

module.exports = route;