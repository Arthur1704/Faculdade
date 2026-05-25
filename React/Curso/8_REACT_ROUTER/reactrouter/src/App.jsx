import './App.css'

// 1 - Config react Router
import {BrowserRouter, Routes, Route} from "react-router-dom"

// Pages
import Home from './pages/Home'
import About from './pages/About'

//Components
import NavBar from './components/NavBar'

function App() {


  return (
    <div className='App'>
      <h1>React Router</h1>
      <BrowserRouter>
       <NavBar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />}/>
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
