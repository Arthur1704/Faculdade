import { useParams } from "react-router-dom"
import { useFetch } from "../hooks/useFetch";

const Product = () => {
  
  const {id} = useParams();
  const url = "http://localhost:3000/products/" + id
  const {data: product, loading, error} = useFetch(url)
  return (
    <>
      <p>ID do produto:</p>
      {error && <p>Ocorreu um erro ...</p>}
      {loading && <p>Caregando ...</p>}
      {product &&(
        <div>
          <h1>{product.name}</h1>
          <p>R$ {product.price}</p>
        </div>
      )}
    </>
  )
}

export default Product