import { useState } from 'react';
import './App.css'
import useFetch from './hooks/useFetch';


const url = "http://localhost:3000/products";
function App() {
  const [produtos, setProdutos] = useState([]);

  const [nome, setNome] = useState("");
  const [preco, setPreco] = useState("");

  const {data: items, httpConfig, setIdProduct} = useFetch(url);

  const handleSubmitPOST = async (e) => {
     e.preventDefault();

    const produto = {
      nome,
      preco
    };

    httpConfig(produto, "POST");

    setName("");
    setPrice("");
  }

  const handleSubmitDELETE = async (id) => {
    setIdProduct(id);
    httpConfig(null, "DELETE");
  }

  return (  
    <div className='App'>
      <h2>Produtos</h2>
      <ul>
        {items && items.map((produto) => (
          <li key={produto.id}>
            Nome: {produto.name} - preço: R${produto.price}

            <button onClick={() => handleSubmitDELETE(produto.id)}>
              EXCLUIR
            </button>
          </li>
        ))}
      </ul>
      <div className="addProduct">
        <form onSubmit={handleSubmitPOST}>
          <h2>Adicionar Produto</h2>
          <label>
            Nome:
            <input type="text" name='name' value={nome} onChange={(e) => setNome(e.target.value)}/>
          </label>
          <br />
          <label>
            Preço:
            <input type="number" name='price' value={preco} onChange={(e) => setPreco(e.target.value)}/>
          </label>
          <input type="submit" value="Enviar"/>
        </form>
      </div>
    </div>
  )
}

export default App
