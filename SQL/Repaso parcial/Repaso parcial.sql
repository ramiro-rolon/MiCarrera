-- Crear base de datos
CREATE DATABASE IF NOT EXISTS biblioteca;
USE biblioteca;

-- Tabla autores
CREATE TABLE autores (
    id_autor INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    nacionalidad VARCHAR(50)
);

-- Tabla libros
CREATE TABLE libros (
    id_libro INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    isbn VARCHAR(20),
    genero VARCHAR(50),
    precio DECIMAL(10,2),
    stock INT NOT NULL DEFAULT 0,
    estado ENUM('disponible', 'no disponible') DEFAULT 'disponible',
    id_autor INT,
    año_publicacion INT,
    FOREIGN KEY (id_autor) REFERENCES autores(id_autor)
);

-- Tabla socios
CREATE TABLE socios (
    id_socio INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE,
    categoria ENUM('estudiante', 'docente', 'general') NOT NULL,
    estado ENUM('activo', 'inactivo') DEFAULT 'activo'
);

-- Tabla préstamos
CREATE TABLE prestamos (
    id_prestamo INT AUTO_INCREMENT PRIMARY KEY,
    id_socio INT NOT NULL,
    id_libro INT NOT NULL,
    fecha_prestamo DATE NOT NULL,
    fecha_devolucion_esperada DATE NOT NULL,
    fecha_devolucion_real DATE NULL,
    estado ENUM('activo', 'devuelto', 'vencido') DEFAULT 'activo',
    multa DECIMAL(10,2) DEFAULT 0,
    FOREIGN KEY (id_socio) REFERENCES socios(id_socio),
    FOREIGN KEY (id_libro) REFERENCES libros(id_libro)
);

-- Tabla para logs de actividades
CREATE TABLE log_actividades (
    id_log INT AUTO_INCREMENT PRIMARY KEY,
    tabla_afectada VARCHAR(50),
    operacion VARCHAR(50),
    id_registro INT,
    usuario VARCHAR(50),
    fecha_operacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Insertar datos de ejemplo en autores
INSERT INTO autores (nombre, apellido, nacionalidad) VALUES
('Gabriel', 'García Márquez', 'Colombiano'),
('Julio', 'Cortázar', 'Argentino'),
('Isabel', 'Allende', 'Chilena'),
('Jorge', 'Luis Borges', 'Argentino'),
('Mario', 'Vargas Llosa', 'Peruano'),
('Laura', 'Esquivel', 'Mexicana');

-- Insertar datos de ejemplo en libros
INSERT INTO libros (titulo, isbn, genero, precio, stock, estado, id_autor, año_publicacion) VALUES
('Cien años de soledad', '978-8437604947', 'Realismo mágico', 15.00, 5, 'disponible', 1, 1967),
('Rayuela', '978-8437604954', 'Literatura contemporánea', 12.50, 3, 'disponible', 2, 1963),
('La casa de los espíritus', '978-8437604961', 'Realismo mágico', 14.00, 4, 'disponible', 3, 1982),
('Ficciones', '978-8437604978', 'Ficción', 10.00, 2, 'disponible', 4, 1944),
('La ciudad y los perros', '978-8437604985', 'Literatura contemporánea', 13.00, 3, 'disponible', 5, 1962),
('Como agua para chocolate', '978-8437604992', 'Realismo mágico', 11.50, 6, 'disponible', 6, 1989),
('El amor en los tiempos del cólera', '978-8437605005', 'Realismo mágico', 16.00, 2, 'no disponible', 1, 1985);

-- Insertar datos de ejemplo en socios
INSERT INTO socios (nombre, apellido, email, categoria, estado) VALUES
('Juan', 'Pérez', 'juan@email.com', 'estudiante', 'activo'),
('María', 'Gómez', 'maria@email.com', 'docente', 'activo'),
('Carlos', 'López', 'carlos@email.com', 'general', 'activo'),
('Ana', 'Martínez', 'ana@email.com', 'estudiante', 'activo'),
('Pedro', 'Rodríguez', 'pedro@email.com', 'docente', 'inactivo'),
('Lucía', 'Fernández', 'lucia@email.com', 'general', 'activo');

-- Insertar datos de ejemplo en préstamos
INSERT INTO prestamos (id_socio, id_libro, fecha_prestamo, fecha_devolucion_esperada, fecha_devolucion_real, estado, multa) VALUES
(1, 1, '2024-01-10', '2024-01-24', '2024-01-22', 'devuelto', 0),
(2, 2, '2024-01-12', '2024-01-26', NULL, 'activo', 0),
(3, 3, '2024-01-15', '2024-01-29', '2024-02-01', 'devuelto', 0),
(1, 4, '2024-01-18', '2024-02-01', NULL, 'activo', 0),
(4, 5, '2024-01-20', '2024-02-03', NULL, 'vencido', 0),
(2, 6, '2024-01-22', '2024-02-05', '2024-02-04', 'devuelto', 0),
(3, 1, '2024-01-25', '2024-02-08', NULL, 'activo', 0);
/* EJERCICIO CTE 1
Crear una CTE que muestre los libros con su información completa y el nombre completo de su
autor, luego filtrar para mostrar solo los libros del género "Realismo mágico" ordenados por año de
publicación. */

with CTE_1 AS(
	select 
		l.titulo as titulo, l.isbn as isbn, l.genero as genero, l.precio as precio, l.stock as stock,
        l.estado as estado, l.año_publicacion as año_publicacion, concat(a.nombre, ' ', a.apellido) as autor
    from
		libros as l 
        inner join autores as a on l.id_autor = a.id_autor
)

select 
	*
from
	CTE_1
where
	genero = 'Realismo magico'
order by
	año_publicacion;
    
/*EJERCICIO CTE 2
Crear una CTE que calcule estadísticas de préstamos por socio, mostrando el nombre
completo, categoría, total de préstamos, préstamos activos, devueltos y vencidos.*/

with CTE_2 as(
	select 
		concat(s.nombre, ' ', s.apellido) as socio, s.categoria as categoria, count(p.id_socio) as Cant_prestamos,
        sum(p.estado = 'Activo') as Prestamos_activos, sum(p.estado = 'Devuelto') as Prestamos_Devueltos,
        sum(p.estado = 'Vencido') as Prestamos_Vencidos
    from
		socios as s
        inner join prestamos as p on s.id_socio = p.id_socio
	group by
		socio
)

select * from CTE_2;

/*EJERCICIO VISTA 1
Crear una vista llamada 'vista_libros_autores' que muestre la información básica de los libros
junto con los datos de sus autores. Luego, usar la vista para mostrar solo los libros de
"Realismo mágico".*/

create or replace view vista_libros_autores as(
	select
		l.titulo as titulo, l.isbn as isbn, l.genero as genero, l.precio as precio, l.stock as stock,
        l.estado as estado, l.año_publicacion as año_publicacion, concat(a.nombre, ' ', a.apellido) as autor
    from
		libros as l 
        inner join autores as a on l.id_autor = a.id_autor
);

select
	*
from
	vista_libros_autores
where
	genero = 'Realismo Magico';
    
/* EJERCICIO VISTA 2
Crear una vista llamada 'vista_estadisticas_socios' que muestre para cada socio:
• Información personal (nombre completo, email, categoría, estado)
• Estadísticas de préstamos (totales, activos, devueltos, vencidos)
• Monto total de multas acumuladas
Luego, usar esta vista para generar un reporte que muestre únicamente los socios que
tienen préstamos vencidos o más de 2 préstamos activos.
*/

CREATE OR REPLACE VIEW vista_estadisticas_socios AS(
	select
		concat(s.nombre, ' ', s.apellido) as socio, s.email as email, s.categoria as categoria, s.estado as estado,
        count(p.id_socio) as CantidadPrestamos, sum(p.estado = 'Activo') as PrestamosActivos, sum(p.estado = 'Devuelto') as PrestamosDevueltos,
        sum(p.estado = 'Vencido') as PrestamosVencidos, sum(p.multa) as AcumulacionMultas, s.id_socio AS id_socio
    from
		socios as s
        inner join prestamos as p on s.id_socio = p.id_socio
	group by
		socio
);

SELECT * FROM vista_estadisticas_socios;

/*EJERCICIO UDF 1
Crear una función llamada 'calcular_multa' que:
• Reciba como parámetros: días de retraso y categoría del socio
• Retorne el monto de la multa según estas reglas:
o Estudiantes: $10 por día
o Docentes: $15 por día
o General: $20 por día
o Si los días de retraso son <= 0, retornar 0*/

DELIMITER $$

CREATE FUNCTION calcular_multa(p_retraso int, p_categoria varchar(15))
RETURNS DECIMAL(7,2)
DETERMINISTIC
BEGIN
	DECLARE MULTA DECIMAL(7,2);
	CASE (p_categoria)
		WHEN 'Estudiante'
		THEN SET MULTA = p_retraso * 10;
        WHEN 'Docente'
        THEN SET MULTA = p_retraso * 15;
        WHEN 'General'
        THEN SET MULTA = p_retraso * 20;
	END CASE;
    RETURN MULTA;
END$$

DELIMITER ;

drop function if exists calcular_multa;

SELECT CALCULAR_MULTA(54, 'General');

/*EJERCICIO UDF 2
Crear una función llamada 'obtener_info_socio' que:
- Reciba un ID de socio
- Retorne un texto descriptivo con: "Nombre Apellido (Categoría):
 X préstamos activos, Y préstamos totales, $Z en multas”
- Si el socio no existe, retornar "Socio no encontrado"
- Debe usar la vista_estadisticas_socios creada anteriormente
*/

DELIMITER $$

CREATE FUNCTION obtener_info_socio(p_id int)
RETURNS VARCHAR(200)
DETERMINISTIC
BEGIN
	DECLARE v_respuesta VARCHAR(200);
    DECLARE v_nombre_completo VARCHAR(20);
    DECLARE v_categoria VARCHAR(15);
    DECLARE v_prestamos INT;
    DECLARE v_activos INT;
    DECLARE v_multas DECIMAL(7,2);
	
    SELECT socio, categoria, prestamosActivos, cantidadPrestamos, acumulacionMultas
    INTO v_nombre_completo, v_categoria, v_activos, v_prestamos, v_multas
    FROM vista_estadisticas_socios
    WHERE id_socio = p_id;
    
    if v_nombre_completo is null then
		return 'Socio no encontrado';
	end if;
    
    SET v_respuesta = concat(v_nombre_completo, ' (', v_categoria, '): ', v_activos, ' prestamos activos,', v_prestamos, ' prestamos totales, ',
						   '$', v_multas, ' Totales en multas');
    RETURN v_respuesta;
END$$

DELIMITER ;

DROP FUNCTION OBTENER_INFO_SOCIO;

select obtener_info_socio(3);

/*
EJERCICIO TRIGGER 1
Crear un trigger llamado 'log_cambios_libros' que:
• Se active DESPUÉS de cualquier UPDATE en la tabla libros
• Registre en la tabla log_actividades: nombre de la tabla afectada, tipo de operación,
ID del registro modificado
• Guarde información básica: usuario que realizó la operación y fecha/hora de la
operación
*/

DELIMITER $$

CREATE TRIGGER log_cambios_libros
AFTER UPDATE
ON libros
FOR EACH ROW
BEGIN
	DECLARE id_socio INT;
    SET id_socio = (SELECT
						id_socio
					FROM
						prestamos
					WHERE
						id_libro = old.id_libro
					ORDER BY
						fecha_prestamo desc
					LIMIT
						1);
	INSERT INTO log_actividades(tabla_afectada, operacion, id_registro, usuario, fecha_operacion) VALUES
    ('Libros', 'Update', OLD.id_libro, id_socio, now());
END$$


DELIMITER ;


INSERT INTO prestamos(id_socio, id_libro, fecha_prestamo, fecha_devolucion_esperada, fecha_devolucion_real, estado, multa)VALUES
(1, 1, now(), '18/11/2025', null, 'activo', 0);
UPDATE libros SET estado = 'No disponible' WHERE id_libro = 1;

select * from log_actividades;

/*
EJERCICIO TRIGGER 2
Crear un trigger llamado 'controlar_stock_prestamo' que:
• Se active ANTES de INSERT en la tabla prestamos
• Verifique que haya stock disponible del libro solicitado (stock > 0)
• Si no hay stock, genere un error personalizado con SIGNAL
• Registre el intento de préstamo sin stock en la tabla log_actividades
*/

DELIMITER $$

CREATE TRIGGER controlar_stock_prestamo
BEFORE INSERT
ON prestamos
FOR EACH ROW
BEGIN
	DECLARE v_stock INT;
    SET v_stock = (SELECT stock FROM libros WHERE id_libro = NEW.id_libro);
    IF v_stock <= 0 THEN
        INSERT INTO log_actividades(tabla_afectada, operacion, id_registro, usuario, fecha_operacion)VALUES
        ('Prestamos', 'Insert', 2, 'Socio', now());
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Stock insuficiente';
    END IF;
END$$

DELIMITER ;

DROP TRIGGER IF EXISTS controlar_stock_prestamo;

UPDATE libros
SET stock = 0 WHERE id_libro = 1;

INSERT INTO prestamos(id_socio, id_libro, fecha_devolucion_esperada, fecha_devolucion_real, estado, multa)VALUES
(1, 1, '12/12/2025', 10/12/2025, 'activo', 0);

SELECT STOCK FROM LIBROS WHERE ID_LIBRO = 1;

SELECT * FROM log_actividades;


/*EJERCICIO SP 1 (HANDLERS)
Crear un stored procedure llamado 'registrar_nuevo_socio' que reciba los datos de un nuevo
socio e intente insertarlo.
- Debe manejar errores con HANDLERS para:
- Duplicados de email (código 1062)
- Errores SQL generales
- Retornar mensaje de éxito o error correspondiente
*/

DELIMITER $$

CREATE PROCEDURE registrar_nuevo_socio(IN p_nombre VARCHAR(20), IN p_apellido VARCHAR(20), IN p_email VARCHAR(20), IN p_categoria VARCHAR(10),
									   IN p_estado VARCHAR(10))
BEGIN
	DECLARE error_codigo INT DEFAULT 0;
    DECLARE verificacion INT;
	DECLARE EXIT HANDLER FOR SQLSTATE '45001'
    BEGIN
        SELECT 'Error 1602, ya existe un usuario con ese mail' AS resultado;
    END;
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
		SET error_codigo = 1;
        SELECT 'Error al cargar el usuario' AS resultado;
    END;
    SET verificacion = (SELECT COUNT(id_socio) FROM socios WHERE email = p_email);
    IF verificacion > 0 THEN
		SIGNAL SQLSTATE '45001'
        SET MESSAGE_TEXT = 'Existe un usuario con ese email';
    END IF;
    INSERT INTO socios(nombre, apellido, email, categoria, estado)VALUES
    (p_nombre, p_apellido, p_email, p_categoria, p_estado);
    
    IF error_codigo = 0 THEN
		SELECT 'Insercion exitosa' AS resultado;
    END IF;
    
END$$

DELIMITER ;

drop procedure if exists registrar_nuevo_socio;

CALL registrar_nuevo_socio('Ramiro', 'Rolon', 'ramirorolon@gmail.com', 'estudiante', 'activo');

/*EJERCICIO SP 2 (SIGNAL + HANDLERS)
Crear un stored procedure llamado 'procesar_devolucion' que reciba un ID de préstamo y
procese su devolución.
• Validar que el préstamo existe y está activo
• Calcular multa automáticamente si hay retraso usando la función UDF
• Actualizar el préstamo a estado 'devuelto'*/

DELIMITER $$

CREATE PROCEDURE procesar_devolucion (IN p_id INT)
BEGIN
	DECLARE estado_prestamo VARCHAR(20);
    DECLARE dias_vencidos INT;
    DECLARE categoria_socio VARCHAR(10);
    DECLARE EXIT HANDLER FOR SQLSTATE '45000'
    BEGIN
		SELECT 'Pues como la ves ya estaba devuelto chamaquito' AS Resultado;
    END;
    DECLARE EXIT HANDLER FOR SQLSTATE '45001'
    BEGIN
		SET dias_vencidos = (SELECT DATEDIFF(fecha_devolucion_real, fecha_devolucion_esperada) FROM prestamos WHERE id_prestamo = p_id);
        SET categoria_socio = (SELECT categoria FROM socios WHERE id_socio = (SELECT id_socio FROM prestamos WHERE id_prestamo = p_id));
		SELECT 'El prestamo esta vencido' AS Resultado, calcular_multa(dias_vencidos, categoria_socio) AS Multa;
    END;
    SET estado_prestamo = (SELECT estado FROM prestamos WHERE id_prestamo = p_id);
    IF estado_prestamo = 'devuelto' THEN
		SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El estado del prestamo ya se devolvio';
	ELSEIF estado_prestamo = 'vencido' THEN
		SIGNAL SQLSTATE '45001'
        SET MESSAGE_TEXT = 'El prestamo se vencio';
    END IF;
    
    UPDATE prestamos
    SET estado = 'devuelto'
    WHERE id_prestamo = p_id;
    
END$$

DELIMITER ;

drop procedure procesar_devolucion;
Call procesar_devolucion(5);

/*EJERCICIO SP 3 (CURSORES)
Crear un procedimiento almacenado llamado 'mostrar_socios_basico' que:
o Use un cursor para recorrer todos los socios
o Para cada socio, muestre su nombre y la cantidad de préstamos*/

DELIMITER $$

CREATE PROCEDURE mostrar_socios_basico()
BEGIN
	DECLARE id int default 0;
    declare socio VARCHAR(50);
    DECLARE prestamos int default 0;
	DECLARE final int default 0;
	DECLARE cur CURSOR FOR SELECT s.id_socio, concat(s.nombre, ' ', s.apellido), count(p.id_socio)
						   FROM socios as s inner join prestamos as p on p.id_socio = s.id_socio
                           GROUP BY s.id_socio;
    
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET final = 1;
    
    OPEN cur;
    
    loop_lectura: LOOP
		fetch cur INTO id, socio, prestamos;
        if final then
			SELECT 'fin de pagina' AS pie;
			LEAVE loop_lectura;
        end if;
        select id as ID_SOCIO, socio AS SOCIO, prestamos AS CANTIDAD_DE_PRESTAMOS;
    END LOOP;
    
    CLOSE cur;
END$$

DELIMITER ; 

call mostrar_socios_basico();

/*EJERCICIO FUNCION VENTANA 1
Usar funciones ventana para mostrar el ranking de los libros más caros por género. Para
cada libro, mostrar:
• Título, género, precio
• Ranking dentro de su género (usar RANK)
• Ranking denso (usar DENSE_RANK)
• Número de fila (usar ROW_NUMBER)*/

SELECT
	l.titulo as Titulo, l.genero as genero, l.precio as precio, RANK()OVER(PARTITION BY l.genero order by l.precio desc) as ranking_1,
    dense_rank()over(partition by l.genero order by l.precio desc) as ranking_2, row_number()over(partition by l.genero order by l.precio desc)
FROM
	libros AS l;
    
select * from libros order by genero;


/*EJERCICIO FUNCION VENTANA 2
Usar funciones ventana para mostrar información acumulada de préstamos por socio. Para
cada préstamo, mostrar:
• Nombre del socio
• Fecha del préstamo
• Total acumulado de préstamos por ese socio
• Promedio de préstamos por socio*/

select
	concat(s.nombre, ' ', s.apellido) as socio, p.fecha_prestamo as fecha_del_prestamo, count(p.id_socio)OVER(partition by p.id_socio order by p.fecha_prestamo rows between unbounded preceding and current row) AS prestamos_por_socio,
    avg(1)OVER(partition by p.id_socio)
from
	socios as s inner join prestamos as p on s.id_socio = p.id_socio;

DELIMITER $$
    
CREATE PROCEDURE actualizar_estado_cursor()
BEGIN
	DECLARE id int default 0;
    declare stock_libro int;
    declare final int default 0;
	DECLARE cur CURSOR FOR SELECT stock, id_libro
						   FROM libros;
	declare continue handler for not found set final = 1;
    
    open cur;
    
    actualizar_loop : loop
		fetch cur into stock_libro, id;
        
        if final then
			leave actualizar_loop;
        end if;
        
        if stock_libro = 0 then
			update libros set estado = 'no disponible' where id_libro = id;
        end if;
    end loop;
    
    close cur;
                           
END$$

DELIMITER ;

