<?php
   require_once 'conexion.php';

   $mensaje = "";
   $clase_alerta = "";

   if($_SERVER["REQUEST_METHOD"] === "POST"){
       $descripcion = trim($_POST['descripcion']);
       $monto = floatval($_POST['monto']);
       $categoria = trim($_POST['categoria']);

       if(!empty($descripcion) && isset($_POST['monto']) && !empty($categoria) && $monto > 0){
        try{
            $sql="INSERT INTO gastos (descripcion, monto, categoria) VALUES (:descripcion, :monto, :categoria)";
            $stmt = $pdo->prepare($sql);

            $stmt->execute([
                ':descripcion' => $descripcion,
                ':monto' => $monto,
                ':categoria' => $categoria
            ]);

                $mensaje = "Gasto registrado exitosamente.";
                $clase_alerta = "alert-success";    
            }
        catch(PDOException $e){
            $mensaje = "Error al cargar el gasto: " . $e->getMessage();
            $clase_alerta = "alert-danger";
        }
        }else{
            $mensaje = "Por favor, complete todos los campos obligatorios.";
            $clase_alerta = "alert-warning";
        }
   }
   else{
       $mensaje = "Error en conexion con la base de datos";
       $clase_alerta = "alert-warning";
   }

       try{
           $sql = $pdo->query("SELECT * FROM gastos ORDER BY gasto_id DESC");
           $gastos = $sql->fetchAll();
       }
       catch(PDOException $e){
           die("Error al consultar los datos: " . $e->getMessage());
       }
   
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
</head>
<body>
    <div class="container mt-5 align-items-center text-primary">
        <h1 class="text-center">Control de Gastos Personales</h1>
        <hr>
        <div>
        <?php if(!empty($mensaje)): ?>
            <?php if($clase_alerta === "alert-success"): ?>
                <div class="alert alert-success" role="alert">
                    <?php echo $mensaje; ?>
                </div>
            <?php elseif($clase_alerta === "alert-danger"): ?>
                <div class="alert alert-danger" role="alert">
                    <?php echo $mensaje; ?>
                </div>
            <?php elseif($clase_alerta === "alert-warning"): ?>
                <div class="alert alert-warning" role="alert">
                    <?php echo $mensaje; ?>
                </div>
            <?php endif; ?>
        <?php endif; ?>
        </div>
            <div class="card">
                <div class="card-header bg-primary text-white fw-bold">
                    Registrar Gasto
                </div>
                <div class="card-body">
                    <form action="index.php" method="POST" class="row g-3 align-items-center">
                        <div class="col">
                            <label for="descripcion" class="form-label">Descripcion</label>
                            <input type="text" class="form-control" id="descripcion" name="descripcion">
                        </div>
                        <div class="col">
                            <label for="categoria" class="form-label">Categoria</label>
                            <select class="form-select" aria-label="Default select example" id="categoria" name="categoria">
                                <option value="Alimentos">Alimentos</option>
                                <option value="Transporte">Transporte</option>
                                <option value="Servicios">Servicios</option>
                                <option value="Entretenimiento">Entretenimiento</option>
                                <option value="Otros">Otros</option>
                            </select>
                        </div>
                        <div class="col">
                            <label for="monto" class="form-label">Monto</label>
                            <input type="number" step="0.01" class="form-control" id="monto" name="monto">
                        </div>
                        <button class="btn btn-primary mt-3 text-center" type="submit">
                            Guardar Gasto
                        </button>
                    </form>
                </div>
            </div>
        <div>
            <div class="card mt-4">
                <div class="card-header bg-primary text-white fw-bold ">
                    Historial de Gastos
                </div>
                <div class="card-body">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Descripcion</th>
                                <th>Categoria</th>
                                <th>Monto</th>
                                <th>Fecha</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php 
                            $i = 0;
                            while($i < count($gastos)) : 
                            ?>
                                <tr>
                                    <td><?php echo $gastos[$i]['gasto_id']; ?></td>
                                    <td><?php echo htmlspecialchars($gastos[$i]['descripcion']); ?></td>
                                    <td><?php echo htmlspecialchars($gastos[$i]['categoria']); ?></td>
                                    <td>$<?php echo $gastos[$i]['monto']; ?></td>
                                    <td><?php echo $gastos[$i]['fecha']; ?></td>
                                </tr>
                            <?php 
                            $i++;
                            endwhile; ?>
                        </tbody>
                    </table>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>