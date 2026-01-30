import { useState } from 'react'

// COMPONENTS

import FirstComponent from "./components/FirstComponent"

// CSS
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
        <h1>Fundamentos React</h1>
        <FirstComponent />
      </div>
    </>
  )
}

export default App
