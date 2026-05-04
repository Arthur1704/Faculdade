import { useState } from 'react'
import './App.css'
import Floresta from "./assets/img2.jpg";
import ManageData from './components/ManageData';
import ListRender from './components/ListRender';
import CondicionalRender from './components/CondicionalRender';
import ShowUserName from './components/ShowUserName';
import CarDetails from './components/CarDetails';

function App() {
  const [count, setCount] = useState(0)
  const name = "Maria";

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
      {/* Props */}
      <ShowUserName name={name}/>
      {/* Destructuring */}
      <CarDetails marca = "Fiat" km = {10000}/>
    </div>

  )
}

export default App
