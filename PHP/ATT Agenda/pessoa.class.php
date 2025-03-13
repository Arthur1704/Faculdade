<?php

public class Pessoa{

    $nome;
    $idade;
    $altura;

    public static function setPessoa($nome, $idade, $altura){

        $this->nome = $nome;
        $this->idade = $idade;
        $this->altura = $altura

        $arquivo = fopen("$nome.txt", "w");

        $conteudo = "Nome: " . $nome;
        $conteudo .= "Idade: " . $idade;
        $conteudo .= "Altura: " . $altura;

        if(fwrite ($arquivo, $conteudo) === TRUE){
            return 1;
        }
        else{
            return 0;
        }
        fclose($arquivo);
        
    }


}

?>