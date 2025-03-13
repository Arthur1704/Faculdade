<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Carta</title>
        <link rel="stylesheet" type="text/css" href="css.css">
    </head>
    <body>
        <nav>
            <h1>Redigir carta</h1>
            <div id="direcionadores_nav">
                <ul>
                    <li><a href="">Criar uma carta</a></li>
                    <li><a href="CartasCriadas.php">Ver cartas feitas</a></li>
                </ul>
            </div>
        </nav>
        <div id="caixa_principal">
            <form id="form" action="GeraCarta.php" method="POST">
                <h2>INFORMAÇOES DA CARTA</h2><br>
                <label for="nome_remetente">Nome Rementente: </label><br>
                <input type="text" name="nome_remetente" id="nome_remetente" required>
                <br>
                <label for="nome_destinatario">Nome Destinatario:</label><br>
                <input type="text" name="nome_destinatario" id="nome_destinatario" required>
                <br>
                <label for="endereco_remetente">Endereço Remetente:</label><br>
                <input type="text" name="endereco_remetente" id="endereco_remetente" required>
                <br>
                <label for="num_remetente">Numero Remetente:</label><br>
                <input type="number" name="num_remetente" id="num_remetente" required>
                <br>
                <label for="endereco_destinatario">Endereço Destinatario:</label><br>
                <input type="text" name="endereco_destinatario" id="endereco_destinatario" required>
                <br>
                <label for="num_destinatario">Numero Remetente:</label><br>
                <input type="number" name="num_destinatario" id="num_destinatario" required>
                <br>
                <label for="data">Data:</label><br>
                <input type="date" name="data" id="data" required>
                <br>
                <label for="assunto">Assunto:</label><br>
                <textarea name="assunto" id="assunto" required placeholder="Assunto da carta..."></textarea>
                <br>
                <label for="conteudo">Conteudo:</label><br>
                <textarea name="conteudo" id="conteudo" required placeholder="Conteudo da carta..."></textarea>
                <br>
                <input type="submit" name="submit" id="submit">
            </form>
        </div>
    </body>
</html>