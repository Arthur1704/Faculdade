import React, { useState, useEffect } from 'react'

const useFetch = (url) => {

  const [data, setData] = useState(null);
  const [config, setConfig] = useState(null);
  const [method, setMethod] = useState(null);
  const [callFetch, setCallFetch] = useState(null);
  const [idProduct, setIdProduct] = useState();

  const httpConfig = (data, method) =>{
    if (method == "POST"){
        setConfig({
            method,
            headers:{
                "Content-type" : "application/json"
            },
            body: JSON.stringify(data),
        });

        setMethod(method);
    }
    else if(method == "DELETE"){
        setConfig({
            method
        });
        setMethod(method);
    }
  };

  useEffect(() =>{
    const buscarTodosDados = async () => {
        try{
            const res = await fetch(url)

            const json = await res.json()

            setData(json)
        }
        catch (e){
            console.log(e);
        }
    }

    buscarTodosDados();
  }, [url, callFetch]);


  useEffect (() =>{
    const httprequest = async () => {
        if (method == "POST"){
            let fetchOptions = [url, config];

            const res = await fetch(...fetchOptions);

            const json = await res.json();

            setCallFetch(json);
        }
        else if (method === "DELETE"){

            const deleteUrl = `${url}/${idProduct}`;
            let fetchOptions = [deleteUrl, config];

            const res = await fetch(...fetchOptions);

            setCallFetch("deleted");
        }
    }

    httprequest();

  }, [config, method, url])

  return {data, httpConfig, setIdProduct}
}

export default useFetch