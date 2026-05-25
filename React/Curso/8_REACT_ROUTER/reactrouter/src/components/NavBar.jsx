import { Link, NavLink } from 'react-router-dom'
import './NavBar.css'


const NavBar = () => {
  return (
    <nav>
        {/* <Link to="/">Home</Link>
        <Link to="/about">Sobre</Link> */}
        <NavLink to="/" 
        // className={({isActive}) => (isActive ? "esta-ativo" : "nao-ativo")}>
          >Home</NavLink>
        <NavLink to="/about">Sobre</NavLink>
    </nav>
  )
}

export default NavBar