
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Agenda</title>
    </head>
    <body>
        <div id="caixa_principal">
            <form action="index.php" method="POST">
                <label>Nome:</label><br>
                <input type="text" name="nome" size="50px" required>
                <br>
                <label>Idade:</label><br>
                <input type="number" name="idade" size="20px">
                <br>
                <label>Altura:</label><br>
                <input type="text" name="altura" size="20px">
                <br>
                <br>
                <label>Posição:</label><br>
                <input type="number" name="posi" size="20px">
                <br>
                <input type="submit" class="botoes" name="guardar" value="Guardar">
                <input type="submit" class="botoes" name="apagar" value="Apagar">
                <input type="submit" class="botoes" name="posicao" value="Posicao">
                <input type="submit" class="botoes" name="verAgenda" value="Ver Agenda">
                <input type="submit" class="botoes" name="verPessoa" value="Ver Pessoa">
            </form>
        </div>
    </body>
</html>

<?php
    include_once 'ClassAgenda.php';
    include_once 'ClassPessoa.php'; 

    $pessoa = new Pessoa();
    $agenda = new Agenda();

   if(isset($_POST['guardar'])){

        $nome = $_POST['nome'];
        $idade = $_POST['idade'];
        $altura = $_POST['altura'];

        $pessoa->setPessoa($nome, $idade, $altura);

    }
    else if (isset($_POST['apagar'])){
        $nome = $_POST['nome'];

        $pessoa->Apagar($nome);
    }
    else if (isset($_POST['posicao'])){
        $nome = $_POST['nome'];
        $retorno = $agenda->Busca($nome);
        if($retorno == 0){
            echo "<script>alert('$nome não foi achado na agenda!!')</script>";
        }else{
            echo "<script>alert('$nome está na posição $retorno!!')</script>";
        }
    }
    else if(isset($_POST['verAgenda'])){
        $agenda->mostarAgenda();
    }
    else if(isset($_POST['verPessoa'])){
        $posiP = $_POST['posi'];
        $pessoa->verPessoa($posiP);
    }
?>