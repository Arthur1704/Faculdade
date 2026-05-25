import { useSearchParams, Link } from "react-router-dom"
import { useFetch } from "../hooks/useFetch"

const Search = () => {
    const [searchParams] = useSearchParams();

    const url = "http://localhost:3000/products?" + searchParams;

    const {data: items, loading} = useFetch(url)
    console.log(url)
console.log(items)
  return (
    <div>
        <h1>Resultados disponiveis: </h1>
        <ul className="products">
            {items && items.map(product =>(
            <li key={product.id}>
                <h2>Nome: {product.name}</h2>
                <p>Preço: R${product.price}</p>            
                <Link to={`/products/${product.id}`}>Detalhes</Link>
            </li>
            ))}
        </ul>
    </div>
  )
}

export default Search