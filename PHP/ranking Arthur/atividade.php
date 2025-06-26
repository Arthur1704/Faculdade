<?php

    require_once 'DatabaseMysql.php';

    $data_att = $_POST['data_att'];
    $nome_aluno = $_POST['nome_aluno'];
    $att = $_POST['atividade'];
    $nota_att = $_POST['nota_att'];
    $obs = $_POST['obs'];
    $data_cadastro = date("Y-m-d");

    $db = new DataBase();

    $sql = "INSERT INTO entrega_de_atividades (data_entrega, aluno, cod_atividade, nota, observacoes, criado_em) VALUES (?,?,?,?,?,?)";
    $db->executa_comando($sql, [$data_att, $nome_aluno, $att, $nota_att, $obs, $data_cadastro]);

    $db->desconecta_BD();
    header ("Location: cadastrar_entrega.php");



?>