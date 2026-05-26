<?php session_start(); ?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Login</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body {
            background: #0b0b0f;
            font-family: 'Segoe UI', Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            margin: 0;
        }
        .login-box {
            background: #13131a;
            padding: 40px 35px;
            border-radius: 12px;
            border: 1px solid #2a2a3a;
            box-shadow: 0 0 25px rgba(0, 255, 255, 0.08), 0 0 60px rgba(0, 255, 255, 0.03);
            width: 340px;
        }
        h1 {
            color: #0ff;
            text-align: center;
            font-size: 24px;
            margin-bottom: 25px;
            text-shadow: 0 0 8px #0ff, 0 0 20px #0ff;
            letter-spacing: 2px;
        }
        label {
            color: #aaf0ff;
            display: block;
            font-size: 13px;
            margin-bottom: 4px;
            letter-spacing: 1px;
        }
        input {
            width: 100%;
            padding: 10px 12px;
            margin-bottom: 18px;
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
            box-shadow: 0 0 10px rgba(0, 255, 255, 0.25);
        }
        button {
            width: 100%;
            padding: 11px;
            background: transparent;
            border: 1px solid #0ff;
            border-radius: 6px;
            color: #0ff;
            font-size: 15px;
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
        .error {
            color: #ff4488;
            text-align: center;
            margin-bottom: 15px;
            text-shadow: 0 0 8px #ff4488;
        }
    </style>
</head>
<body>
    <div class="login-box">
        <h1>Iniciar Sesión</h1>
        <?php if (isset($_SESSION["error"])): ?>
            <p class="error"><?= $_SESSION["error"] ?></p>
            <?php unset($_SESSION["error"]); ?>
        <?php endif; ?>
        <form method="post" action="login.php">
            <label>Usuario:</label>
            <input type="text" name="usuario" required>
            <label>Contraseña:</label>
            <input type="password" name="password" required>
            <button type="submit">Ingresar</button>
        </form>
    </div>
</body>
</html>
