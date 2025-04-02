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

        .hidden {
            display: none;
        }
    </style>
</head>
<body>
    <h1>Escolha uma Área para Conhecer:</h1>
    <form>
        <label for="area">Selecione a área:</label>
        <select id="area" name="area" onchange="esconder_aparecer()">
            <option value="">-- Selecione --</option>
            <option value="front">Front End</option>
            <option value="back">Back End</option>
        </select>

        <div id="front-end" class="hidden">
            <label for="front-linguagens">Selecione uma linguagem de Front End:</label>
            <select id="front-linguagens" name="front-linguagens">
                <option value="html">HTML</option>
                <option value="css">CSS</option>
                <option value="javascript">JavaScript</option>
            </select>
        </div>

        <div id="back-end" class="hidden">
            <label for="back-linguagens">Selecione uma linguagem de Back End:</label>
            <select id="back-linguagens" name="back-linguagens">                
                <option value="python">Python</option>
                <option value="java">Java</option>
                <option value="php">PHP</option>        
            </select>
        </div>

        <button type="submit">Enviar</button><br>
        <button type="button">Adicionar Conteúdo</button>
    </form>

    <script>
        function esconder_aparecer() {
            const area = document.getElementById('area').value;
            const front = document.getElementById('front-end');
            const back = document.getElementById('back-end');

            if (area === 'front') {
                front.classList.remove('hidden');
                back.classList.add('hidden');
            } else if (area === 'back') {
                back.classList.remove('hidden');
                front.classList.add('hidden');
            } else {
                front.classList.add('hidden');
                back.classList.add('hidden');
            }
        }
    </script>
</body>
</html>