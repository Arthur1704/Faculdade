import "./NavigationBar.css"

const NavigationBar = () => {
  return (
    <div className="bar">
      <nav className="sideBar">
        <h1>Clinica Viana</h1>
        <ul>
          <li><a href="#">Consultas</a></li>
          <li><a href="#">Pacientes</a></li>
          <li><a href="#">Medicos</a></li>
          <li><a href="#">Relatorios</a></li>
          <li id="sair"><a href="#">Sair</a></li>
        </ul>
      </nav>
    </div>
  )
}

export default NavigationBar