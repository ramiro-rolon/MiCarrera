<?php
require "patova.php";

$archivo = "gastos.txt";

$gastos = [];
if (file_exists($archivo)) {
    $contenido = file_get_contents($archivo);
    $gastos = unserialize($contenido) ?: [];
}

$usuario_actual = $_SESSION["usuario"];

$migrado = false;
foreach ($gastos as &$g) {
    if (!isset($g["id"])) {
        $g["id"] = uniqid();
        $migrado = true;
    }
    if (!isset($g["usuario"])) {
        $g["usuario"] = "Usuario";
        $migrado = true;
    }
}
unset($g);
if ($migrado) {
    file_put_contents($archivo, serialize($gastos));
}

if (isset($_GET["eliminar"])) {
    $id_eliminar = $_GET["eliminar"];
    $gastos = array_filter($gastos, function ($g) use ($id_eliminar, $usuario_actual) {
        return !($g["id"] === $id_eliminar && $g["usuario"] === $usuario_actual);
    });
    $gastos = array_values($gastos);
    file_put_contents($archivo, serialize($gastos));
    header("Location: gastos.php");
    exit;
}

if ($_SERVER["REQUEST_METHOD"] === "POST" && isset($_POST["concepto"], $_POST["importe"])) {
    $gastos[] = [
        "id"         => uniqid(),
        "usuario"    => $usuario_actual,
        "concepto"   => $_POST["concepto"],
        "importe"    => (float) $_POST["importe"],
        "created_at" => date("Y-m-d H:i:s")
    ];
    file_put_contents($archivo, serialize($gastos));
    header("Location: gastos.php");
    exit;
}

$gastos = array_filter($gastos, fn($g) => $g["usuario"] === $usuario_actual);
$gastos = array_reverse(array_values($gastos));
$total = array_sum(array_column($gastos, "importe"));
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Gastos</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body {
            background: #0b0b0f;
            font-family: 'Segoe UI', Arial, sans-serif;
            padding: 40px;
            color: #c0c0e0;
        }
        .top-bar {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 30px;
        }
        h1 {
            color: #0ff;
            font-size: 26px;
            text-shadow: 0 0 8px #0ff, 0 0 25px #0ff;
            letter-spacing: 2px;
        }
        a {
            color: #ff66aa;
            text-decoration: none;
            transition: 0.2s;
        }
        a:hover { text-shadow: 0 0 10px #ff66aa; }
        .logout {
            border: 1px solid #ff4488;
            padding: 7px 16px;
            border-radius: 6px;
            font-size: 13px;
            color: #ff4488;
            letter-spacing: 1px;
        }
        .logout:hover {
            background: #ff4488;
            color: #0b0b0f;
            box-shadow: 0 0 18px #ff4488;
        }
        .form-box {
            background: #13131a;
            border: 1px solid #2a2a3a;
            border-radius: 10px;
            padding: 25px 30px;
            margin-bottom: 30px;
            box-shadow: 0 0 20px rgba(0,255,255,0.05);
        }
        label {
            color: #aaf0ff;
            font-size: 13px;
            letter-spacing: 1px;
            display: inline-block;
            width: 80px;
        }
        input {
            padding: 8px 12px;
            margin-right: 10px;
            background: #1a1a26;
            border: 1px solid #2a2a4a;
            border-radius: 6px;
            color: #e0e0ff;
            font-size: 14px;
            outline: none;
            transition: 0.2s;
        }
        input:focus {
            border-color: #0ff;
            box-shadow: 0 0 10px rgba(0,255,255,0.25);
        }
        button {
            padding: 8px 20px;
            background: transparent;
            border: 1px solid #0ff;
            border-radius: 6px;
            color: #0ff;
            font-size: 14px;
            font-weight: bold;
            letter-spacing: 2px;
            cursor: pointer;
            transition: 0.2s;
            text-shadow: 0 0 6px #0ff;
        }
        button:hover {
            background: #0ff;
            color: #0b0b0f;
            box-shadow: 0 0 20px #0ff;
        }
        .section-title {
            color: #ff66aa;
            font-size: 18px;
            margin-bottom: 12px;
            text-shadow: 0 0 6px #ff66aa;
            letter-spacing: 1px;
        }
        table {
            border-collapse: collapse;
            width: 100%;
            max-width: 600px;
            background: #13131a;
            border: 1px solid #2a2a3a;
            border-radius: 10px;
            overflow: hidden;
        }
        th {
            background: #1a1a2a;
            color: #0ff;
            padding: 10px 12px;
            text-align: left;
            font-size: 13px;
            letter-spacing: 1px;
            border-bottom: 1px solid #2a2a4a;
            text-shadow: 0 0 4px #0ff;
        }
        td {
            padding: 10px 12px;
            border-bottom: 1px solid #1e1e2e;
        }
        tr:last-child td { border-bottom: none; }
        tr:hover td { background: #1a1a2a; }
        .eliminar {
            color: #ff4488;
            font-size: 13px;
        }
        .eliminar:hover { text-shadow: 0 0 10px #ff4488; }
        .total {
            margin-top: 16px;
            font-size: 18px;
            color: #0ff;
            text-shadow: 0 0 8px #0ff;
            letter-spacing: 1px;
        }
    </style>
</head>
<body>
    <div class="top-bar">
        <h1>Registro de Gastos</h1>
        <a class="logout" href="salir.php">Cerrar sesión</a>
    </div>

    <div class="form-box">
        <form method="post">
            <label>Concepto:</label>
            <input type="text" name="concepto" required>
            <label>Importe:</label>
            <input type="number" step="0.01" name="importe" required>
            <button type="submit">Grabar</button>
        </form>
    </div>

    <h2 class="section-title">Listado</h2>
    <table>
        <tr><th>Concepto</th><th>Importe</th><th>Fecha</th><th></th></tr>
        <?php foreach ($gastos as $row): ?>
        <tr>
            <td><?= htmlspecialchars($row["concepto"]) ?></td>
            <td>$<?= number_format($row["importe"], 2) ?></td>
            <td><?= $row["created_at"] ?></td>
            <td><a class="eliminar" href="?eliminar=<?= $row["id"] ?>" onclick="return confirm('¿Eliminar este gasto?')">Eliminar</a></td>
        </tr>
        <?php endforeach; ?>
    </table>
    <p class="total">Total gastado: $<?= number_format($total, 2) ?></p>
</body>
</html>
