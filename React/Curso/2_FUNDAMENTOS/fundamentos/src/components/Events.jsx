const Events = () => {

    const handleMyEvent = () => {
        alert("Você Clicou");
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