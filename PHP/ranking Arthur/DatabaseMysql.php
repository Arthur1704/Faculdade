<?php
class Database {
    private $host = 'localhost';
    private $dbname = 'disciplina_web';
    private $user = 'root';
    private $senha = '';
    private $conn = null;

    // Abre a conexão com o banco
    public function conecta_BD() {
        if ($this->conn === null) {
            try {
                $this->conn = new PDO("mysql:host={$this->host};dbname={$this->dbname};charset=utf8", $this->user, $this->senha);
                $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
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

    // Executa uma query SELECT e retorna os resultados
    public function consulta($sql, $params = []) {
        $this->conecta_BD(); // Garante que a conexão esteja aberta
        $stmt = $this->conn->prepare($sql);
        $stmt->execute($params);
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    // Executa uma query de INSERT, UPDATE ou DELETE
    public function executa_comando($sql, $params = []) {
        $this->conecta_BD(); // Garante que a conexão esteja aberta
        $stmt = $this->conn->prepare($sql);
        return $stmt->execute($params);
    }
}
?>
