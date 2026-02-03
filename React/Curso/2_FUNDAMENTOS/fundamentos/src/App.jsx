import { useState } from 'react'

// COMPONENTS
import FirstComponent from "./components/FirstComponent"

// CSS
import './App.css'
import TemplateExpression from './components/TemplateExpression'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
        <h1>Fundamentos React</h1>
        <FirstComponent />
        <TemplateExpression />
      </div>
    </>
  )
}

export default App
