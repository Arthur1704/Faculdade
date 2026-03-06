import { useState } from 'react'

// COMPONENTS
import FirstComponent from "./components/FirstComponent"
import TemplateExpression from './components/TemplateExpression'
import Events from './components/Events'


// CSS
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
        <h1>Fundamentos React</h1>
        <FirstComponent />
        <TemplateExpression />
        <Events />
      </div>
    </>
  )
}

export default App
