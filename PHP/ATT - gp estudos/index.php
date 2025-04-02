<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulário de Linguagens</title>
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

        select {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
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
    <h1>Escolha uma Área para Conhecer:</h1>
    <form action="" method="POST">
        <label for="area">Selecione a área:</label>
        <select id="area" name="area">
            <option value="">-- Selecione --</option>
            <option value="front">Front End</option>
            <option value="back">Back End</option>
        </select>

        <button type="submit">Enviar</button><br><br>
        <button type="button" onclick="window.location.href='form_add_conteudo.php'">Adicionar Conteúdo</button>
    </form>

        <?php
        
            $arquivos = scandir()
        
        ?>
    
</body>
</html>