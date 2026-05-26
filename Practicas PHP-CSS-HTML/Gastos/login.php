<?php
session_start();

$archivo_usuarios = "usuarios.txt";
$usuarios = [];
if (file_exists($archivo_usuarios)) {
    $usuarios = unserialize(file_get_contents($archivo_usuarios)) ?: [];
}

if ($_SERVER["REQUEST_METHOD"] === "POST" && isset($_POST["usuario"], $_POST["password"])) {
    $user = $_POST["usuario"];
    $pass = $_POST["password"];

    if (isset($usuarios[$user]) && $usuarios[$user]["password"] === $pass) {
        $_SESSION["usuario"]  = $user;
        $_SESSION["activo"]   = $usuarios[$user]["activo"];
        header("Location: gastos.php");
        exit;
    }
}

$_SESSION["error"] = "Usuario o contraseña incorrectos";
header("Location: index.php");
exit;
