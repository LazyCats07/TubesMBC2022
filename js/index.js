const search = async() => {
  const dataSearch = document.getElementById('inSearch').value
  console.log(dataSearch)
  let inf = await data()
  console.log(inf[dataSearch].name)

}

const data = async () => {
  const raw = await fetch('assets/data/skill.json')
  const data = await raw.json()
  return data
}