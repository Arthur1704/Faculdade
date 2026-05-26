import './App.css'
import { BrowserRouter, Route, Routes } from "react-router-dom";
import NavBar from './components/NavBar'
import Home from './pages/Home';
import About from './pages/About';
import Products from './pages/Products';


function App() {
 
  return (
    <div>
      <h1>Constext API</h1>
      <BrowserRouter>
        <NavBar/>
        <Routes>
          <Route path="/" element={<Home />}/>
          <Route path='/products' element={<Products />}/>
          <Route path="/about" element={<About />}/>
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
