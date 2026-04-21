<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Temperatura</title>
</head>
<body>
    <?php
        $temperatura = $_GET ["temperatura"];
        
        if(isset ($_GET["nombre"])){
            $nombre = $_GET ["nombre"];
        }else{
            $nombre = "ROMAAAAAAAN";
        }
        if($temperatura < 15){
            echo "$nombre Hache frioo";
        }else{
            if($temperatura > 22){
                echo "$nombre hace caloor";
            }else{
                echo "$nombre ta joyita";
            }
        }

    ?>
</body>
</html>