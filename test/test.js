// let dat

// const request = async() => {
//   dat = await fetch('http://localhost:5000')
//     .then(res => {
//       if (res.ok) {
//         return res.json()
//       }
//     })
//   console.log(dat)
// }

// request()

let dat = async() => {
  await fetch('http://127.0.0.1:5000/data').then(res => {
    if(res.ok) {
      return res.json()
    }
  }).then((jsonDat) => {
    console.log(jsonDat)
  })
}
dat()
// console.log(dat)