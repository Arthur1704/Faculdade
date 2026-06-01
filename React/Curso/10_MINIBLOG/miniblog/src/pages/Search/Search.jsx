import { useQuery } from "../../hooks/useQuery"
import styles from "./Search.module.css"

import React from 'react'

const Search = () => {

  const query = useQuery()

  const search = query.get("q");
  return (
    <div>
        <h2>Search</h2>
        <p>{search}</p>
    </div>
  )
}

export default Search