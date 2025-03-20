<?php

//49. Faça um script que calcula o número de palavras dentro de um arquivo de texto enviado pelo usuário.

    $nome = "Log.txt";

    $arquivo = fopen($nome, "r");

    $caminho = "./$nome";

    if ($arquivo){
        $conteudo = file_get_contents($caminho);

        $numero_palavras = str_word_count($conteudo);

        echo "A quantidade de palavras deste arquivo é: " . $numero_palavras;
    }

?>