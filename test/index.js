const axios = require('axios')

axios.get('http://127.0.0.1:5000/dana')
  .then(res => {
    const listed_data = res.data
    listed_data.forEach(data => {
      console.log(data['Nama Lengkap'])
    });
  })