<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Iniciar Sesión</title>
</head>
<body>
    <form action="login.php" method="post">
        <table border="0">
            <tr>
                <td><label for="usuario">Usuario:</label></td>
                <td><input type="text" id="usuario" name="usuario" required></td>
            </tr>
            <tr>
                <td><label for="password">Contraseña:</label></td>
                <td><input type="password" id="password" name="password" required></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input type="submit" value="Ingresar">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
