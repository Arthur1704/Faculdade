<?php

//36. Faça um script que verifica se um arquivo existe em uma pasta específica.

    $diretorio = "./";
    $nome = "ate25.php";
    $arquivo = $diretorio.$nome;

    if (file_exists($arquivo)){
        echo "Este arquivo existe!!";
    }
    else {
        echo "Este arquivo não existe!!";
    }


//37. Liste todos os arquivos dentro de uma pasta no servidor.

    echo "<br><br>";
    $diretorio = "./";

    $arquivos = scandir($diretorio);

    foreach($arquivos as $arquivo){

        echo $arquivo . "<br>";

    }
    

//38. Crie um script que cria um arquivo chamado "dados.txt" e escreve "Olá, Mundo!" nele.    
    
    // echo "<br><br>";
    // $nome = "dados";

    // $arquivo = fopen("$nome.txt", "w");

    // $conteudo = "Olá, Mundo!";
    // $caminho = $diretorio . $nome . ".txt"; 

    // if (file_exists($caminho)){
    //     if(fwrite($arquivo, $conteudo)){
    //         echo "Arquivo Criado com sucesso!!";
    //     }
    //     else{
    //         echo "Não gravou!!";
    //     }
    //     fclose($arquivo);
    // }else{
    // echo "Falha ao criar o arquivo!!";
    // }


//39. Leia o conteúdo do arquivo "dados.txt" e exiba na tela.

    echo "<br><br>";    
    $nome = "dados";
    $arquivo = fopen("$nome.txt", "r");
    echo fgets($arquivo);
    fclose($arquivo);
    
    
//40. Adicione uma nova linha ao final do arquivo "dados.txt" sem apagar o conteúdo anterior.

    // echo "<br><br>";
    // $arquivo = fopen("$nome.txt", "a");
    // $conteudo = "\n\nEstamos na questão 40";
    // $caminho = $diretorio . $nome . ".txt"; 

    // if (file_exists($caminho)){
    //     if(fwrite($arquivo, $conteudo)){
    //         echo "Arquivo modificado com sucesso!!";
    //     }
    //     else{
    //         echo "Não gravou!!";
    //     }
    //     fclose($arquivo);
    // }


//41. Faça um script que verifica se um arquivo existe antes de tentar lê-lo.

    echo "<br><br>";
    $diretorio = "./";
    $nome = "dados";
    $arquivo = $diretorio . $nome . ".txt";

    if (file_exists($arquivo)){
        $arquivo = fopen("$nome.txt", "r");
        echo fgets($arquivo);
        fclose($arquivo);
    }
    else {
        echo "Este arquivo não existe!!";
    }

//42. Exclua o arquivo "dados.txt" (se ele existir).

    echo "<br><br>";
    $diretorio = "./";
    $nome = "dados";
    $arquivo = $diretorio . $nome . ".txt";
    if (file_exists($arquivo)){
        unlink($arquivo);
        echo "Arquivo excluido com sucesso!!";
    }
    else {
        echo "Este arquivo não existe!!";
    }

?>