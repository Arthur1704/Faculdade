<?php

require_once 'DatabaseMysql.php';

    $id = $_POST['id'];
    $ra_aluno = $_POST['ra_aluno'];
    $nome_aluno = $_POST['nome_aluno'];
    $sobrenome = $_POST['sobrenome_aluno'];
    $curso = $_POST['curso'];
    $email = $_POST['email'];
    $cidade = $_POST['cidade'];
    $ano = $_POST['ano'];

    $db = new Database();

    $sql = "UPDATE alunos SET ra = ?, nome = ?, sobrenome = ?, curso = ?, email = ?, cidade = ?, ano_ingresso = ? WHERE id = ?";
    try{
        $db->consulta($sql, [$ra_aluno, $nome_aluno, $sobrenome, $curso, $email, $cidade, $ano, $id]);
        $db->desconecta_BD();
        header('Location: alunos.php');
    }
    catch (Exception $e) {
        echo "Ocorreu um erro: " . htmlspecialchars($e->getMessage());
    }

?>