<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulario</title>
</head>
<body>
    <h1>Cadastro!!</h1>
    <form action="{{route('cadastrar')}}" method="POST">
        @csrf
        <input type="text" name="usuarioform">
        <input type="submit">
    </form>
</body>
</html>