<?php
    if ($_SERVER['REQUEST_METHOD'] == 'POST'){
        $nomeP = $_POST['nome'];
        $idade = $_POST['idade'];
        $cpf = $_POST['cpf'];


        $nome = "DADOS.csv";

        $conteudo = array($nomeP, $idade, $cpf);

        $arquivo = fopen("$nome", "a");

        if ($arquivo){
            if (fputcsv($arquivo, $conteudo)){
            echo "Usuario inserido com sucesso!!";
            }else{
                echo "Não foi possivel gravar!!";
            }
        }
        fclose($arquivo);


    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Cadastro</title>
    </head>
    <body>
        <form action="Q46.php" method="POST">
            <label>Nome:</label><br>
            <input type="text" name="nome" required>
            <br><br>
            <label>Idade:</label><br>
            <input type="number" name="idade" required>
            <br><br>
            <label>CPF:</label><br>
            <input type="text" name="cpf" size="25px" required>
            <br><br>
            <input type="submit" name="submit">
        </form>
    </body>
</html>