import { useState, useEffect } from "react";

//4 - Custom hook

export const useFecth = (url) => {
    const [data, setData] = useState(null);

    useEffect(() => {

        const fechData = async () => {
            const res = await fetch(url)

            const json = await res.json()

            setData(json)
        }

        fechData();

    }, [url]);

    return {data}; 
};