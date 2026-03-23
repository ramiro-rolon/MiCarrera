create database TP_CTE;

USE TP_CTE;

CREATE TABLE Ventas (
 venta_id INT PRIMARY KEY AUTO_INCREMENT,
 cliente_id INT NOT NULL,
 fecha_venta DATE NOT NULL,
 valor DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Empleados (
 empleado_id INT PRIMARY KEY AUTO_INCREMENT,
 nombre VARCHAR(100) NOT NULL,
 departamento_id INT NOT NULL,
 fecha_contratacion DATE NOT NULL,
 salario DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Clientes (
 cliente_id INT PRIMARY KEY AUTO_INCREMENT,
 nombre VARCHAR(100) NOT NULL,
 apellido VARCHAR(100) NOT NULL
);

CREATE TABLE Departamentos (
 departamento_id INT PRIMARY KEY AUTO_INCREMENT,
 nombre_departamento VARCHAR(100) NOT NULL,
 jefe_id INT DEFAULT NULL
);

ALTER TABLE Ventas
ADD CONSTRAINT fk_cliente_id FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id);

ALTER TABLE Empleados
ADD CONSTRAINT fk_departamento_id FOREIGN KEY (departamento_id) REFERENCES
Departamentos(departamento_id);

/* Ejercicio 1 */

DELIMITER $$

CREATE FUNCTION Concatenar_NombreYApellido(nombre varchar(20), apellido varchar(20))
RETURNS varchar (41)
DETERMINISTIC
BEGIN
	DECLARE Nombre_Completo varchar (32);
    SET Nombre_Completo = Concat(nombre, ' ', apellido);
    RETURN Nombre_Completo;
END$$

DELIMITER ;

DROP FUNCTION IF EXISTS Concatenar_NombreYApellido;

SELECT Concatenar_NombreYApellido('Ramiro', 'Rolon') As NombreCompleto;

/* Ejercicio 2 */

DELIMITER $$

CREATE FUNCTION Promedio_VentasXCliente(id_cli int)
RETURNS decimal(7,2)
DETERMINISTIC
BEGIN
	DECLARE Promedio DECIMAL(7,2);
    SET Promedio = (Select avg(valor)
				   From ventas
                   Where id_cliente = id_cli);
	 RETURN Promedio;
END$$

DELIMITER ;

/* Ejercicio 3 */

DELIMITER $$

CREATE FUNCTION CalcularAntiguedad(id_emp int)
RETURNS int
DETERMINISTIC
BEGIN
	DECLARE Antiguedad int;
    SET Antiguedad = (SELECT (year(now()) - year(fecha_contratacion))
					  FROM empleados
                      WHERE empleado_id = id_emp);
    RETURN Antiguedad;
END$$

DELIMITER ;

/* Ejercicio 4 */

DELIMITER $$

CREATE FUNCTION CalcularComision(id_cli int)
RETURNS decimal(7,2)
DETERMINISTIC
BEGIN
	DECLARE Ventas_Clientes DECIMAL(7,2);
    SET Ventas_Clientes = (SELECT sum(monto)
						   FROM ventas
						   WHERE id_cliente = id_cli);
    RETURN Ventas_Clientes * 0.1;
END$$

DELIMITER ;

/* Ejercicio 5 */

DELIMITER $$

CREATE FUNCTION ObtenerJefe(depto_id int)
RETURNS varchar(25)
DETERMINISTIC
BEGIN
	DECLARE jefecito varchar(25);
    DECLARE jefecito_id int;
    SET jefecito_id = (SELECT jefe_id
					   FROM departamentos
                       WHERE departamento_id = depto_id);
	SET jefecito = (SELECT nombre
					FROM empleados
                    WHERE empleado_id = jefecito_id);
	RETURN jefecito;
END$$

DELIMITER ;

/* Ejercicio 6 */

DELIMITER $$

CREATE FUNCTION VentasPorFecha (fecha_inicial datetime, fecha_final datetime)
RETURNS int
DETERMINISTIC
BEGIN
	DECLARE ventas int;
    SET ventas = (SELECT count(venta_id)
				  FROM ventas
                  WHERE fecha_venta between fecha_inicial and fecha_final);
END$$

DELIMITER ;

/* Ejercicio 7 */

DELIMITER $$

CREATE FUNCTION SalarioPorDepto (id_emp int, id_depto int)
RETURNS DECIMAL(7,2)
DETERMINISTIC
BEGIN
	DECLARE porcentaje_final DECIMAL(7,2);
    DECLARE salario_empleado DECIMAL(7,2);
    DECLARE salarios_total_depto DECIMAL(7,2);
    SET salario_empleado = (SELECT salario
							FROM empleados
                            WHERE empleado_id = id_emp);
	SET salarios_total_depto = (SELECT sum(salario)
								FROM empleados
                                WHERE departamento_id = id_depto);
	SET porcentaje_final = (salario_total_depto / salario_empleado) * 100;
END$$

DELIMITER ;

/* Ejercicio 8 */

DELIMITER $$

-- NO SE SI ES LO QUE PIDE LA CONSIGNA

CREATE FUNCTION ClienteSinVentas(id_cli int)
RETURNS varchar(15)
DETERMINISTIC
BEGIN
	DECLARE respuesta varchar(15);
    DECLARE ventas int;
    SET ventas = (SELECT count(venta_id)
				  FROM ventas
                  WHERE cliente_id = id_cli);
    SET respuesta = IF(ventas = 0, 'No tiene ventas', 'Si tiene ventas');
    RETURN respuesta;
END$$

DELIMITER ;

-- Ejercicio 9

DELIMITER $$

CREATE FUNCTION VentasPorCliente(id_cli int)
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE ventas int;
    SET ventas = (SELECT count(venta_id)
				  FROM ventas
                  WHERE cliente_id = id_cli);
    RETURN ventas;
END$$

DELIMITER ;

-- Ejercicio 10

DELIMITER $$

CREATE FUNCTION DepartamentoPorEmpleado(id_emp int)
RETURNS varchar(20)
DETERMINISTIC
BEGIN
	DECLARE departamento varchar(20);
    SET departamento = (SELECT d.nombre_departamento
					    FROM departamentos as d INNER JOIN empleados as e
												ON e.departamento_id = d.departamento_id
                        WHERE e.empleado_id = id_emp); 
	RETURN departamento;
END$$

DELIMITER ;

-- EJERCICIOS CTE

-- Ejercicio 1

WITH VentasAltas AS
(
	SELECT *
    FROM Ventas
    WHERE valor > 1000
)

SELECT
	COUNT(venta_id) as VentasTotales, AVG(valor) as PromedioMontos
FROM
	VentasAltas;
    
-- Ejercicio 2

WITH PromedioPorDepartamento AS
(
	SELECT
		d.nombre_departamento, avg(e.salario) AS PromedioSalarios
    FROM
		departamentos AS d INNER JOIN empleados AS e
        ON d.departamento_id = e.departamento_id
    GROUP BY
		d.nombre_departamento
)

SELECT
	*
FROM
	PromedioPorDepartamento
WHERE
	PromedioSalarios > 4000;
    
-- Ejercicio 3

WITH AntiguedadEmpleados AS
(
	SELECT
		*, DATEDIFF(now(), fecha_contratacion) AS Antiguedad
    FROM
		empleados
)

SELECT
	*
FROM
	AntiguedadEmpleados
WHERE
    Antiguedad >= (5 * 365);
    
-- Ejercicio 4

WITH VentasClientes AS
(
	SELECT
		count(v.venta_id) as ventas, c.nombre, c.apellido
    FROM
		ventas as v INNER JOIN clientes as c
					ON v.cliente_id = c.cliente_id
	GROUP BY
		c.cliente_id
)

SELECT
	*
FROM
	VentasClientes
WHERE
	ventas >= 3;
    
-- Ejercicio 5

WITH SalariosOrdenados AS
(
	SELECT
		nombre, salario
    FROM
		empleados
	ORDER BY
		salarios desc
)

SELECT
	*
FROM
	SalariosOrdenados
LIMIT 10;

-- Ejercicio 6

WITH VentasPorMes AS
(
	SELECT
		sum(valor) VentasTotales, month(fecha_venta) as Mes, year(fecha_venta) as Año
    FROM
		ventas
	GROUP BY
		Mes, Año
)

SELECT
	*
FROM
	VentasPorMes
HAVING
	VentasTotales > 5000;

-- Ejercicio 8

WITH ClientesDuplicados AS
(
	SELECT
		nombre, apellido, count(nombre) as NombresRepetidos, count(apellido) ApellidosRepetidos
    FROM
		clientes
	GROUP BY
		nombre, apellido
	HAVING
		NombresRepetidos > 1 and ApellidosRepetidos > 1
)

SELECT
	nombre, apellido, NombresRepetidos
FROM
	ClientesDuplicados;
    
-- Ejercicio 9

WITH TotalVentasPorCliente AS
(
	SELECT
		nombre, apellido, sum(valor) TotalVentas
    FROM
		ventas as v INNER JOIN clientes as c
					ON c.cliente_id = v.cliente_id
	GROUP BY
		nombre, apellido
)

WITH Filtro AS
(
	SELECT
		*
    FROM
		TotalVentasPorCliente
	WHERE
		TotalVentas > 10000
)

SELECT * FROM Filtro;

-- Ejercicio 10

