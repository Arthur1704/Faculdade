import React from 'react'

const CarDetails = ({marca, km, newCar}) => {
  return (
    <div>
        <h2>Detalhes do Carro:</h2>
        <ul>
            <li>Marca: {marca}</li>
            <li>Km: {km}</li>
        </ul>
        {newCar && <p>É um carro novo!!</p>}
    </div>
  )
}

export default CarDetails