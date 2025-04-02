<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulário de Código</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        h1 {
            color: #333;
            text-align: center;
        }

        form {
            background: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            max-width: 400px;
            margin: 0 auto;
        }

        label {
            display: block;
            margin-bottom: 8px;
            font-weight: bold;
        }

        select, textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }

        textarea{
            resize: vertical;
            width: 96%;
        }

        button {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
            transition: background-color 0.3s;
        }

        button:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <h1>Insira seu Código:</h1>
    <form action="class.adicionar_conteudo.php" method="POST">
        <label for="linguagem">Selecione a linguagem:</label>
        <select id="linguagem" name="linguagem">
            <option value="">-- Selecione --</option>
            <option value="html">HTML</option>
            <option value="css">CSS</option>
            <option value="javascript">JavaScript</option>
            <option value="python">Python</option>
            <option value="java">Java</option>
            <option value="php">PHP</option>
        </select>

        <label for="gp_estudos">Grupo de Estudos:</label>
        <input type="text" id="gp_estudos" name="gp_estudos">

        <label for="codigo">Insira seu trecho de teoria:</label>
        <textarea id="codigo" name="codigo" rows="10" placeholder="Cole seu código aqui..."></textarea>
        
        <label for="codigo">Insira seu trecho de código:</label>
        <textarea id="codigo" name="codigo" rows="10" placeholder="Cole seu código aqui..."></textarea>

        <button type="submit">Enviar</button>
    </form>
</body>
</html>