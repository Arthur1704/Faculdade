<?php

    require_once 'class.grupos.php';
    class Teoria{

        public $pasta_G = "./GP_estudos/";
        public $pasta_T = "./Teorias_codigos/";
        public $grupo;

        public function __construct() {
            $this->grupo = new Grupo();
        }
            public function set_Teoria($conteudo, $grupo, $linguagem){

            $conteudo .= "\n\nData Postada: " . date("d-m-Y");

            if($this->grupo->get_Grupos($grupo) == 1){

                $arquivoG = fopen("$this->pasta_G$grupo.txt", "a");
                $arquivoT = fopen("$this->pasta_T Teoria $linguagem.txt", "a");

                if ($arquivoG === false || $arquivoT === false) {
                    echo "Erro ao abrir os arquivos para escrita.";        
                }

                if($arquivoG && $arquivoT){
                    fwrite($arquivoG, $conteudo);                    
                    fwrite($arquivoT, $conteudo);
                    fclose($arquivoG);
                    fclose($arquivoT);
                }
                else{
                    fclose($arquivoG);
                    fclose($arquivoT);
                }
            }
            else{

                $this->grupo->set_Grupos($grupo);

                $arquivoG = fopen("$this->pasta_G$grupo.txt", "w");
                $arquivoT = fopen("$this->pasta_T Teoria $linguagem.txt", "a");

                if($arquivoG && $arquivoT){
                    fwrite($arquivoG, $conteudo);                    
                    fwrite($arquivoT, $conteudo);
                    $this->cont_T++;
                    fclose($arquivoG);
                    fclose($arquivoT);

                }
                else{
                    fclose($arquivoG);
                    fclose($arquivoT);
                }
            }
        }

    }

?>
