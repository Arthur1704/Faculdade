import React from 'react'

const CarDetails = ({marca, km}) => {
  return (
    <div>
        <h2>Detalhes do Carro:</h2>
        <ul>
            <li>Marca: {marca}</li>
            <li>Km: {km}</li>
        </ul>
    </div>
  )
}

export default CarDetails