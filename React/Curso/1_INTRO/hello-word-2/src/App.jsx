import { useState } from 'react'
import './App.css'


function Login() {
  return (
    <>
      <div className="formulario">
        <form action="">
          <label htmlFor="login">
            Login:
            <br />
            <input type="text" name="login" id="login" />
          </label>

          <br/><br />

          <label htmlFor="senha">
             Senha:
             <br />
            <input type="text" name="senha" id="senha" />
          </label>
        </form>
      </div>
    </>
  )
}

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
        <h1>Ola mundo</h1>
        <br />
        <Login />
      </div>
    </>
  )
}

export default App
