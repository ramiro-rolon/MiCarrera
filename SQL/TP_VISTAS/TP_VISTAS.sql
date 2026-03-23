CREATE DATABASE Tp_Listas_e_Interfaces;

USE Tp_Listas_e_Interfaces;

-- Tabla Clientes
CREATE TABLE Clientes (
    cliente_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    ciudad VARCHAR(50),
    email VARCHAR(50)
);

-- Tabla Productos
CREATE TABLE Productos (
    producto_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_producto VARCHAR(50),
    categoria VARCHAR(50),
    precio DECIMAL(10, 2)
);

-- Tabla Pedidos
CREATE TABLE Pedidos (
    pedido_id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT,
    fecha_pedido DATE,
    FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id)
);

-- Tabla Detalle_Pedido
CREATE TABLE Detalle_Pedido (
    detalle_id INT AUTO_INCREMENT PRIMARY KEY,
    pedido_id INT,
    producto_id INT,
    cantidad INT,
    FOREIGN KEY (pedido_id) REFERENCES Pedidos(pedido_id),
    FOREIGN KEY (producto_id) REFERENCES Productos(producto_id)
);

-- Insertar registros en Clientes
INSERT INTO Clientes (cliente_id, nombre, apellido, ciudad, email) VALUES
(1, 'Ana', 'García', 'Madrid', 'ana.garcia@email.com'),
(2, 'Juan', 'Pérez', 'Barcelona', 'juan.perez@email.com'),
(3, 'María', 'López', 'Madrid', 'maria.lopez@email.com'),
(4, 'Carlos', 'Ruiz', 'Valencia', 'carlos.ruiz@email.com');

-- Insertar registros en Productos
INSERT INTO Productos (producto_id, nombre_producto, categoria, precio) VALUES
(1, 'Laptop', 'Electrónicos', 1200.00),
(2, 'Tablet', 'Electrónicos', 300.00),
(3, 'Libro', 'Libros', 25.00),
(4, 'Smartphone', 'Electrónicos', 800.00);

-- Insertar registros en Pedidos
INSERT INTO Pedidos (pedido_id, cliente_id, fecha_pedido) VALUES
(1, 1, '2023-10-26'),
(2, 1, '2023-11-10'),
(3, 2, '2023-11-05'),
(4, 3, '2023-10-28'),
(5, 4, '2023-11-15');

-- Insertar registros en Detalle_Pedido
INSERT INTO Detalle_Pedido (detalle_id, pedido_id, producto_id, cantidad) VALUES
(1, 1, 1, 1),
(2, 1, 2, 2),
(3, 2, 4, 1),
(4, 3, 3, 3),
(5, 4, 1, 1),
(6, 5, 2, 2),
(7, 5, 4, 1);



-- Ejercicio 1

CREATE OR REPLACE VIEW clientes_por_ciudad AS
SELECT c.nombre, c.apellido, c.email, c.ciudad
FROM clientes as c
WHERE c.ciudad = 'Madrid'
WITH CHECK OPTION;

SELECT *
FROM clientes_por_ciudad;

-- Ejercicio 2

CREATE OR REPLACE VIEW resumen_ventas_categoria AS
SELECT p.categoria, sum(dp.cantidad)
FROM productos AS p INNER JOIN
detalle_pedido AS dp ON p.producto_id = dp.producto_id
GROUP BY p.categoria;

select *
from resumen_ventas_categoria;

-- Ejercicio 3

CREATE OR REPLACE VIEW clientes_total_pedidos AS
SELECT c.nombre, c.apellido, count(p.cliente_id)
FROM clientes as c INNER JOIN
pedidos as p ON p.cliente_id = c.cliente_id
GROUP BY c.nombre, c.apellido;

SELECT *
From clientes_total_pedidos;

-- Ejercicio 4

CREATE OR REPLACE VIEW productos_mas_vendidos_ciudad AS
SELECT c.ciudad, p.nombre_producto, sum(dp.cantidad) as cantidad
FROM clientes as c
INNER JOIN pedidos as p2 ON c.cliente_id = p2.cliente_id
INNER JOIN detalle_pedido as dp ON dp.pedido_id = p2.pedido_id
INNER JOIN productos as p ON p.producto_id = dp.producto_id
GROUP BY c.ciudad, p.nombre_producto;

select *
from productos_mas_vendidos_ciudad as j
order by j.cantidad;

-- Ejercicio 5

CREATE OR REPLACE VIEW ingresos_por_mes AS
SELECT date_format(pe.fecha_pedido, '%y-%m') as mes, sum(pr.precio) as recaudado
FROM productos as pr
INNER JOIN detalle_pedido as dp ON pr.producto_id = dp.producto_id
INNER JOIN pedidos as pe ON dp.pedido_id = pe.pedido_id
GROUP BY mes;

select *
from ingresos_por_mes;

-- Ejercicio 6

CREATE OR REPLACE VIEW productos_electronicos as
SELECT pr.producto_id, pr.categoria, pr.nombre_producto
FROM productos as pr
WHERE pr.categoria = 'Electronicos';

select *
from productos_electronicos;

CREATE OR REPLACE VIEW ventas_electronicos as
SELECT pe.nombre_producto, sum(dp.cantidad)
FROM productos_electronicos as pe
INNER JOIN detalle_pedido as dp ON pe.producto_id = dp.producto_id
GROUP BY pe.nombre_producto
WITH LOCAL CHECK OPTION; -- claramente te tira el error xd

-- Ejercicio 7

CREATE OR REPLACE VIEW ventas_electronicos as
SELECT pe.nombre_producto, sum(dp.cantidad) as total_vendido
FROM productos_electronicos as pe
INNER JOIN detalle_pedido as dp ON pe.producto_id = dp.producto_id
GROUP BY pe.nombre_producto;
-- Si lo hago con cascaded option check igual me tira el error
select *
from ventas_electronicos;

-- ejercicio 8

CREATE OR REPLACE VIEW clientes_productos_favoritos as
SELECT c.nombre, c.apellido, pr.nombre_producto, sum(dp.cantidad) as cantidad
FROM clientes as c INNER JOIN pedidos as pe ON c.cliente_id = pe.cliente_id
INNER JOIN detalle_pedido as dp ON dp.pedido_id = pe.pedido_id
INNER JOIN productos as pr ON pr.producto_id = dp.producto_id
GROUP BY c.nombre, c.apellido, pr.nombre_producto
ORDER BY cantidad;

select *
from clientes_productos_favoritos;

SELECT cpf.nombre, cpf.apellido, cpf.nombre_producto, max(cpf.cantidad)
from clientes_productos_favoritos as cpf
group by cpf.nombre, cpf.apellido;

-- Ejercicio 9.1

CREATE OR REPLACE VIEW clientes_pedidos_recientes As
SELECT c.nombre, c.apellido, max(p.fecha_pedido) as fecha_ultimo_pedido
FROM clientes as c INNER JOIN pedidos as p ON c.cliente_id = p.cliente_id
GROUP BY c.nombre, c.apellido;

select *
from clientes_pedidos_recientes;

SELECT max(fecha_ultimo_pedido)
FROM clientes_pedidos_recientes;

-- Ejercicio 9.2

CREATE OR REPLACE VIEW clientes_pedidos_recientes_2 As
SELECT c.nombre, c.apellido, max(p.fecha_pedido) as fecha_ultimo_pedido, pr.nombre_producto
FROM clientes as c INNER JOIN pedidos as p ON c.cliente_id = p.cliente_id
INNER JOIN detalle_pedido as dp ON p.pedido_id = dp.pedido_id
INNER JOIN productos as pr ON pr.producto_id = dp.producto_id
GROUP BY c.nombre, c.apellido;

select  *
from clientes_pedidos_recientes_2;

-- Ejercicio 10

CREATE INDEX IX_Clientes_Ciudad ON Clientes(ciudad);

SELECT *
FROM clientes
WHERE clientes.ciudad = 'Madrid';

-- Ejercicio 11 

