import { useState } from 'react'
import './App.css'
import Floresta from "./assets/img2.jpg";
import ManageData from './components/ManageData';
import ListRender from './components/ListRender';
import CondicionalRender from './components/CondicionalRender';

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="App">
      <h1>Avancando em React</h1>
      {/* Imagem em public */}
      <div>
        <img src="img1.jpg" alt="Paisagem" />
      </div>
      {/* Imagem em assets */}
      <div>
        <img src={Floresta} alt="Floresta" />
      </div>
      <ManageData />
      <ListRender />
      <CondicionalRender />
    </div>

  )
}

export default App
