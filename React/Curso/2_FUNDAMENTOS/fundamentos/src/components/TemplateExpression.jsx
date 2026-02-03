const TemplateExpression = () => {

    const name = "Arthur";

    const data = {
        age : 19,
        job : "dev",
    };

    return (
        <div>
            <h1>Seja bem vindo, {name}</h1><br />
            <h2>Voce atua como {data.job}</h2>
        </div>
    );

};


export default TemplateExpression;