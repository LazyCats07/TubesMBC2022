const search = async() => {
  const dataSearch = document.getElementById('inSearch').value
  let inf = await data()
  let listed = () => {
    const list = []
    try{
      const data = inf[dataSearch].name
      data.forEach(nama => {
        const node = document.createTextNode(nama)
        list.push(node)
      });
      return list
    } catch {
      list.push(document.createTextNode(`Data '${dataSearch}' not found!`))
      return list
    }
  }

  const node = listed()
  const parag = document.createElement('p')
  node.forEach(l => {
    parag.appendChild(l)
  })
  const element = document.getElementById('header')
  element.appendChild(parag)
  console.log(listed())
}

const data = async () => {
  const raw = await fetch('assets/data/skill.json')
  const data = await raw.json()
  return data
}