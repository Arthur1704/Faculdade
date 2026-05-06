import { useState } from "react"
import "./Myform.css"

const Myform = ({user}) => {
    //  6 - controlled inputs
    // 3 - Gerenciando dados
    const [name, setName] = useState(user ? user.name : "");
    const [email, setEmail] = useState(user ? user.email : "");
    const [bio, setBio] = useState("");

    const handleName = (e) => {
       setName(e.target.value);
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log("Enviando o formulario");
        console.log(name, email, bio);

        // 7 - LIMPANDO FORM APOS ENVIO
        setName("");
        setEmail("");
        setBio("");
    }

  return (
    <div>
        {/* 5 - Envio de Form */}
        {/* 1 - Crianção do form */}
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="name">Nome:</label>
                <input type="text" name="name" placeholder="Digite seu nome" onChange={handleName} value={name}/>
            </div>
            {/* 2 - Label envolvendo Input */}
            <label>
                <span>E-mail: </span>
                {/* Simplificação de manipulação de input */}
                <input type="email" name="email" placeholder="Digite seu email" onChange={(e) => setEmail(e.target.value)} value={email}/>
            </label>

            {/* TextArea */}
            <label>
                <span>Bio: </span>
                <textarea name="bio" onChange={(e) => setBio(e.target.value)} value={bio}></textarea>
            </label>
            <input type="submit" value="Enviar" />
        </form>
    </div>
  )
}

export default Myform