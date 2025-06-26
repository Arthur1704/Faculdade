<?php 

    require 'DatabaseMysql.php';

    $nome_att = $_POST['nome_att'];
    $data_att = $_POST['data_entrega'];
    $data_cadastro = date("Y-m-d H:i:s");

    $db = new Database();

    $sql = "INSERT INTO atividades (nome_atividade, data_entrega, data_inicio) VALUES (?,?,?)";

    $db->executa_comando($sql, [$nome_att, $data_att, $data_cadastro]);
    $db->desconecta_BD();
    header('Location: cadastrar_atividade.php');




?>