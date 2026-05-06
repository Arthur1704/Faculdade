import { useState } from "react"
import "./Myform.css"

const Myform = () => {
    const [name, setName] = useState();
    const [email, setEmail] = useState();

    const handleName = (e) => {
       setName(e.target.value);
    }

    console.log(name);

  return (
    <div>
        {/* 1 - Crianção do form */}
        <form>
            <div>
                <label htmlFor="name">Nome:</label>
                <input type="text" name="name" placeholder="Digite seu nome" onChange={handleName}/>
            </div>
            {/* 2 - Label envolvendo Input */}
            <label>
                <span>E-mail: </span>
                <input type="email" name="email" placeholder="Digite seu email"/>
            </label>
            <input type="submit" value="Enviar" />
        </form>
    </div>
  )
}

export default Myform