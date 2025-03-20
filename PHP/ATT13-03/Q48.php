<?php

//48. Crie um script que gera um arquivo de log com a data e a ação realizada pelo usuário.

    $acao = "Gravação no Banco de dados.";

    $data = date("d-m-Y");

    $log = "$data - $acao\n\n";

    $nomeArq = "Log.txt";

    $arquivo = fopen($nomeArq, "a");

    if ($arquivo){
        fwrite($arquivo, $log);
        fclose($arquivo);
    }

    

?>