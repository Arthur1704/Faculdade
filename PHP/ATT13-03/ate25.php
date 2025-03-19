<?php

//1. Crie uma variável para armazenar seu nome e exiba na tela.

    $nome = "Arthur";

    echo $nome."<br>";

//2. Declare duas variáveis numéricas e exiba a soma delas.

    $a = 10;
    $b = 9;

    echo ($a + $b)."<br>";

//3. Crie uma variável booleana e exiba seu valor na tela.

    $true_false = false;

    var_dump($true_false);
    echo"<br>";
//4. Concatene duas strings e exiba o resultado.

    $sobrenome = " Viana"."<br>";

    echo  $nome . $sobrenome; 

//5. Declare uma constante e exiba seu valor.

    define ("naoMuda", "Não vai mudar");

    echo naoMuda . "<br><br>";


//6. Crie um código que verifica se um número é positivo, negativo ou zero.

    $num = -10;

    if ($num > 0){
        echo $num . " é Positivo<br>";
    }
    else if($num < 0){
        echo $num . " é Negativo<br>";
    }
    else{
        echo "É o numero zero<br>";
    }

//7. Faça um script que verifica se um número é par ou ímpar.

    $num2 = 11;

    if (($num2 % 2) == 0 ){
        echo $num2 . " é Par<br>";
    }
    else{
        echo $num2 . " é Impar<br>";
    }

//8. Use um switch-case para exibir o nome do dia da semana com base em um número de 1 a 7.

    $dia = "3";

    switch($dia){
        case 1:{
            echo "Domingo<br>";
            break;
        }
        case 2:{
            echo "Segunda-feira<br>";
            break;
        }
        case 3:{
            echo "Terça-feira<br>";
            break;
        }
        case 4:{
            echo "Quarta-feira<br>";
            break;
        }
        case 5:{
            echo "Quinta-feira<br>";
            break;
        }
        case 6:{
            echo "Sexta-feira<br>";
            break;
        }
        case 7:{
            echo "Sabado";
            break;
        }
        default:{
            echo "Dia invalido<br>";
            break;
        }
    }

//9. Crie um loop for que exiba os números de 1 a 10.

    for ($cont = 0; $cont < 10; $cont++){
        echo $cont+1 ."<br>";
    }

//10. Faça um loop while que exiba os números de 10 a 1.

    $num3 = 10;
    echo "<br>";
    while($num3 > 0){
        echo $num3."<br>";
        $num3--;
    }

//11. Crie um array com 5 cores e exiba todas elas usando um loop.

    echo "<br>";
    $cores = array("Amarelo", "Vermelho", "Verde", "Azul", "Branco");

    foreach ($cores as $cor){
        echo $cor . "<br>";
    }

//12. Faça um array associativo com nome e idade de 3 pessoas e exiba na tela.

    echo "<br>";
    $nomes = array("Artur -18", "Livia - 18", "Jéssica - 25");
    
    foreach($nomes as $nome){
        echo $nome."<br>";
    }

//13. Crie uma função que recebe dois números como parâmetros e retorna a soma.

    echo "<br>";
    $num4 = 20;
    $num5 = 50;

    function Soma($num, $num2){
        return $num + $num2;
    }

    echo  "A soma de " . $num4 . " + " . $num5 . " = " .Soma($num4, $num5);

//14. Faça uma função que recebe um array de números e retorna a média dos valores.


    echo "<br>";
    $notas = array(10, 5);

    function Media($notas){
        $quant = 0;
        $media = 0;
        foreach ($notas as $nota){
            $media += $nota;  
            $quant++;
        }

        return $media / $quant;
    }

    echo  "A Media é " .Media($notas);

//15. Crie uma função que recebe uma string e retorna a mesma string em maiúsculas.

    echo "<br>";
    $frase = "transformar";

    function Maiusculas($frase){
        return strtoupper($frase);
    }

    echo "A frase " . $frase . " em maiusculas é " . Maiusculas($frase);


//16. Remova espaços extras de uma string.

    echo "<br>";
    $espacos = "Tirar espaços desta frase";
    echo "A frase ". $espacos . " sem espaços é " . trim($espacos);

//17. Substitua todas as ocorrências da letra "a" por "@" em uma string.

    echo "<br>";
    $trocarA = "arthur Cruz Viana";

    echo $trocarA;
    echo "<br>";
    echo str_replace("a", "@", $trocarA);

//18. Verifique se uma palavra contém a letra "z".

    echo "<br>";
    $farseZ = "Azzure";

    if (strpos($farseZ, "z") == true){
        echo "A frase contem z";
    }
    else{
        echo "A frase não contem z";
    }

//19. Converta uma string para um array de palavras.

    echo "<br>";
    $fraseArray = "Tranformar tudo em palavras";

    $palavras = explode(" ", $fraseArray);

    foreach ($palavras as $palavra){
        echo $palavra . "<br>"; 
    }


//20. Exiba o comprimento de uma string fornecida pelo usuário.

    echo "<br>";
    $tamanho = "Arthur";

    echo "A string ". $tamanho . " tem " . strlen($tamanho) . " caracteres";

//21. Exiba a data e a hora atuais.

    echo "<br>";
    echo date("d-m-Y H:i:s");

//22. Converta uma data no formato "dd/mm/yyyy" para "yyyy-mm-dd".

    $data = date("d-m-Y");
    
    
//23. Exiba o dia da semana de uma data específica.

    echo "<br>";
    $dataH = '20-12-2004';

    $dataH = strtotime($dataH);
    $dataformatada = date('Y/m/d', $dataH);
    echo $dataformatada;

//24. Calcule a diferença de dias entre duas datas.

    echo "<br>";
    $data1 = new DateTime($data);
    $data2 = new DateTime($dataH);

    $diferenca = $data1->diff($data2);
    $dias = $diferenca->days;

    echo $dias . " Dias";

//25. Adicione 30 dias a uma data e exiba o novo valor.

    echo "<br>";

    $data30 = new DateTime('07-04-2006');
    $dias = new DateInterval('P30D');
    $data30->add($dias);

    echo $data30->format('Y-m-d');


?>