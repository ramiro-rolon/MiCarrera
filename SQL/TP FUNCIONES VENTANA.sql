-- =====================================================
-- TRABAJO PRÁCTICO: FUNCIONES VENTANA EN MYSQL
-- =====================================================

-- 1. CREAR BASE DE DATOS Y TABLAS
-- =====================================================

CREATE DATABASE IF NOT EXISTS tp_funciones_ventana;
USE tp_funciones_ventana;

-- Tabla de Departamentos
CREATE TABLE departamentos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100)
);

-- Tabla de Empleados
CREATE TABLE empleados (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    departamento_id INT NOT NULL,
    sueldo DECIMAL(10, 2) NOT NULL,
    fecha_ingreso DATE,
    FOREIGN KEY (departamento_id) REFERENCES departamentos(id)
);

-- Tabla de Ventas
CREATE TABLE ventas (
    id INT PRIMARY KEY AUTO_INCREMENT,
    vendedor_id INT NOT NULL,
    mes VARCHAR(20),
    cantidad INT,
    monto DECIMAL(12, 2),
    FOREIGN KEY (vendedor_id) REFERENCES empleados(id)
);

-- 2. INSERTAR DATOS
-- =====================================================

-- Departamentos
INSERT INTO departamentos (nombre, ciudad) VALUES
('Ventas', 'Buenos Aires'),
('IT', 'Buenos Aires'),
('Recursos Humanos', 'Córdoba'),
('Finanzas', 'Buenos Aires'),
('Marketing', 'Rosario');

-- Empleados
INSERT INTO empleados (nombre, apellido, departamento_id, sueldo, fecha_ingreso) VALUES
('Juan', 'Pérez', 1, 50000, '2020-01-15'),
('María', 'García', 1, 55000, '2019-06-10'),
('Carlos', 'López', 1, 48000, '2021-03-22'),
('Ana', 'Martínez', 2, 65000, '2018-11-05'),
('Pedro', 'Rodríguez', 2, 62000, '2020-02-18'),
('Laura', 'Sánchez', 2, 60000, '2021-07-12'),
('Diego', 'Fernández', 3, 45000, '2019-09-30'),
('Sofia', 'González', 4, 70000, '2018-05-14'),
('Miguel', 'Díaz', 4, 68000, '2020-08-25'),
('Emma', 'Torres', 5, 52000, '2021-01-10');

-- Ventas (registros de varios meses para análisis)
INSERT INTO ventas (vendedor_id, mes, cantidad, monto) VALUES
(1, 'Enero', 150, 15000),
(1, 'Febrero', 200, 20000),
(1, 'Marzo', 180, 18000),
(2, 'Enero', 220, 22000),
(2, 'Febrero', 210, 21000),
(2, 'Marzo', 250, 25000),
(3, 'Enero', 100, 10000),
(3, 'Febrero', 130, 13000),
(3, 'Marzo', 140, 14000),
(4, 'Enero', 300, 30000),
(4, 'Febrero', 280, 28000),
(4, 'Marzo', 320, 32000);

/*EJERCICIO 1: ROW_NUMBER
Asignar un número único a cada empleado ordenado por sueldo (descendente) dentro
de cada departamento
Utilizando la función ROW_NUMBER(), muestra un listado con:
• Nombre y apellido del empleado
• Nombre del departamento
• Sueldo del empleado
• Un número de fila único que se reinicie para cada departamento, ordenado de mayor
a menor sueldo*/

SELECT 
	concat(e.nombre, ' ', e.apellido) AS nombre_completo, d.nombre as departamento, e.sueldo, row_number()over(partition by d.id order by e.sueldo desc)
FROM
	empleados as e inner join departamentos as d on d.id = e.departamento_id;

/*EJERCICIO 2: RANK y DENSE_RANK
Comparar ranking en ventas (notar las diferencias en caso de empate)
Crea un ranking de vendedores por monto de venta, pero esta vez:
• Muestra el nombre y apellido del vendedor
• El mes de la venta
• El monto vendido
• El ranking usando RANK()
• El ranking usando DENSE_RANK()
• Agrupa por mes*/

select
	concat(e.nombre, ' ', e.apellido) as nombre_completo, v.mes as mes, v.monto as monto, rank() over(partition by v.mes order by v.monto desc), dense_rank() over(partition by v.mes order by v.monto desc)
from
	ventas as v inner join empleados as e on v.vendedor_id = e.id;

/*EJERCICIO 3: SUM() OVER - Suma Acumulada
Mostrar acumulado de ventas de cada vendedor mes a mes
Para cada vendedor y cada mes, calcula:
• Nombre y apellido del vendedor
• Mes
• Monto de la venta en ese mes
• Acumulado de ventas desde el primer mes hasta el actual (suma acumulativa)*/

select
	concat(e.nombre, ' ', e.apellido) as vendedor, v.mes, sum(v.monto) over(partition by v.vendedor_id order by v.mes rows between unbounded preceding and current row) as suma_acumulativa
from
	empleados as e inner join ventas as v on v.vendedor_id = e.id;
    
/*EJERCICIO 4: AVG() OVER - Promedio por Grupo
Calcular el promedio de sueldo por departamento mostrando cada empleado con su
respectivo promedio
Utilizando AVG() OVER(), muestra:
• Nombre y apellido del empleado
• Nombre del departamento
• Sueldo individual del empleado
• Promedio de sueldo de su departamento
Ordena por departamento y luego por sueldo (mayor a menor).*/

select
	concat(e.nombre, ' ', e.apellido) as empleado, d.nombre as departamento, e.sueldo as sueldito, avg(e.sueldo)over(partition by d.id) as promedio_sueldo
from
	departamentos as d inner join empleados as e on e.departamento_id = d.id
order by
	d.id, e.sueldo desc;

/*EJERCICIO 5: MIN/MAX OVER
Mostrar el sueldo mínimo y máximo de cada departamento junto a cada empleado
Para cada empleado, calcula:
• Nombre y apellido
• Departamento
• Sueldo del empleado
• Sueldo mínimo de su departamento
• Sueldo máximo de su departamento
Ordena por departamento y luego por sueldo descendente.*/

select
	concat(e.nombre, ' ', e.apellido) as empleado, d.nombre as departamento, e.sueldo as sueldo_empleado, min(e.sueldo) over(partition by e.departamento_id order by e.departamento_id) as Sueldo_Min_Departamento,
    max(e.sueldo) over(partition by e.departamento_id order by e.departamento_id)
from
	empleados as e inner join departamentos as d on d.id = e.departamento_id;

/*EJERCICIO 6: LEAD y LAG
Comparar ventas del mes actual con el mes anterior y siguiente
Para cada venta de cada vendedor, muestra:
• Nombre y apellido del vendedor
• Mes
• Monto vendido en el mes actual
• Monto vendido en el mes anterior (usando LAG)
• Monto vendido en el mes siguiente (usando LEAD)
• La diferencia entre el mes actual y el anterior*/

select
	concat(e.nombre, ' ', e.apellido) as empleado, v.mes as mes, v.monto, lag(v.monto)over(partition by v.vendedor_id order by v.mes) as ventas_mes_anterior,
    lead(v.monto)over(partition by v.vendedor_id order by v.mes) as mes_siguiente, sum(v.monto)over(partition by v.vendedor_id order by v.mes) - lag(v.monto)over(partition by v.vendedor_id order by v.mes)
from
	ventas as v inner join empleados as e on e.id = v.vendedor_id;

/*EJERCICIO 7: FIRST_VALUE y LAST_VALUE
Mostrar la venta más alta y más baja de cada vendedor
Para cada venta de cada vendedor, muestra:
• Nombre y apellido del vendedor
• Mes
• Monto de la venta
• La venta más alta registrada por ese vendedor
• La venta más baja registrada por ese vendedor
EJERCICIO 8: COUNT() OVER
Contar cuántos empleados hay en cada departamento
Para cada empleado, muestra:
• Nombre y apellido
• Departamento
• Cantidad de empleados en su departamento
Ordena por departamento y luego alfabéticamente por nombre.
NOTAS
• Todos los ejercicios deben ejecutarse utilizando Funciones Ventana (OVER clause)
• No está permitido usar GROUP BY para estos ejercicios (excepto si se hace en una
CTE previa)
• Los datos deben mantenerse a nivel de detalle individual (sin reducir filas)*/