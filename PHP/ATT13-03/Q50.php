<?php


    $displayA = "none";
    $displayR = "none";
    $displayV = "none";
    $dados = [];
    $dadosNew = [];
    if($_SERVER['REQUEST_METHOD'] == 'POST'){
        $nome = "Tarefas.csv";

        if (isset($_POST['adicionar'])){

            $displayA = "block";

        }
        else if(isset($_POST['remover'])){

            $displayR = "block";

        }
        else if(isset($_POST['vizualizar'])){

            $displayV = "block";
            $arquivo = fopen("$nome", "r");

            if ($arquivo){
                while (($linha = fgetcsv($arquivo)) != false) {
                    $dados[] = $linha;
                }
                fclose($arquivo);
            }

        }


        if(isset($_POST['novaT'])){

            $descricao = $_POST['descricao'];
            $data = $_POST['data'];
            $prioridade = $_POST['prioridade'];


            $conteudo = array($descricao, $data, $prioridade);

            $arquivo = fopen("$nome", "a");

            if($arquivo){
                fputcsv($arquivo, $conteudo);
            }

            fclose($arquivo);

        }

        if(isset($_POST["removerT"])){

            $dadosOld = [];
            $descri = $_POST['descricao'];
            $arquivo = fopen("$nome", "r");

            if ($arquivo){
                while (($linha = fgetcsv($arquivo)) != false) {
                    $dadosOld[] = $linha;
                }
                fclose($arquivo);
            }

            $arquivoNew = fopen($nome, "w");

            foreach($dadosOld as $dado){
                if (trim($dado[0]) != $descri) { 
                    fputcsv($arquivoNew, $dado);
                }
            }
            fclose($arquivoNew);


        }
    }

?>


<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Tarefas</title>
        <style>
            #adicionar{
                display:<?php echo$displayA; ?>;
            }
            #remover{
                display:<?php echo$displayR; ?>;
            }
            #mostrar{
                display:<?php echo$displayV; ?>;
            }
            table {
                width: 25%; 
                border-collapse: collapse; 
                margin: 20px 0;
            }

            th, td {
                border: 1px solid #dddddd; 
                text-align: left; 
                padding: 8px;
            }
            
        </style>
    </head>
    <body>
        <form action="Q50.php" method="POST">
            <label>O que deseja executar</label>
            <br>
            <input type="submit" name="adicionar" value="Adicionar">
            <input type="submit" name="remover" value="Remover">
            <input type="submit" name="vizualizar" value="Vizualizar">
        </form>
        
        <div id="adicionar">
            <form action="Q50.php" method="POST">

                <label>Descrição da tarefa:<br>
                    <input type="text" name="descricao" id="desricao">
                </label>
                <br><br>
                <label>Data:<br>
                    <input type="date" name="data" id="data">
                </label>
                <br><br>
                <label>Prioridade (1 a 3):<br>
                    <input type="number" name="prioridade" id="prioridade">
                </label>    
                <br><br>
                <input type="submit" name="novaT">
            </form>
        </div>

        <div id="remover">

            <form action="Q50.php" method="POST">

                <label>Descriçao que deseja remover: <br>
                    <input type="text" name="descricao">
                    <br><br>
                    <input type="submit" name="removerT">
                </label>

            </form>
        </div>
        
        <div id="mostrar">
            <table>
                <tr>
                    <th>Descriçao</th>
                    <th>Data</th>
                    <th>Prioridade</th>
                </tr>
                <?php foreach($dados as $dado){
                echo "<tr>
                    <td>" . htmlspecialchars($dado[0]) . "</td>
                    <td>" . htmlspecialchars($dado[1]) . "</td>
                    <td>" . htmlspecialchars($dado[2]) . "</td>
                </tr>";
                }
                ?>
            </table>
        </div>
    </body>
</html>