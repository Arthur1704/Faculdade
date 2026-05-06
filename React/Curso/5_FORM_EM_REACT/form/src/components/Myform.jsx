import "./Myform.css"

const Myform = () => {
  return (
    <div>
        {/* 1 - Crianção do form */}
        <form>
            <div>
                <label htmlFor="name">Nome:</label>
                <input type="text" name="name" placeholder="Digite seu nome"/>
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