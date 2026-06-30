<?php
$host = 'localhost';
$db   = 'gastos';
$user = 'root';
$pass = '';
$charset = 'utf8mb4';

// Data Source Name: define el tipo de DB, host, nombre y codificación
$dsn = "mysql:host=$host;dbname=$db;charset=$charset";

// Opciones de configuración de PDO
$options = [
    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION, // Activa el manejo de errores con excepciones
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,       // Devuelve los datos en arrays asociativos
    PDO::ATTR_EMULATE_PREPARES   => false,                  // Desactiva la emulación; usa consultas preparadas reales
];

try {
     // Creamos la instancia de la conexión
     $pdo = new PDO($dsn, $user, $pass, $options);
} catch (\PDOException $e) {
     // Si algo falla, se captura el error aquí
     throw new \PDOException($e->getMessage(), (int)$e->getCode());
}
?>