const express = require('express')
const path = require('path')
const fs = require('fs')
const app = express()
const port = 9000

app.use(express.static(path.join(__dirname, '../'))) //change this for root directory
app.use(express.urlencoded({
  extended: true
}))

const files = fs.readdirSync(path.join(__dirname, '../')) // change the path for html files

// using method get to all the html files
for(f in files) {
  const file = files[f]
  if(!file.endsWith('.html')) {
    continue
  }

  if(file == 'main.html') {
    app.get('/', (req, res) => {
      res.sendFile(path.join(__dirname, `../${file}`))
    })
  } else {
    app.get(`/${file.split('.')[0]}`, (req, res) => {
      res.sendFile(path.join(__dirname, `../${file}`))
    })
  }
}

app.listen(port, () => console.log('Listening on port 9000'))