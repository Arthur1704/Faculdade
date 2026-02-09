const Events = () => {

    const handleMyEvent = () => {
        alert("Você Clicou");
    }

    const renderSomething = (x) => {

        if (x) {

            return <h1>Verdadeiro !!</h1>          
        }
        else{
            return <h1>Falso !!</h1>
        }
    }


    return (
        <div>
            <div>
                <button onClick={handleMyEvent}>Clique aqui!!</button>
            </div>
            <div>
                <button onClick={() => alert("Function in line")}>Clique aqui tambem!!</button>
            </div>
        </div>
    );
};

export default Events;