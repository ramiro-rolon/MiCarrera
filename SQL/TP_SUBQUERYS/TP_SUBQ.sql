create database PIPO;

use PIPO;

CREATE TABLE productos (
 id INT auto_increment PRIMARY KEY,
 nombre VARCHAR(50),
 precio double
);

CREATE TABLE clientes (
 id INT auto_increment PRIMARY KEY,
 nombre VARCHAR(50),
 correo VARCHAR(100)
);

CREATE TABLE ventas (
 id INT auto_increment PRIMARY KEY,
 producto_id INT,
 cliente_id INT,
 cantidad INT,
 total double,
 CONSTRAINT fk_producto FOREIGN KEY (producto_id) REFERENCES productos(id),
 CONSTRAINT fk_cliente FOREIGN KEY (cliente_id) REFERENCES clientes(id)
);

INSERT INTO productos (nombre, precio) VALUES ('Laptop', 1500.00);
INSERT INTO productos (nombre, precio) VALUES ('Mouse', 20.00);
INSERT INTO productos (nombre, precio) VALUES ('Teclado', 50.00);
INSERT INTO productos (nombre, precio) VALUES ('Monitor', 300.00);
INSERT INTO productos (nombre, precio) VALUES ('Impresora', 200.00);
INSERT INTO clientes (nombre, correo) VALUES ('Juan Perez', 'juan.perez@example.com');
INSERT INTO clientes (nombre, correo) VALUES ('Maria Garcia', 'maria.garcia@example.com');
INSERT INTO clientes (nombre, correo) VALUES ('Carlos Sanchez', 'carlos.sanchez@example.com');
INSERT INTO clientes (nombre, correo) VALUES ('Ana Rodriguez', 'ana.rodriguez@example.com');
INSERT INTO clientes (nombre, correo) VALUES ('Sofia Galbato', 'sofi.galbato@example.com');
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (1, 1, 2, 50.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (2, 2, 1, 30.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (3, 3, 5, 150.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (1, 4, 3, 75.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (2, 5, 4, 120.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (3, 1, 1, 30.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (1, 2, 2, 50.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (2, 3, 3, 90.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (3, 4, 2, 60.00);
INSERT INTO ventas (producto_id, cliente_id, cantidad, total) VALUES (1, 5, 1, 25.00);

-- Ejercicio 1

select nombre, precio
from productos
where precio > (select avg(precio) from productos);

-- Ejercicio 2

select c.nombre
from ventas as v inner join clientes as c on v.cliente_id = c.id
where (select count(cliente_id)
from ventas) >= 1;

select count(cliente_id)
from ventas
group by cliente_id