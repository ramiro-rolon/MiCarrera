<!DOCTYPE html>
<html lang="e">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cuotitas</title>
</head>
<body>
    <?php
    if(isset($_POST["importe"])&& $_POST["importe"]!=""){
        $importe = $_POST["importe"];
    }
    else{
        $importe = 0;
    }
    if(isset($_POST["cuotas"])&& $_POST["cuotas"]!=""){
        $cuotas = $_POST["cuotas"];
    }
    else{
        $cuotas = 1;
    }
    $valor = ceil($importe/$cuotas);
    ?>
    <h1>El valor de cada cuota es de $<?=$valor?></h1>


</body>
</html>