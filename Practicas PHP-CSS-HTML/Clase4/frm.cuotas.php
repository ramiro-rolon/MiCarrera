<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cuotitas</title>
</head>
<body>
    <form action="acc.cuotas.php" method="post">
        <p>
            <label for="Importe">Importe:</label>
            <input type="text" name="importe" placeholder="Ingrese el importe a cobrar"></input>
        </p>
        <p>
            <label for="Cuotas">Cuotas:</label>
            <input type="text" name="cuotas" placeholder="Ingrese cantidad de cuotas"></input>
        </p>
        <input type="submit" name="Calcular cuotitas">
    </form>
</body>
</html>