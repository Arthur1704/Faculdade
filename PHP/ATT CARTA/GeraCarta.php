<?php

    if($_SERVER['REQUEST_METHOD'] == 'POST'){
        $nome_R = $_POST['nome_remetente'];
        $nome_D = $_POST['nome_destinatario'];
        $endereco_R = $_POST['endereco_remetente'];
        $num_R = $_POST['num_remetente'];
        $endereco_D = $_POST['endereco_destinatario'];
        $num_D = $_POST['num_destinatario'];
        $data = $_POST['data'];
        $assunto = $_POST['assunto'];
        $conteudo = $_POST['conteudo'];

        $nomeA = "$data-$nome_R.txt";
        $arquivo = fopen("$nomeA", "w");

        $escrever = "$endereco_R-$num_R\n$data\n\n$nome_D\n$endereco_D-$num_D\n\nAssunto: $assunto\n\nPrezado(a): $nome_D, $conteudo\nAtensiosamente,\n$nome_R";

        fwrite ($arquivo, $escrever);
        fclose ($arquivo);
    }

?>