const express = require('express')
const path = require('path')

const app = express()

app.use(express.static(path.join(__dirname, '../')))

app.get('/', (req, res) => {
  res.send('hello')
})

app.listen(3000, () => console.log('Server Online'))