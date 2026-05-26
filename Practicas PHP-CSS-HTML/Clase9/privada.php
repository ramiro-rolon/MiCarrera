<?php require_once "patova.php"; ?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Privada</title>
</head>
<body>
    <h1>Bienvenido, <?= htmlspecialchars($_SESSION["usuario"]) ?></h1>
    <p>Estado activo: <?= $_SESSION["activo"] ? "Sí" : "No" ?></p>
    <a href="logout.php">Cerrar sesión</a>
</body>
</html>
