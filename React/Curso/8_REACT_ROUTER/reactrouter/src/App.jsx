import './App.css'

// 1 - Config react Router
import {BrowserRouter, Routes, Route} from "react-router-dom"

//Components
import NavBar from './components/NavBar'

// Pages
import Home from './pages/Home'
import About from './pages/About'
import Info from './pages/Info'
import Product from './pages/Product'
import NotFound from './pages/NotFound'


function App() {


  return (
    <div className='App'>
      <h1>React Router</h1>
      <BrowserRouter>
       <NavBar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />}/>
          <Route path="/products/:id" element={<Product />}/>
          {/* 6 - nested route */}
          <Route path='/products/:id/info' element={<Info />}/>
          {/* 7 - no match route */}
          <Route path='*' element={<NotFound/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
