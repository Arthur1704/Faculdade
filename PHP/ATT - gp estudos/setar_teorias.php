<?php

    require_once 'class.teorias.php';
    $teorias = new Teoria();

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        if (isset($_POST['submit'])) {

            $gp_estudos = $_POST['gp_estudos'];
            $linguagem = $_POST['linguagem'];
            $conteudo = $_POST['teoria'];
            $conteudo .= "\n\n\n";
            $conteudo .= $_POST['codigo'];

            $teorias->set_Teoria($conteudo, $gp_estudos, $linguagem);
            echo "<script>window.location.href='form_add_conteudo.php';</script>";
        }
    } 
    else {
       echo "Método não suportado ou não definido.\n";
    }
?>