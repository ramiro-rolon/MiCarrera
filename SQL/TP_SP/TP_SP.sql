CREATE DATABASE TP_SP;

USE TP_SP;

-- Crear las tablas
CREATE TABLE clientes (
 id_cliente INT AUTO_INCREMENT PRIMARY KEY,
 nombre VARCHAR(100) NOT NULL,
 saldo DECIMAL(10,2) NOT NULL
);

CREATE TABLE compras (
 id_compra INT AUTO_INCREMENT PRIMARY KEY,
 id_cliente INT,
 fecha DATE,
 monto DECIMAL(10,2),
 FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);
-- Insertar algunos registros de muestra
INSERT INTO clientes (nombre, saldo) VALUES
('Juan Pérez', 1000),
('María López', 500),
('Pedro Gómez', 2000);

INSERT INTO compras (id_cliente, fecha, monto) VALUES
(1, '2023-11-01', 100),
(2, '2023-11-05', 250);

-- Ejercicio 1

DELIMITER $$

CREATE PROCEDURE insertar_cliente (IN p_nombre VARCHAR(100), IN p_saldo DECIMAL(7,2))
	INSERT INTO clientes (nombre, saldo) VALUES
    (p_nombre, p_saldo);
END $$

DELIMITER ;

CALL insertar_cliente('Ramiro Rolon', 2500);

SELECT * FROM clientes;

-- Ejercicio 2

DELIMITER $$

CREATE PROCEDURE cambiar_nombre (IN p_id_cliente INT, IN p_nombre_nuevo VARCHAR(100))
	UPDATE clientes
    SET nombre = p_nombre_nuevo
    WHERE id_cliente = p_id_cliente;
END $$

DELIMITER ;

CALL cambiar_nombre (1, 'Santiago Fernandez Espinosa');

-- Ejercicio 3

DELIMITER $$

CREATE PROCEDURE eliminar_cliente (IN p_id_cliente INT)
BEGIN
	DELETE FROM clientes WHERE id_cliente = p_id_cliente;
END$$

DELIMITER ;

DROP PROCEDURE eliminar_cliente;

CALL eliminar_cliente(3);

SELECT * FROM clientes;

-- Ejercicio 4

DELIMITER $$

CREATE PROCEDURE consultar_saldo (IN p_id_cliente INT, OUT p_saldo DECIMAL(7,2))
BEGIN
	SELECT saldo INTO p_saldo
    FROM clientes
    WHERE id_cliente = p_id_cliente;
END$$

DELIMITER ; 

SET @saldo = 0;
CALL consultar_saldo(4, @saldo);
SELECT @saldo;

-- Ejercicio 5

DELIMITER $$



DELIMITER ;