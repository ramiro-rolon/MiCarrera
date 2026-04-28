<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Manzana</title>
</head>
<body>
    <?php
        if(isset($_POST["ancho"]) && $_POST["ancho"] != "")
            {
                $ancho = $_POST["ancho"];
            }
            else{
                $ancho = 1;
            }
        if(isset($_POST["largo"]) && $_POST["largo"] != ""){
            $largo = $_POST["largo"];
        }else{
            $largo = 1;
        }

        $valor = 1200 * $ancho * $largo;
    ?>
    <h1>El valor de un terreno con <?=$ancho?> metros de ancho y 
    <?=$largo?> metros de largo es de US$<?=$valor?>
    </h1>
</body>
</html>