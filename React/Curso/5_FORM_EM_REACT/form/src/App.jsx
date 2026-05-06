import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import Myform from './components/Myform'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div>
      <h2>Forms</h2>
      <Myform />
    </div>
  )
}

export default App
