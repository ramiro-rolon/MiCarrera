<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Saludo</title>
</head>
<body>
    <pre>
    <?php
    if(isset($_POST["nombre"])){
        $nombre = $_POST["nombre"];
    }
    else{
        $nombre = "Invitado";
    }
    ?>
    <h1>HOLA <?php echo $nombre ?></h1>
    <a href="frm.saludo.php">Volver</a>
    </pre>
</body>
</html>