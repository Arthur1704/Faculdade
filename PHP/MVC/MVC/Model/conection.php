<?php

    class Conection{
        private $url = 'localhost:3307';
        private $db_name = 'faidb';
        private $user = 'root';
        private $password = '';
        private $conn;

        public function conection_DB(){
            try{
                if ($this->conn == null){
                    $this->conn = new PDO('mysql:host=' . $this->url . '; dbname=' . $this->db_name, $this->user, $this->password);
                    $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                        
                }
            }
            catch(PDOException $e){
                echo 'Error connect: ' . $e->getMessage();
            }
        }

        public function getConn(){
            return $this->conn;
        }

        public function consulta($sql, $param = []){
            $this->conection_DB();

            $smtp = $this->conn->prepare($sql);
            $smtp->execute($param);
            return $smtp->fetchALL(PDO::FETCH_ASSOC);
        }
        
    }

?>