<?php

    class Agenda{


        public static function Busca($nome){
            $pasta = "./Agenda";
            $arquivos = scandir($pasta);
            $cont = 1;

            foreach($arquivos as $arquivo){
                if (strcmp($arquivo, $nome) == 0){
                    return $cont;                    
                }
                $cont++;
            }
            return 0;
        }

        public static function mostarAgenda():void{

            $pasta = "./Agenda/";
            $conteudoTotal = "";

            $arquivos = scandir($pasta);
            
            foreach($arquivos as $arquivo){
                if($arquivo != "." && $arquivo != ".."){
                    $arquivo = $pasta.$arquivo;
                    $arq = fopen($arquivo, "r");
                    $conteudo = fread($arq, filesize($arquivo));                
                    $conteudoTotal .= $conteudo."\n";
                    fclose($arq);
                }
                echo nl2br($conteudoTotal); 
            }
        }
    }
 
?>