<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Contador</title>
</head>
<body>
    <?php  
        if(isset($_GET["n"])) {
            $n = $_GET["n"];
        }else{
            $n = 1;
        }
        $proximo = $n+1;
        $anterior = $n-1;
    ?>
    <h1>
        <?php
            echo $n;
        ?>
    </h1>
    <a href="contador.php?n=<?php echo $proximo ?>">Sumar</a>
    <a href="contador.php">Reset</a>
    <a href="contador.php?n=<?php echo $anterior ?>">Restar</a>
</body>
</html>