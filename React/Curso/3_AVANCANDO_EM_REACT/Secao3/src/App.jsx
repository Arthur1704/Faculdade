import { useState } from 'react'
import './App.css'
import Floresta from "./assets/img2.jpg";
import ManageData from './components/ManageData';
import ListRender from './components/ListRender';
import CondicionalRender from './components/CondicionalRender';
import ShowUserName from './components/ShowUserName';
import CarDetails from './components/CarDetails';
import Fragments from './components/Fragments';
import Container from './components/Container';
import ExecuteFunction from './components/ExecuteFunction';
import Message from './components/Message';
import ChangeMessageState from './components/ChangeMessageState';

function App() {
  const [count, setCount] = useState(0)
  const name = "Maria";

  const cars = [
    {id: 1, marca: "Chevrolet", km: 10000, newCar: false},
    {id: 2, marca: "Maserati", km: 0, newCar: true},
    {id: 3, marca: "Jaguar", km: 250, newCar: false}
  ];

  function showMessage() {
    console.log("Evento do componente pai!!")
  }

  const [message, setMessage] = useState("");

  const handleMessage = (msg) => {
    setMessage(msg);
  };

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
      <CarDetails marca = "Fiat" km = {10000} newCar = {true}/>
      {/* Reaproveitamento */}
      <CarDetails marca = "Ford" km = {200} newCar = {false}/>
      {/* Loop em array de Objetos */}
      {cars.map((car) => (
        <CarDetails marca={car.marca} km={car.km} newCar={car.newCar} />
      ))}
      {/* Fragments */}
      <Fragments />
      {/* Children */}
      <Container>
        <p>Este é um comentario</p>
      </Container>
      {/* Executar função */}
      <ExecuteFunction myFunction={showMessage}/>
      {/* State lift */}
      <Message msg={message}/>
      <ChangeMessageState handleMessage = {handleMessage}/>
    </div>

  )
}

export default App
