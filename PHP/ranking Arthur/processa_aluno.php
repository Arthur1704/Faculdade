<?php

    //Arquivio conexão com Banco de dados;
    require_once 'DatabaseMysql.php';

    $ra_aluno = $_POST['ra_aluno'];
    $nome_aluno = $_POST['nome_aluno'];
    $sobrenome = $_POST['sobrenome_aluno'];
    $curso = $_POST['curso'];
    $email = $_POST['email'];
    $cidade = $_POST['cidade'];
    $ano = $_POST['ano'];
    $data = date("Y-m-d H:i:s");

    $db = new DataBase();

    $sql = "INSERT INTO alunos (ra, nome, sobrenome, curso, email, cidade, ano_ingresso, criado_em) VALUES (?,?,?,?,?,?,?,?)";

    if ($db->executa_comando($sql, [$ra_aluno, $nome_aluno ,$sobrenome ,$curso ,$email, $cidade, $ano, $data])) {
        echo "<p>Dados inseridos com sucesso no banco de dados!</p>" ;
    } else {
        echo "<p>Erro ao inserir os dados no banco.</p>";
    }
    $db->desconecta_BD();
    header('Location: alunos.php');
?>