import { useState } from 'react'
import './App.css'
import MyComponent from './components/MyComponent'
import Title from './components/Title';

function App() {
  const [count, setCount] = useState(0)
  const num = 12;
  const title = false

  return (
    <div>
      {/* CSS GLOBAL */}
      <h1>React com css</h1>
      {/* CSS DE COMPONENTE */}
      <MyComponent />
      {/* CSS INLINE */}
      <p style={{color: "white"}}>Este elemento foi estilizado de forma inline</p>
      {/* CSS INLINE DINAMICO */}
      <h2 style={num < 10 ? ({color: "blue"}) : ({color: "Magenta"})}>CSS Dinamico</h2>
      {/* CLASSE DINAMICA */}
      <h2 className={title ? "title" : "title2"}>Esse elemento tem uma classe dinamica</h2>
      {/* CSS Modules */}
      <Title />
    </div>
  )
}

export default App
