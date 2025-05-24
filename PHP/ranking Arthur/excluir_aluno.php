<?php

    require_once 'DatabaseMysql.php';

    $id = $_GET['id'];

    $db = new Database();

    $sql = "DELETE FROM alunos WHERE id = ?";

    try{
        $db->consulta($sql, [$id]);
        $db->desconecta_BD();
    }
    catch(Exception $e){
        echo "Erro: " . htmlspecialchars(e->getMessage());
    }
?>
