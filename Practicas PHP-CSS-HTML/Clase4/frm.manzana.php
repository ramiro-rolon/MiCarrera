<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Manazana</title>
</head>
<body>
    <form action="frm.manzana.php" method="post">
        <p>
            <label for="Ancho">Ancho:</label>
            <input type="text" name="ancho" placeholder="Ingrese el ancho de la manzana">
        </p>
        <p>
            <label for="Largo">Largo:</label>
            <input type="text" name="largo" placeholder="Ingrese el largo de la manzana">
        </p>
        <input type="submit" name="Calcular valor">
    </form>
    <?php
        if(isset($_POST["ancho"]) && $_POST["ancho"] != "")
            {
                $ancho = $_POST["ancho"];
            }
        if(isset($_POST["largo"]) && $_POST["largo"] != ""){
            $largo = $_POST["largo"];
        $valor = 1200 * $ancho * $largo; ?>
    <h1>El valor de un terreno con <?=$ancho?> metros de ancho y 
    <?=$largo?> metros de largo es de US$<?=$valor?>
    </h1><?php
        }
    ?>
</body>
</html>