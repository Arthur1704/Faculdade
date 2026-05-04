import React from 'react'

const Container = ({children}) => {
  return (
    <div>
        <h2>Este é o titulo o container</h2>
        {children}
    </div>
  )
}

export default Container