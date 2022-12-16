const search = async() => {
  const dataSearch = document.getElementById('inSearch').value
  let inf = await data()
  let listed = () => {
    const list = []
    // Creating the text for paragraph
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

  const parent = document.getElementsByClassName('home')
  const node = listed()
  const parag = document.createElement('p')
  node.forEach(l => {
    parag.appendChild(l)
  }) // output: <p> [text] </p>
  const element = document.getElementById('header') // need to create id for section header for every html
  element.appendChild(parag) // put the parag output on the end of header id
  console.log(listed())
}

const data = async () => {
  const raw = await fetch('assets/data/skill.json')
  const data = await raw.json()
  return data
}