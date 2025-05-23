 <?php
 class Database {
   private $host = 'localhost';
   private $dbname = 'nome_do_banco';
   private $user = 'usuario';
   private $pass = 'senha';
   private $conn = null;
   public function conecta_BD() {   // Abre a conexão com o banco
       if ($this->conn === null) {
           try {
               $this->conn = new PDO(
                   "mysql:host={$this->host};dbname={$this->dbname};charset=utf8" ,$this->user,$this->pass );
           } catch (PDOException $e) {
               die("Erro de conexão: " . $e->getMessage());
           }
       }
       return $this->conn;
   }
   // Fecha a conexão com o banco
   public function desconecta_BD() {
       $this->conn = null;
   }
      public function consulta($sql, $params = []) { // Executa uma query SELECT e retorna os resultados
       $this->conecta_BD(); // Garante que a conexão está ativa
       $stmt = $this->conn->prepare($sql);
       $stmt->execute($params);
       return $stmt->fetchAll(PDO::FETCH_ASSOC);
   }
   public function executa_comando( $sql, $params = []) {   // Executa uma query de INSERT, UPDATE ou DELETE
       $this->conecta_BD(); // Garante que a conexão está ativa
       $stmt = $this->conn->prepare($sql);
       return $stmt->execute($params);
   }
 }
 ?