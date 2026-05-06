import { useState } from 'react'
import './App.css'
import MyComponent from './components/MyComponent'

function App() {
  const [count, setCount] = useState(0)
  const num = 12;

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
    </div>
  )
}

export default App
