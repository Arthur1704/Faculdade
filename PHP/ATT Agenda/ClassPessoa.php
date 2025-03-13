<?php

class Pessoa{

    public $contador = 0;


    public function setPessoa($nome, $idade, $altura):void{
        $pasta = "./Agenda";
        $arquivo = fopen("$pasta/$nome.txt", "w");

        $conteudo = "Nome: " . $nome;
        $conteudo .= "\nIdade: " . $idade;
        $conteudo .= "\nAltura: " . $altura;
        if ($this->contador <= 10){
            if ($arquivo){
                fwrite($arquivo, $conteudo);
                fclose($arquivo);
                $this->contador++;
                echo "<script>alert('Arquivo Criado com sucesso!!')</script>";
            }
            else{
                echo "<script>alert('Arquivo não foi criado!!')</script>";
            }
        }
    }

    public static function Apagar($nome){
        $arquivo = "./Agenda/$nome.txt";

        if (file_exists($arquivo)){ 
            unlink($arquivo);
            echo "<script>alert('Arquivo apagado com Sucesso!!')</script>";
        }
        else{
            echo "<script>alert('Não foi possivel apagar o arquivo !!')</script>";
        }
    }

    public function verPessoa($posi):void{
        $posi = $posi+2;
        $pasta = "./Agenda/";
        
        $arquivos = scandir($pasta);

        $valido = false;
        $arquivo = $arquivos[$posi];

        $aberto = fopen($pasta.$arquivo, "r");
        if ($aberto){
            $conteudo = fread($aberto, filesize($pasta . $arquivo));
            fclose($aberto);
            $valido = true;
            $mostrar = nl2br($conteudo);
            echo $mostrar;
        }
        if (!$valido){
            echo "<script>alert('Posição nao é valida')</script>";
        }

    }
}

?>