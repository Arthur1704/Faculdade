import React from 'react'

const UserDetails = ({name, age, work}) => {
  return (
    <div>
        <h1>Lista de Pessoas:</h1>
        <ul>
            <li>Nome: {name}</li>
            <li>Idade: {age}</li>
            <li>Profissão: {work}</li>
        </ul>
        {age >= 18 ? (
           <>
            <p>Pode tirar Habilitação!</p>
           </>
        ) : (<p></p>)}
    </div>
  )
}

export default UserDetails