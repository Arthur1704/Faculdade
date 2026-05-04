import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import UserDetails from './Components/UserDetails'

function App() {
  const [count, setCount] = useState(0)

  const Users = [
    {id: 1, name:"Arthur", age:19, work:"Desenvolvedor"},
    {id: 2, name:"Maria", age:22, work:"Enfermeira"},
    {id: 3, name:"Leandro", age:21, work:"Designer"},
    {id: 4, name:"Felipe", age:21, work:"Contador"}
  ];

  return (
    <>
      {Users.map((user) => (
        <UserDetails name = {user.name} age={user.age} work={user.work} />
      ))}
    </>
  )
}

export default App
