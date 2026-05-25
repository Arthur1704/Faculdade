import "./Home.css"
import { useFetch } from '../hooks/useFetch'
import { Link } from "react-router-dom"

const Home = () => {
  // 3 - Carregamento de dados

  const url = "http://localhost:3000/products"

  const {data: items, loading, error} = useFetch(url)
  return (
    <div>
      <h1>Products</h1>
      {error && <p>{error}</p>}
      <ul className="products">
        {items && items.map(product =>(
          <li key={product.id}>
            <h2>Nome: {product.name}</h2>
            <p>Preço: R${product.price}</p>
            {/* 4 - rota Dimanmica */}
            <Link to={`products/${product.id}`}>Detalhes</Link>
          </li>
        ))};
      </ul>
    </div>
  )
}

export default Home