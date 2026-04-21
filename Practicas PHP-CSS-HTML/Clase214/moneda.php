<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Moneda</title>
</head>
<body>
    <?php
        $lado = rand(0,1);
        if( $lado == 1){
            echo "Cara";
        }else{
            echo "Cruz";
        }
    ?>
    <hr>
    <a href="moneda.php">Tirar de nuevo</a>
</body>
</html>