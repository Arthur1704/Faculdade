<?php

    class Grupo{

        public $pasta = "./GP_estudos/";


        public function set_Grupos($nome){

            $nomeArquivo = $this->pasta . $nome;
            $arquivo = fopen("$nomeArquivo.txt", "w");
            $data = date("d-m-Y");

            fwrite($arquivo, $data);
            fclose($arquivo);

        }

        public function get_Grupos($nome){

            $arquivos = scandir($this->pasta);
            
            foreach($arquivos as $arquivo){
                if ($arquivo == $nome){
                    return 1;
                }
            }
            return 0;
        }


    }

?>