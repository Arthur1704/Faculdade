 <?php
 require_once 'DatabaseMysql.php';
 //require_once 'Database.php';

 $data_entrega = $_POST['data_entrega'] ?? '01-01-1900';
 $aluno = $_POST['aluno'] ?? 'aluno não informado';
 $atividade = $_POST['atividade'] ?? 'atividade não informada';
 $nota = $_POST['nota'] ?? '0.00';
 $observacoes = $_POST['observacoes'] ?? 'sem observações';






 // Criação da instância do banco e inserção dos dados
 $db = new Database();
 $sql = "INSERT INTO entrega_de_atividades (data_entrega, aluno, atividade, nota, observacoes) VALUES ( ?, ?, ?, ?, ?)";
 if ($db->executa_comando($sql, [$data_entrega,$aluno,$atividade,$nota,$observacoes])) {
   echo "<p>Dados inseridos com sucesso no banco de dados!</p>" ;
 } else {
   echo "<p>Erro ao inserir os dados no banco.</p>";
 }
 $db->desconecta_BD();
header('Location: listagem_geral.php');


?>
