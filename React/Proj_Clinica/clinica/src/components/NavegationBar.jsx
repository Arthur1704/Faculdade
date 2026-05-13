import {useState} from 'react'

const [button, setButton] = useState("");

const navegationBar = () => {
  return (
    <div className="bar">
        <a href="#" className='pacienteButton'>Pacientes</a>
    </div>
  )
}

export default navegationBar