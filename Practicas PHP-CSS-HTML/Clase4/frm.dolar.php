<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>DOLAR</title>
</head>
<body>
    <form action="frm.dolar.php" method="post">
        <p>
            <label for="pesos">Pesos:</label>
            <input type="text" name="pesos" placeholder="Ingrese los pesos a convertir">
        </p>
        <input type="submit" name="Convertir">
    </form>
    <?php
        if(isset($_POST["pesos"]) && $_POST["pesos"] != "")
            {
                $pesos = $_POST["pesos"];
                ?><h1>Lo que tiene equiale a <?php echo ceil($pesos/1420); ?></h1><?php
            }
    ?>
</body>
</html>