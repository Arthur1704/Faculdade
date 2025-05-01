<?php

require_once 'conexaoBD.php';

if($_SERVER['REQUEST_METHOD'] == "POST"){
    $nome = $_POST['nome'];
    $telefone = $_POST['telefone'];
    $endereco = $_POST['endereco'];
    $curso = $_POST['curso'];

    try{
        $sql = $pdo->prepare("INSERT INTO alunos (nome, telefone, endereco, curso) VALUES (?,?,?,?)");
        $sql->execute([$nome, $telefone, $endereco, $curso]);
        echo "<script>alert('Cadastro feito com sucesso!!')</script>";
    }
    catch(Exception $e){
        echo "<script>alert('Não foi possivel cadastrar, erro: " . $e->getMessage() ."')</script>";
    }
}

?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Formulario BD</title>
        <link rel="stylesheet" href="css.css">
    </head>
    <body>
        <form action="index.php" method="POST">
            <h2>Formulario</h2>
            <label for="nome">Nome:</label><br>
            <input type="text" name="nome" id="nome" required size="35px"><br><br>
            <label for="telefone">Telefone:</label><br>
            <input type="text" name="telefone" id="telefone" required size="35px"><br><br>
            <label for="endereco">Endereço:</label><br>
            <input type="text" name="endereco" id="endereco" required size="35px"><br><br>
            <label for="curso">Curso:</label><br>
            <input type="text" name="curso" id="curso" required size="35px"><br><br>
            <input type="submit" name="submit" id="submit">
        </form>
    </body>
</html>