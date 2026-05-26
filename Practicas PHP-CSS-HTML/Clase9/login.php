<?php
session_start();

$usuarios = [
    [
        "nombre" => "admin",
        "password" => "admin",
        "activo" => 1
    ],
    [
        "nombre" => "usuario",
        "password" => "usuario",
        "activo" => 0
    ]
];

$nombre = $_POST["usuario"] ?? "";
$password = $_POST["password"] ?? "";
$valido = false;

foreach ($usuarios as $u) {
    if ($u["nombre"] === $nombre && $u["password"] === $password) {
        $valido = true;
        $_SESSION["usuario"] = $u["nombre"];
        $_SESSION["activo"] = $u["activo"];
        $_SESSION["autenticado"] = true;
        break;
    }
}

if ($valido) {
    header("Location: privada.php");
    exit;
} else {
    header("Location: index.php");
    exit;
}
