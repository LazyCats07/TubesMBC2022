let data
// let dat = async() => {await fetch('https://b0fb-180-244-139-168.ap.ngrok.io/profil')
//   .then(res => {
//     if(res.ok) {
//       return res.json()
//     }
//   })
//   .then(jsonRes => {
//     console.log(jsonRes)
//     data = jsonRes
//   })
// }
// dat()

const delay = ms => new Promise(res => setTimeout(res, ms));

const search = async() => {
  fetch('http://127.0.0.1:5000/data')
    .then(res => {
      if(res.ok) {
        return res.json()
      }
    })
    .then(jsonRes => {
      console.log(jsonRes)
      data = jsonRes
    })
  let doc = document.getElementById('inSearch').value
  console.log('hi')
  console.log(data)
}