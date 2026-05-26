import { NavLink } from "react-router-dom";
import "./NavBar.css";
const NavBar = () => {

  return (
    <div>
        <nav>
            <NavLink to="/">Home</NavLink>
            <NavLink to="/products">Produtos</NavLink>
            <NavLink to="/about">Sobre</NavLink>
        </nav>
    </div>
  )
}

export default NavBar