import { useState } from "react";

const CondicionalRender = () => {
    const [x] = useState(false);
    const [name, setName] = useState("Maria");
  return (
    <div>
        <h1>Isso sera exibido ?</h1>
        {x && <p>Se x for true, sim</p>}
        {!x && <p>Agora x é falso</p>}

        {name === "Arthur" ? (
            <div>
                <p>O nome é Arthur!!</p>
            </div>
        ) : (
            <div>
                <p>Nome não encontrado!!</p>
            </div>
        )}

        <button onClick={() => setName("Arthur")}>Clique aqui!!</button>
    </div>
  )
}

export default CondicionalRender