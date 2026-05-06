import { useState } from 'react'
import './App.css'
import MyComponent from './components/MyComponent'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div>
      {/* CSS GLOBAL */}
      <h1>React com css</h1>
      {/* CSS DE COMPONENTE */}
      <MyComponent />
    </div>
  )
}

export default App
