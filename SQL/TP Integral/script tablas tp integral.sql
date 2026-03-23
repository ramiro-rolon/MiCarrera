-- =====================================================
-- TP BASE DE DATOS AVANZADA - SCRIPT BASE
-- Sistema de Gestión de Biblioteca
-- =====================================================

DROP DATABASE IF EXISTS biblioteca_tp;
CREATE DATABASE biblioteca_tp;
USE biblioteca_tp;

-- =====================================================
-- ESTRUCTURA DE TABLAS
-- =====================================================

-- Tabla de autores
CREATE TABLE autores (
    id_autor INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE,
    nacionalidad VARCHAR(50),
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla de libros
CREATE TABLE libros (
    id_libro INT PRIMARY KEY AUTO_INCREMENT,
    titulo VARCHAR(200) NOT NULL,
    id_autor INT NOT NULL,
    isbn VARCHAR(20) UNIQUE,
    fecha_publicacion DATE,
    genero VARCHAR(50),
    precio DECIMAL(10,2),
    stock_disponible INT DEFAULT 0,
    estado ENUM('disponible', 'descontinuado', 'agotado') DEFAULT 'disponible',
    fecha_alta TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (id_autor) REFERENCES autores(id_autor)
);

-- Tabla de socios
CREATE TABLE socios (
    id_socio INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    telefono VARCHAR(20),
    fecha_inscripcion DATE NOT NULL,
    categoria ENUM('estudiante', 'docente', 'general') DEFAULT 'general',
    estado ENUM('activo', 'suspendido', 'inactivo') DEFAULT 'activo',
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla de préstamos
CREATE TABLE prestamos (
    id_prestamo INT PRIMARY KEY AUTO_INCREMENT,
    id_socio INT NOT NULL,
    id_libro INT NOT NULL,
    fecha_prestamo DATE NOT NULL,
    fecha_devolucion_esperada DATE NOT NULL,
    fecha_devolucion_real DATE NULL,
    estado ENUM('activo', 'devuelto', 'vencido') DEFAULT 'activo',
    multa_aplicada DECIMAL(8,2) DEFAULT 0.00,
    observaciones TEXT,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_socio) REFERENCES socios(id_socio),
    FOREIGN KEY (id_libro) REFERENCES libros(id_libro)
);

-- Tabla de log de actividades (para triggers)
CREATE TABLE log_actividades (
    id_log INT PRIMARY KEY AUTO_INCREMENT,
    tabla_afectada VARCHAR(50) NOT NULL,
    operacion ENUM('INSERT', 'UPDATE', 'DELETE') NOT NULL,
    id_registro INT NOT NULL,
    campo_modificado VARCHAR(50),
    valor_anterior TEXT,
    valor_nuevo TEXT,
    usuario VARCHAR(100) DEFAULT 'sistema',
    fecha_operacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observaciones TEXT
);

-- tabla para cursor 1
CREATE TABLE log_multas_cursor (
    id_log INT AUTO_INCREMENT PRIMARY KEY,
    id_prestamo INT NOT NULL,
    id_socio INT NOT NULL,
    dias_retraso INT NOT NULL,
    multa_asignada DECIMAL(8,2) NOT NULL,
    fecha_proceso TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    -- Claves foráneas (opcional, se pueden comentar si no se quiere restricción)
    CONSTRAINT fk_logmultas_prestamo FOREIGN KEY (id_prestamo) REFERENCES prestamos(id_prestamo),
    CONSTRAINT fk_logmultas_socio FOREIGN KEY (id_socio) REFERENCES socios(id_socio)
);



-- tabla para cursor 2
CREATE TABLE log_multas_cursor_2 (
    id_log INT AUTO_INCREMENT PRIMARY KEY,
    id_prestamo INT,
    id_socio INT,
    dias_retraso INT,
    multa_asignada DECIMAL(8,2),
    fecha_proceso TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


-- =====================================================
-- DATOS DE PRUEBA
-- =====================================================

-- Insertar autores
INSERT INTO autores (nombre, apellido, fecha_nacimiento, nacionalidad) VALUES
('Gabriel', 'García Márquez', '1927-03-06', 'Colombiana'),
('Jorge Luis', 'Borges', '1899-08-24', 'Argentina'),
('Isabel', 'Allende', '1942-08-02', 'Chilena'),
('Mario', 'Vargas Llosa', '1936-03-28', 'Peruana'),
('Julio', 'Cortázar', '1914-08-26', 'Argentina'),
('Octavio', 'Paz', '1914-03-31', 'Mexicana');

-- Insertar libros
INSERT INTO libros (titulo, id_autor, isbn, fecha_publicacion, genero, precio, stock_disponible) VALUES
('Cien años de soledad', 1, '978-0-06-088328-7', '1967-06-05', 'Realismo mágico', 450.00, 5),
('El amor en los tiempos del cólera', 1, '978-0-14-024859-6', '1985-12-01', 'Romance', 380.00, 3),
('Ficciones', 2, '978-0-8021-3050-8', '1944-01-01', 'Fantasía', 320.00, 4),
('El Aleph', 2, '978-84-376-0494-4', '1949-01-01', 'Fantasía', 290.00, 2),
('La casa de los espíritus', 3, '978-0-553-38356-6', '1982-01-01', 'Realismo mágico', 420.00, 6),
('La ciudad y los perros', 4, '978-84-204-6244-7', '1963-01-01', 'Narrativa', 350.00, 3),
('Rayuela', 5, '978-84-376-0298-8', '1963-06-28', 'Narrativa experimental', 480.00, 2),
('El laberinto de la soledad', 6, '978-0-8021-5608-9', '1950-01-01', 'Ensayo', 310.00, 4);

-- Insertar socios
INSERT INTO socios (nombre, apellido, email, telefono, fecha_inscripcion, categoria) VALUES
('Ana', 'González', 'ana.gonzalez@email.com', '1234567890', '2023-01-15', 'estudiante'),
('Carlos', 'Rodríguez', 'carlos.rodriguez@email.com', '1234567891', '2023-02-20', 'docente'),
('María', 'López', 'maria.lopez@email.com', '1234567892', '2023-03-10', 'general'),
('Juan', 'Pérez', 'juan.perez@email.com', '1234567893', '2023-04-05', 'estudiante'),
('Laura', 'Martínez', 'laura.martinez@email.com', '1234567894', '2023-05-12', 'general'),
('Diego', 'Fernández', 'diego.fernandez@email.com', '1234567895', '2023-06-18', 'docente');

-- Insertar préstamos
INSERT INTO prestamos (id_socio, id_libro, fecha_prestamo, fecha_devolucion_esperada, fecha_devolucion_real, estado) VALUES
(1, 1, '2024-01-10', '2024-01-24', '2024-01-22', 'devuelto'),
(2, 3, '2024-01-15', '2024-02-14', NULL, 'activo'),
(3, 5, '2024-02-01', '2024-02-15', '2024-02-20', 'devuelto'),
(4, 2, '2024-02-10', '2024-02-24', NULL, 'vencido'),
(1, 7, '2024-02-15', '2024-03-01', NULL, 'activo'),
(5, 4, '2024-03-01', '2024-03-15', '2024-03-14', 'devuelto'),
(6, 6, '2024-03-05', '2024-04-04', NULL, 'activo'),
(2, 8, '2024-03-10', '2024-04-09', NULL, 'activo');

-- Actualizar algunos préstamos vencidos con multas
UPDATE prestamos 
SET multa_aplicada = 50.00, observaciones = 'Entrega tardía - 5 días'
WHERE id_prestamo = 3;

UPDATE prestamos 
SET multa_aplicada = 75.00, observaciones = 'Préstamo vencido - pendiente devolución'
WHERE id_prestamo = 4;

-- =====================================================
-- VERIFICACIÓN DE DATOS
-- =====================================================
SELECT 'AUTORES' AS tabla, COUNT(*) AS registros FROM autores
UNION ALL
SELECT 'LIBROS' AS tabla, COUNT(*) AS registros FROM libros
UNION ALL
SELECT 'SOCIOS' AS tabla, COUNT(*) AS registros FROM socios
UNION ALL
SELECT 'PRÉSTAMOS' AS tabla, COUNT(*) AS registros FROM prestamos;

-- =====================================================
-- TP BASE DE DATOS AVANZADA - EJERCICIOS CTE
-- =====================================================

	-- =====================================================
	-- EJERCICIO CTE 1 (BÁSICO)
	-- Crear una CTE que muestre información completa de libros 
	-- con sus autores, luego filtrar por género "Realismo mágico"
	-- =====================================================

	WITH libros_completos AS (
		SELECT 
			l.id_libro,
			l.titulo,
			l.isbn,
			l.genero,
			l.precio,
			l.stock_disponible,
			l.estado,
			CONCAT(a.nombre, ' ', a.apellido) AS autor_completo,
			a.nacionalidad,
			YEAR(l.fecha_publicacion) AS año_publicacion
		FROM libros l
		INNER JOIN autores a ON l.id_autor = a.id_autor
	)
	SELECT 
		titulo,
		autor_completo,
		nacionalidad,
		año_publicacion,
		precio,
		stock_disponible
	FROM libros_completos
	WHERE genero = 'Realismo mágico'
	ORDER BY año_publicacion;

	-- =====================================================
	-- EJERCICIO CTE 2 (INTERMEDIO)
	-- Usar CTE para calcular estadísticas de préstamos por socio
	-- (cantidad total, préstamos activos, multas acumuladas)
	-- =====================================================

	WITH estadisticas_socios AS (
		SELECT 
			s.id_socio,
			CONCAT(s.nombre, ' ', s.apellido) AS socio_completo,
			s.categoria,
			s.estado AS estado_socio,
			COUNT(p.id_prestamo) AS total_prestamos,
			SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END) AS prestamos_activos,
			SUM(CASE WHEN p.estado = 'devuelto' THEN 1 ELSE 0 END) AS prestamos_devueltos,
			SUM(CASE WHEN p.estado = 'vencido' THEN 1 ELSE 0 END) AS prestamos_vencidos,
			SUM(p.multa_aplicada) AS total_multas,
			AVG(DATEDIFF(COALESCE(p.fecha_devolucion_real, CURRENT_DATE), p.fecha_prestamo)) AS promedio_dias_prestamo
		FROM socios s
		LEFT JOIN prestamos p ON s.id_socio = p.id_socio
		GROUP BY s.id_socio, s.nombre, s.apellido, s.categoria, s.estado
	)
	SELECT 
		socio_completo,
		categoria,
		estado_socio,
		total_prestamos,
		prestamos_activos,
		prestamos_devueltos,
		prestamos_vencidos,
		COALESCE(total_multas, 0) AS multas_acumuladas,
		ROUND(COALESCE(promedio_dias_prestamo, 0), 1) AS promedio_dias_prestamo,
		CASE 
			WHEN prestamos_vencidos > 0 THEN 'MOROSO'
			WHEN prestamos_activos > 2 THEN 'ACTIVO ALTO'
			WHEN prestamos_activos > 0 THEN 'ACTIVO'
			ELSE 'INACTIVO'
		END AS clasificacion
	FROM estadisticas_socios
	ORDER BY total_prestamos DESC, multas_acumuladas DESC;

	-- =====================================================
	-- EJERCICIO CTE 3 (AVANZADO)
	-- CTE para ranking de libros más prestados, 
	-- incluyendo información del autor y disponibilidad actual
	-- =====================================================

	WITH ranking_libros AS (
		SELECT 
			l.titulo,
			CONCAT(a.nombre, ' ', a.apellido) AS autor,
			l.genero,
			l.stock_disponible,
			COUNT(p.id_prestamo) as total_prestamos,
			COUNT(CASE WHEN p.estado = 'activo' THEN 1 END) as prestamos_activos,
			SUM(p.multa_aplicada) as multas_generadas
		FROM libros l
		INNER JOIN autores a ON l.id_autor = a.id_autor
		LEFT JOIN prestamos p ON l.id_libro = p.id_libro
		GROUP BY l.id_libro, l.titulo, a.nombre, a.apellido, l.genero, l.stock_disponible
	)
	SELECT 
		titulo,
		autor,
		genero,
		total_prestamos,
		prestamos_activos,
		stock_disponible,
		(stock_disponible - prestamos_activos) as disponibles_ahora,
		COALESCE(multas_generadas, 0) as multas_generadas,
		CASE 
			WHEN total_prestamos >= 3 THEN 'MUY POPULAR'
			WHEN total_prestamos >= 2 THEN 'POPULAR'  
			WHEN total_prestamos >= 1 THEN 'MODERADO'
			ELSE 'POCO PRESTADO'
		END as popularidad
	FROM ranking_libros
	ORDER BY total_prestamos DESC, multas_generadas ASC
	LIMIT 8;

-- =====================================================
-- CONSULTAS ADICIONALES PARA VERIFICAR RESULTADOS
-- =====================================================

-- Verificar datos para CTE 1
SELECT DISTINCT genero FROM libros ORDER BY genero;

-- Verificar datos para CTE 2
SELECT s.nombre, s.apellido, COUNT(p.id_prestamo) as prestamos
FROM socios s
LEFT JOIN prestamos p ON s.id_socio = p.id_socio
GROUP BY s.id_socio, s.nombre, s.apellido
ORDER BY prestamos DESC;

-- Verificar datos para CTE 3
SELECT 
    DATE_SUB(CURRENT_DATE, INTERVAL 6 MONTH) as fecha_limite,
    COUNT(*) as prestamos_ultimos_6_meses
FROM prestamos 
WHERE fecha_prestamo >= DATE_SUB(CURRENT_DATE, INTERVAL 6 MONTH);

-- =====================================================
-- TP BASE DE DATOS AVANZADA - EJERCICIOS VISTAS
-- =====================================================

-- =====================================================
-- EJERCICIO VISTA 1 (BÁSICO)
-- Crear una vista que muestre información básica de libros 
-- con sus autores (reutilizando lógica de CTE anterior)
-- =====================================================

CREATE VIEW vista_libros_autores AS
SELECT 
    l.id_libro,
    l.titulo,
    l.isbn,
    l.genero,
    l.precio,
    l.stock_disponible,
    l.estado,
    CONCAT(a.nombre, ' ', a.apellido) AS autor_completo,
    a.nacionalidad,
    YEAR(l.fecha_publicacion) AS año_publicacion,
    l.fecha_publicacion
FROM libros l
INNER JOIN autores a ON l.id_autor = a.id_autor;

-- Consulta de prueba para la vista
SELECT titulo, autor_completo, genero, precio, stock_disponible
FROM vista_libros_autores
WHERE genero = 'Realismo mágico'
ORDER BY año_publicacion;

-- =====================================================
-- EJERCICIO VISTA 2 (INTERMEDIO)  
-- Crear una vista con estadísticas de socios que incluya
-- información calculada de préstamos
-- =====================================================

CREATE VIEW vista_estadisticas_socios AS
SELECT 
    s.id_socio,
    CONCAT(s.nombre, ' ', s.apellido) AS socio_completo,
    s.email,
    s.categoria,
    s.estado AS estado_socio,
    s.fecha_inscripcion,
    COUNT(p.id_prestamo) AS total_prestamos,
    SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END) AS prestamos_activos,
    SUM(CASE WHEN p.estado = 'devuelto' THEN 1 ELSE 0 END) AS prestamos_devueltos,
    SUM(CASE WHEN p.estado = 'vencido' THEN 1 ELSE 0 END) AS prestamos_vencidos,
    COALESCE(SUM(p.multa_aplicada), 0) AS multas_acumuladas,
    CASE 
        WHEN SUM(CASE WHEN p.estado = 'vencido' THEN 1 ELSE 0 END) > 0 THEN 'MOROSO'
        WHEN SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END) > 2 THEN 'ACTIVO ALTO'
        WHEN SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END) > 0 THEN 'ACTIVO'
        ELSE 'INACTIVO'
    END AS clasificacion_socio
FROM socios s
LEFT JOIN prestamos p ON s.id_socio = p.id_socio
GROUP BY s.id_socio, s.nombre, s.apellido, s.email, s.categoria, s.estado, s.fecha_inscripcion;

-- Consulta de prueba para la vista
SELECT socio_completo, categoria, total_prestamos, prestamos_activos, 
       multas_acumuladas, clasificacion_socio
FROM vista_estadisticas_socios
WHERE clasificacion_socio IN ('MOROSO', 'ACTIVO ALTO')
ORDER BY multas_acumuladas DESC;

-- =====================================================
-- EJERCICIO VISTA 3 (AVANZADO)
-- Crear una vista que combine las vistas anteriores con
-- información de disponibilidad de libros en tiempo real
-- =====================================================

CREATE VIEW vista_disponibilidad_libros AS
SELECT 
    vla.id_libro,
    vla.titulo,
    vla.autor_completo,
    vla.genero,
    vla.precio,
    vla.stock_disponible,
    COUNT(p.id_prestamo) as total_prestamos_historicos,
    SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END) as prestamos_actuales,
    (vla.stock_disponible - COALESCE(SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END), 0)) as disponibles_ahora,
    COALESCE(SUM(p.multa_aplicada), 0) as multas_generadas,
    CASE 
        WHEN (vla.stock_disponible - COALESCE(SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END), 0)) <= 0 THEN 'NO DISPONIBLE'
        WHEN (vla.stock_disponible - COALESCE(SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END), 0)) = 1 THEN 'ÚLTIMA COPIA'
        WHEN (vla.stock_disponible - COALESCE(SUM(CASE WHEN p.estado = 'activo' THEN 1 ELSE 0 END), 0)) <= 2 THEN 'POCAS COPIAS'
        ELSE 'DISPONIBLE'
    END as estado_disponibilidad,
    CASE 
        WHEN COUNT(p.id_prestamo) >= 3 THEN 'MUY POPULAR'
        WHEN COUNT(p.id_prestamo) >= 2 THEN 'POPULAR'  
        WHEN COUNT(p.id_prestamo) >= 1 THEN 'MODERADO'
        ELSE 'POCO PRESTADO'
    END as nivel_popularidad
FROM vista_libros_autores vla
LEFT JOIN prestamos p ON vla.id_libro = p.id_libro
WHERE vla.estado = 'disponible'
GROUP BY vla.id_libro, vla.titulo, vla.autor_completo, vla.genero, vla.precio, vla.stock_disponible;

-- Consulta de prueba para la vista
SELECT titulo, autor_completo, nivel_popularidad, disponibles_ahora, estado_disponibilidad
FROM vista_disponibilidad_libros
WHERE estado_disponibilidad IN ('ÚLTIMA COPIA', 'POCAS COPIAS')
ORDER BY total_prestamos_historicos DESC;

-- =====================================================
-- CONSULTAS DE VALIDACIÓN Y USO COMBINADO DE VISTAS
-- =====================================================

-- Consulta combinando múltiples vistas
SELECT 
    vdl.titulo,
    vdl.autor_completo,
    vdl.nivel_popularidad,
    vdl.disponibles_ahora,
    COUNT(ves.socio_completo) as socios_interesados
FROM vista_disponibilidad_libros vdl
LEFT JOIN prestamos p ON vdl.id_libro = p.id_libro
LEFT JOIN vista_estadisticas_socios ves ON p.id_socio = ves.id_socio
WHERE vdl.genero = 'Narrativa'
GROUP BY vdl.id_libro, vdl.titulo, vdl.autor_completo, vdl.nivel_popularidad, vdl.disponibles_ahora
ORDER BY vdl.nivel_popularidad DESC, vdl.disponibles_ahora ASC;

-- Verificar estructura de las vistas creadas
SHOW CREATE VIEW vista_libros_autores;
SHOW CREATE VIEW vista_estadisticas_socios;
SHOW CREATE VIEW vista_disponibilidad_libros;

-- =====================================================
-- EJERCICIOS ADICIONALES PARA PRACTICAR
-- =====================================================

/*
EJERCICIO A: Crear una vista que muestre solo libros disponibles para préstamo
(estado = 'disponible' y disponibles_ahora > 0)

EJERCICIO B: Crear una vista que muestre el "top 5" de socios más activos
con sus libros favoritos (géneros más prestados)

EJERCICIO C: Modificar la vista_disponibilidad_libros para agregar el campo
"ultima_vez_prestado" que muestre la fecha del último préstamo de cada libro
*/

-- =====================================================
-- TP BASE DE DATOS AVANZADA - EJERCICIOS UDF
-- =====================================================

-- =====================================================
-- EJERCICIO UDF 1 (BÁSICO)
-- ENUNCIADO: La biblioteca necesita calcular multas por días 
-- de retraso. Crear una función llamada 'calcular_multa' que:
-- - Reciba como parámetros: días de retraso y categoría de socio
-- - Retorne el monto de multa según estas reglas:
--   * Estudiantes: $10 por día
--   * Docentes: $15 por día  
--   * General: $20 por día
--   * Si días <= 0, retornar 0
-- =====================================================

DELIMITER //

CREATE FUNCTION calcular_multa(dias_retraso INT, categoria_socio VARCHAR(20))
RETURNS DECIMAL(8,2)
READS SQL DATA
DETERMINISTIC
BEGIN
    DECLARE multa_diaria DECIMAL(5,2);
    
    -- Si no hay retraso, no hay multa
    IF dias_retraso <= 0 THEN
        RETURN 0.00;
    END IF;
    
    -- Determinar multa diaria según categoría
    CASE categoria_socio
        WHEN 'estudiante' THEN SET multa_diaria = 10.00;
        WHEN 'docente' THEN SET multa_diaria = 15.00;
        WHEN 'general' THEN SET multa_diaria = 20.00;
        ELSE SET multa_diaria = 20.00; -- Por defecto
    END CASE;
    
    RETURN multa_diaria * dias_retraso;
END //

DELIMITER ;

-- Pruebas de la función
SELECT calcular_multa(5, 'estudiante') AS multa_estudiante_5_dias;
SELECT calcular_multa(3, 'docente') AS multa_docente_3_dias;
SELECT calcular_multa(-2, 'general') AS multa_sin_retraso;

-- =====================================================
-- EJERCICIO UDF 2 (INTERMEDIO)
-- ENUNCIADO: Para generar reportes automáticos, crear una función
-- llamada 'obtener_info_socio' que:
-- - Reciba un ID de socio
-- - Retorne un texto descriptivo con: "Nombre Apellido (Categoría): 
--   X préstamos activos, Y préstamos totales, $Z en multas"
-- - Si el socio no existe, retornar "Socio no encontrado"
-- - Debe usar la vista_estadisticas_socios creada anteriormente
-- =====================================================

DELIMITER //

CREATE FUNCTION obtener_info_socio(socio_id INT)
RETURNS TEXT
READS SQL DATA
DETERMINISTIC
BEGIN
    DECLARE info_texto TEXT;
    DECLARE socio_nombre VARCHAR(200);
    DECLARE socio_categoria VARCHAR(20);
    DECLARE prestamos_activos INT;
    DECLARE prestamos_totales INT;
    DECLARE multas DECIMAL(8,2);
    
    -- Obtener información del socio desde la vista
    SELECT socio_completo, categoria, prestamos_activos, total_prestamos, multas_acumuladas
    INTO socio_nombre, socio_categoria, prestamos_activos, prestamos_totales, multas
    FROM vista_estadisticas_socios
    WHERE id_socio = socio_id;
    
    -- Verificar si se encontró el socio
    IF socio_nombre IS NULL THEN
        RETURN 'Socio no encontrado';
    END IF;
    
    -- Construir el texto informativo
    SET info_texto = CONCAT(socio_nombre, ' (', socio_categoria, '): ',
        prestamos_activos, ' préstamos activos, ',
        prestamos_totales, ' préstamos totales, $',
        FORMAT(multas, 2), ' en multas'
    );
    
    RETURN info_texto;
END //

DELIMITER ;

-- Pruebas de la función
SELECT obtener_info_socio(1) AS info_socio_1;
SELECT obtener_info_socio(2) AS info_socio_2;
SELECT obtener_info_socio(999) AS socio_inexistente;

-- =====================================================
-- EJERCICIO UDF 3 (AVANZADO)
-- ENUNCIADO: Para el sistema de recomendaciones, crear una función
-- llamada 'recomendar_libro_por_genero' que:
-- - Reciba un género como parámetro
-- - Retorne el título del libro más disponible de ese género
--   (mayor stock disponible y que no esté agotado)
-- - Si no hay libros disponibles del género, retornar "Sin disponibilidad"
-- - Debe usar la vista_libros_autores y considerar préstamos activos
-- =====================================================

DELIMITER //

CREATE FUNCTION recomendar_libro_por_genero(genero_buscar VARCHAR(50))
RETURNS VARCHAR(200)
READS SQL DATA
DETERMINISTIC
BEGIN
    DECLARE titulo_recomendado VARCHAR(200);
    
    -- Buscar el libro con mayor disponibilidad del género
    SELECT vla.titulo
    INTO titulo_recomendado
    FROM vista_libros_autores vla
    LEFT JOIN prestamos p ON vla.id_libro = p.id_libro AND p.estado = 'activo'
    WHERE vla.genero = genero_buscar 
    AND vla.estado = 'disponible'
    GROUP BY vla.id_libro, vla.titulo, vla.stock_disponible
    HAVING (vla.stock_disponible - COUNT(p.id_prestamo)) > 0
    ORDER BY (vla.stock_disponible - COUNT(p.id_prestamo)) DESC
    LIMIT 1;
    
    -- Verificar si se encontró algún libro
    IF titulo_recomendado IS NULL THEN
        RETURN 'Sin disponibilidad';
    END IF;
    
    RETURN titulo_recomendado;
END //

DELIMITER ;

-- Pruebas de la función
SELECT recomendar_libro_por_genero('Realismo mágico') AS recomendacion_realismo;
SELECT recomendar_libro_por_genero('Narrativa') AS recomendacion_narrativa;
SELECT recomendar_libro_por_genero('Género inexistente') AS sin_genero;

-- =====================================================
-- CONSULTAS DE VALIDACIÓN USANDO LAS FUNCIONES
-- =====================================================

-- Calcular multas teóricas para préstamos vencidos actuales
SELECT 
    p.id_prestamo,
    s.nombre,
    s.categoria,
    DATEDIFF(CURRENT_DATE, p.fecha_devolucion_esperada) as dias_vencido,
    calcular_multa(
        DATEDIFF(CURRENT_DATE, p.fecha_devolucion_esperada), 
        s.categoria
    ) AS multa_teorica,
    p.multa_aplicada as multa_real
FROM prestamos p
INNER JOIN socios s ON p.id_socio = s.id_socio
WHERE p.estado = 'vencido'
AND DATEDIFF(CURRENT_DATE, p.fecha_devolucion_esperada) > 0;

-- Generar reporte completo de todos los socios
SELECT obtener_info_socio(id_socio) as reporte_socio
FROM socios
ORDER BY id_socio;

-- Obtener recomendaciones por cada género disponible
SELECT DISTINCT 
    vla.genero,
    recomendar_libro_por_genero(vla.genero) as libro_recomendado
FROM vista_libros_autores vla
WHERE vla.estado = 'disponible'
ORDER BY vla.genero;


-- =====================================================
-- TP BASE DE DATOS AVANZADA - EJERCICIOS TRIGGERS
-- =====================================================

-- =====================================================
-- EJERCICIO TRIGGER 1 (BÁSICO)
-- ENUNCIADO: Para mantener un registro de auditoría básico,
-- crear un trigger llamado 'log_cambios_libros' que:
-- - Se active DESPUÉS de cualquier UPDATE en la tabla libros
-- - Registre en log_actividades: tabla afectada, operación, ID del registro
-- - Guarde información básica: usuario, fecha de operación
-- =====================================================

DELIMITER //

CREATE TRIGGER log_cambios_libros
AFTER UPDATE ON libros
FOR EACH ROW
BEGIN
    INSERT INTO log_actividades (
        tabla_afectada, 
        operacion, 
        id_registro, 
        observaciones
    ) VALUES (
        'libros',
        'UPDATE',
        NEW.id_libro,
        CONCAT('Libro modificado: ', OLD.titulo)
    );
END //

DELIMITER ;

-- Prueba del trigger
UPDATE libros SET precio = 500.00 WHERE id_libro = 1;

-- Verificar el log
SELECT * FROM log_actividades WHERE tabla_afectada = 'libros' ORDER BY fecha_operacion DESC;

-- =====================================================
-- EJERCICIO TRIGGER 2 (INTERMEDIO)
-- ENUNCIADO: Para controlar automáticamente el stock de libros,
-- crear un trigger llamado 'controlar_stock_prestamo' que:
-- - Se active ANTES de INSERT en la tabla prestamos
-- - Verifique que hay stock disponible del libro solicitado
-- - Si no hay stock, genere un error personalizado con SIGNAL
-- - Registre el intento en la tabla log_actividades
-- =====================================================

DELIMITER //

CREATE TRIGGER controlar_stock_prestamo
BEFORE INSERT ON prestamos
FOR EACH ROW
BEGIN
    DECLARE stock_actual INT;
    DECLARE prestamos_activos INT;
    DECLARE disponibles INT;
    DECLARE titulo_libro VARCHAR(200);
    
    -- Obtener información del libro
    SELECT stock_disponible, titulo
    INTO stock_actual, titulo_libro
    FROM libros 
    WHERE id_libro = NEW.id_libro;
    
    -- Contar préstamos activos del libro
    SELECT COUNT(*)
    INTO prestamos_activos
    FROM prestamos
    WHERE id_libro = NEW.id_libro AND estado = 'activo';
    
    -- Calcular disponibilidad
    SET disponibles = stock_actual - prestamos_activos;
    
    -- Registrar el intento de préstamo
    INSERT INTO log_actividades (
        tabla_afectada,
        operacion,
        id_registro,
        observaciones
    ) VALUES (
        'prestamos',
        'INSERT',
        NEW.id_libro,
        CONCAT('Intento de préstamo - Libro: ', titulo_libro, ', Disponibles: ', disponibles)
    );
    
    -- Verificar disponibilidad
    IF disponibles <= 0 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = CONCAT('Sin stock disponible para el libro: ', titulo_libro);
    END IF;
    
END //

DELIMITER ;

-- Prueba del trigger (debe funcionar - hay stock)
INSERT INTO prestamos (id_socio, id_libro, fecha_prestamo, fecha_devolucion_esperada)
VALUES (1, 8, CURRENT_DATE, DATE_ADD(CURRENT_DATE, INTERVAL 15 DAY));

-- Prueba del trigger (debe dar error - sin stock)
-- Primero agotamos el stock del libro ID 4
UPDATE libros SET stock_disponible = 1 WHERE id_libro = 4;
INSERT INTO prestamos (id_socio, id_libro, fecha_prestamo, fecha_devolucion_esperada)
VALUES (3, 4, CURRENT_DATE, DATE_ADD(CURRENT_DATE, INTERVAL 15 DAY));

-- Esta segunda inserción debería fallar
-- INSERT INTO prestamos (id_socio, id_libro, fecha_prestamo, fecha_devolucion_esperada)
-- VALUES (4, 4, CURRENT_DATE, DATE_ADD(CURRENT_DATE, INTERVAL 15 DAY));

-- Verificar logs generados
SELECT * FROM log_actividades WHERE tabla_afectada = 'prestamos' ORDER BY fecha_operacion DESC;

-- =====================================================
-- EJERCICIO TRIGGER 3 (INTERMEDIO)  
-- ENUNCIADO: Para automatizar el cálculo de multas,
-- crear un trigger llamado 'calcular_multa_devolucion' que:
-- - Se active ANTES de UPDATE en prestamos cuando cambia el estado a 'devuelto'
-- - Calcule automáticamente la multa usando la función calcular_multa
-- - Solo si la devolución es tardía (fecha_devolucion_real > fecha_devolucion_esperada)
-- - Use la función creada anteriormente para el cálculo
-- =====================================================

DELIMITER //

CREATE TRIGGER calcular_multa_devolucion
BEFORE UPDATE ON prestamos
FOR EACH ROW
BEGIN
    DECLARE dias_retraso INT;
    DECLARE categoria_socio VARCHAR(20);
    DECLARE multa_calculada DECIMAL(8,2);
    
    -- Solo procesar si cambia a estado 'devuelto' y no tenía multa
    IF NEW.estado = 'devuelto' AND OLD.estado != 'devuelto' THEN
        
        -- Calcular días de retraso si hay fecha de devolución real
        IF NEW.fecha_devolucion_real IS NOT NULL THEN
            SET dias_retraso = DATEDIFF(NEW.fecha_devolucion_real, OLD.fecha_devolucion_esperada);
            
            -- Solo calcular multa si hay retraso
            IF dias_retraso > 0 THEN
                -- Obtener categoría del socio
                SELECT categoria INTO categoria_socio
                FROM socios WHERE id_socio = NEW.id_socio;
                
                -- Calcular multa usando la función creada
                SET multa_calculada = calcular_multa(dias_retraso, categoria_socio);
                
                -- Asignar la multa calculada
                SET NEW.multa_aplicada = multa_calculada;
                
                -- Agregar observación
                SET NEW.observaciones = CONCAT(
                    COALESCE(OLD.observaciones, ''), 
                    ' - Multa automática por ', dias_retraso, ' días de retraso'
                );
            END IF;
        END IF;
    END IF;
    
END //

DELIMITER ;

-- Prueba del trigger - devolución a tiempo (sin multa)
UPDATE prestamos 
SET estado = 'devuelto', fecha_devolucion_real = '2024-03-12'
WHERE id_prestamo = 7;

-- Prueba del trigger - devolución tardía (con multa automática)
INSERT INTO prestamos (id_socio, id_libro, fecha_prestamo, fecha_devolucion_esperada, estado)
VALUES (2, 5, '2024-03-01', '2024-03-15', 'activo');

-- Simular devolución tardía
UPDATE prestamos 
SET estado = 'devuelto', fecha_devolucion_real = '2024-03-20'
WHERE id_socio = 2 AND id_libro = 5 AND fecha_prestamo = '2024-03-01';

-- Verificar resultados
SELECT id_prestamo, id_socio, id_libro, fecha_devolucion_esperada, 
       fecha_devolucion_real, multa_aplicada, observaciones
FROM prestamos 
WHERE estado = 'devuelto' 
ORDER BY id_prestamo DESC;

-- =====================================================
-- CONSULTAS DE VERIFICACIÓN DE TRIGGERS
-- =====================================================

-- Ver todos los triggers creados
SHOW TRIGGERS;

-- Verificar log de todas las actividades
SELECT tabla_afectada, operacion, COUNT(*) as cantidad
FROM log_actividades
GROUP BY tabla_afectada, operacion
ORDER BY tabla_afectada, operacion;


-- =====================================================
-- TP BASE DE DATOS AVANZADA - EJERCICIOS STORED PROCEDURES
-- =====================================================

-- =====================================================
-- EJERCICIO SP 1 (BÁSICO - HANDLERS)
-- ENUNCIADO: Crear un stored procedure llamado 'registrar_nuevo_socio'
-- que reciba los datos de un nuevo socio e intente insertarlo.
-- Debe manejar errores con HANDLERS para:
-- - Duplicados de email (código 1062)
-- - Errores SQL generales
-- Retornar mensaje de éxito o error correspondiente
-- =====================================================

DELIMITER //

CREATE PROCEDURE registrar_nuevo_socio(
    IN p_nombre VARCHAR(100),
    IN p_apellido VARCHAR(100), 
    IN p_email VARCHAR(150),
    IN p_telefono VARCHAR(20),
    IN p_categoria ENUM('estudiante', 'docente', 'general'),
    OUT p_resultado VARCHAR(200)
)
BEGIN
    -- Declarar handlers para manejo de errores
    DECLARE EXIT HANDLER FOR 1062 
        SET p_resultado = 'Error: El email ya está registrado en el sistema';
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
        SET p_resultado = 'Error: No se pudo registrar el socio - Error de base de datos';
    
    -- Insertar el nuevo socio
    INSERT INTO socios (nombre, apellido, email, telefono, fecha_inscripcion, categoria)
    VALUES (p_nombre, p_apellido, p_email, p_telefono, CURRENT_DATE, p_categoria);
    
    -- Si llegamos aquí, la inserción fue exitosa
    SET p_resultado = CONCAT('Socio registrado exitosamente: ', p_nombre, ' ', p_apellido);
    
END //

DELIMITER ;

-- Pruebas del procedimiento
CALL registrar_nuevo_socio('Pedro', 'Gómez', 'pedro.gomez@email.com', '1111111111', 'general', @resultado);
SELECT @resultado;

-- Probar error de email duplicado
CALL registrar_nuevo_socio('Ana', 'García', 'ana.gonzalez@email.com', '2222222222', 'estudiante', @resultado);
SELECT @resultado;

-- =====================================================
-- EJERCICIO SP 2 (INTERMEDIO - SIGNAL + HANDLERS)
-- ENUNCIADO: Crear un stored procedure llamado 'procesar_devolucion'
-- que reciba un ID de préstamo y procese su devolución.
-- Debe:
-- - Validar que el préstamo existe y está activo
-- - Generar errores personalizados con SIGNAL si hay problemas
-- - Usar la función UDF para calcular multas automáticamente
-- - Manejar errores con HANDLERS
-- - Actualizar el préstamo a estado 'devuelto'
-- =====================================================

DELIMITER //

CREATE PROCEDURE procesar_devolucion(
    IN p_id_prestamo INT,
    IN p_fecha_devolucion DATE,
    OUT p_mensaje VARCHAR(300)
)
BEGIN
    DECLARE v_estado_actual VARCHAR(20);
    DECLARE v_socio_id INT;
    DECLARE v_libro_titulo VARCHAR(200);
    DECLARE v_fecha_esperada DATE;
    DECLARE v_categoria VARCHAR(20);
    DECLARE v_dias_retraso INT;
    DECLARE v_multa DECIMAL(8,2);
    
    -- Handler para errores SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
        SET p_mensaje = 'Error: No se pudo procesar la devolución - Error de sistema';
    
    -- Obtener información del préstamo
    SELECT p.estado, p.id_socio, l.titulo, p.fecha_devolucion_esperada, s.categoria
    INTO v_estado_actual, v_socio_id, v_libro_titulo, v_fecha_esperada, v_categoria
    FROM prestamos p
    INNER JOIN libros l ON p.id_libro = l.id_libro
    INNER JOIN socios s ON p.id_socio = s.id_socio
    WHERE p.id_prestamo = p_id_prestamo;
    
    -- Validar que el préstamo existe
    IF v_estado_actual IS NULL THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Error: El préstamo no existe';
    END IF;
    
    -- Validar que el préstamo está activo
    IF v_estado_actual != 'activo' THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Error: El préstamo ya fue devuelto o está cancelado';
    END IF;
    
    -- Calcular días de retraso
    SET v_dias_retraso = DATEDIFF(p_fecha_devolucion, v_fecha_esperada);
    
    -- Calcular multa usando la función UDF
    SET v_multa = calcular_multa(v_dias_retraso, v_categoria);
    
    -- Actualizar el préstamo
    UPDATE prestamos 
    SET estado = 'devuelto',
        fecha_devolucion_real = p_fecha_devolucion,
        multa_aplicada = v_multa,
        observaciones = CASE 
            WHEN v_dias_retraso > 0 THEN CONCAT('Devolución tardía - ', v_dias_retraso, ' días')
            ELSE 'Devolución a tiempo'
        END
    WHERE id_prestamo = p_id_prestamo;
    
    -- Mensaje de éxito
    SET p_mensaje = CONCAT(
        'Devolución procesada: ', v_libro_titulo, 
        ' - Multa: $', FORMAT(v_multa, 2),
        CASE 
            WHEN v_dias_retraso > 0 THEN CONCAT(' (', v_dias_retraso, ' días de retraso)')
            ELSE ' (a tiempo)'
        END
    );
    
END //

DELIMITER ;

-- Pruebas del procedimiento
CALL procesar_devolucion(2, CURRENT_DATE, @mensaje);
SELECT @mensaje;

-- Probar error con préstamo inexistente
CALL procesar_devolucion(999, CURRENT_DATE, @mensaje);
SELECT @mensaje;

-- =====================================================
-- EJERCICIO SP 3 (INTERMEDIO - TRANSACCIONES)
-- ENUNCIADO: Crear un stored procedure llamado 'realizar_prestamo_completo'
-- que gestione todo el proceso de préstamo de forma transaccional:
-- - Validar disponibilidad del libro
-- - Validar que el socio no tenga préstamos vencidos
-- - Insertar el nuevo préstamo
-- - Si algo falla, hacer ROLLBACK
-- - Usar COMMIT solo si todo sale bien
-- =====================================================

DELIMITER //

CREATE PROCEDURE realizar_prestamo_completo(
    IN p_id_socio INT,
    IN p_id_libro INT,
    IN p_dias_prestamo INT,
    OUT p_resultado VARCHAR(300)
)
BEGIN
    DECLARE v_prestamos_vencidos INT;
    DECLARE v_stock_disponible INT;
    DECLARE v_prestamos_activos INT;
    DECLARE v_disponibles INT;
    DECLARE v_titulo_libro VARCHAR(200);
    DECLARE v_nombre_socio VARCHAR(200);
    DECLARE v_nuevo_prestamo_id INT;
    
    -- Handler para errores - hace rollback automático
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_resultado = 'Error: No se pudo realizar el préstamo - Transacción cancelada';
    END;
    
    -- Iniciar transacción
    START TRANSACTION;
    
    -- Validar que el socio no tenga préstamos vencidos
    SELECT COUNT(*)
    INTO v_prestamos_vencidos
    FROM prestamos p
    INNER JOIN socios s ON p.id_socio = s.id_socio
    WHERE p.id_socio = p_id_socio 
    AND p.estado = 'vencido';
    
    IF v_prestamos_vencidos > 0 THEN
        ROLLBACK;
        SET p_resultado = 'Error: El socio tiene préstamos vencidos pendientes';
        LEAVE exit_proc;
    END IF;
    
    -- Obtener información del libro y socio
    SELECT l.stock_disponible, l.titulo, CONCAT(s.nombre, ' ', s.apellido)
    INTO v_stock_disponible, v_titulo_libro, v_nombre_socio
    FROM libros l, socios s
    WHERE l.id_libro = p_id_libro AND s.id_socio = p_id_socio;
    
    -- Contar préstamos activos del libro
    SELECT COUNT(*)
    INTO v_prestamos_activos
    FROM prestamos
    WHERE id_libro = p_id_libro AND estado = 'activo';
    
    -- Calcular disponibilidad
    SET v_disponibles = v_stock_disponible - v_prestamos_activos;
    
    -- Validar disponibilidad
    IF v_disponibles <= 0 THEN
        ROLLBACK;
        SET p_resultado = CONCAT('Error: No hay copias disponibles de "', v_titulo_libro, '"');
        LEAVE exit_proc;
    END IF;
    
    -- Insertar el préstamo
    INSERT INTO prestamos (
        id_socio, 
        id_libro, 
        fecha_prestamo, 
        fecha_devolucion_esperada, 
        estado
    ) VALUES (
        p_id_socio,
        p_id_libro,
        CURRENT_DATE,
        DATE_ADD(CURRENT_DATE, INTERVAL p_dias_prestamo DAY),
        'activo'
    );
    
    -- Obtener ID del préstamo recién creado
    SET v_nuevo_prestamo_id = LAST_INSERT_ID();
    
    -- Confirmar transacción
    COMMIT;
    
    -- Mensaje de éxito
    SET p_resultado = CONCAT(
        'Préstamo realizado exitosamente - ID: ', v_nuevo_prestamo_id,
        ' - Libro: "', v_titulo_libro, '" para ', v_nombre_socio,
        ' hasta ', DATE_FORMAT(DATE_ADD(CURRENT_DATE, INTERVAL p_dias_prestamo DAY), '%d/%m/%Y')
    );
    
    exit_proc: BEGIN END;
    
END //

DELIMITER ;

-- Pruebas del procedimiento
CALL realizar_prestamo_completo(1, 3, 15, @resultado);
SELECT @resultado;

-- Probar con socio que tiene préstamos vencidos
CALL realizar_prestamo_completo(4, 5, 15, @resultado);
SELECT @resultado;

-- =====================================================
-- CONSULTAS DE VERIFICACIÓN
-- =====================================================

-- Ver todos los stored procedures creados
SHOW PROCEDURE STATUS WHERE Db = DATABASE();

-- Verificar préstamos recientes
SELECT p.id_prestamo, CONCAT(s.nombre, ' ', s.apellido) as socio, 
       l.titulo, p.fecha_prestamo, p.fecha_devolucion_esperada, p.estado
FROM prestamos p
INNER JOIN socios s ON p.id_socio = s.id_socio
INNER JOIN libros l ON p.id_libro = l.id_libro
ORDER BY p.fecha_prestamo DESC
LIMIT 5;

-- =====================================================
-- TP BASE DE DATOS AVANZADA - EJERCICIOS CURSORES
-- =====================================================

-- =====================================================
-- EJERCICIO CURSOR 1 (BÁSICO)
-- Procedimiento: listar_socios_con_prestamos
-- Recorrer todos los socios y contar sus préstamos,
-- guardando resultados en una tabla temporal.
-- =====================================================

DELIMITER //

CREATE PROCEDURE listar_socios_con_prestamos()
BEGIN
    DECLARE v_id INT;
    DECLARE v_nombre VARCHAR(100);
    DECLARE v_apellido VARCHAR(100);
    DECLARE v_total_prestamos INT;
    DECLARE fin_cursor BOOLEAN DEFAULT FALSE;

    -- Crear tabla temporal (se borra al terminar la sesión)
    DROP TEMPORARY TABLE IF EXISTS tmp_resumen_socios;
    CREATE TEMPORARY TABLE tmp_resumen_socios (
        id_socio INT,
        nombre_completo VARCHAR(200),
        total_prestamos INT
    );

    -- Definir cursor para recorrer socios
    DECLARE cur_socios CURSOR FOR
        SELECT id_socio, nombre, apellido FROM socios;

    -- Handler para detectar fin del cursor
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET fin_cursor = TRUE;

    OPEN cur_socios;

    leer_socios: LOOP
        FETCH cur_socios INTO v_id, v_nombre, v_apellido;
        IF fin_cursor THEN
            LEAVE leer_socios;
        END IF;

        -- Calcular préstamos del socio actual
        SELECT COUNT(*) INTO v_total_prestamos
        FROM prestamos
        WHERE id_socio = v_id;

        -- Insertar en tabla temporal
        INSERT INTO tmp_resumen_socios (id_socio, nombre_completo, total_prestamos)
        VALUES (v_id, CONCAT(v_nombre, ' ', v_apellido), v_total_prestamos);
    END LOOP;

    CLOSE cur_socios;

    -- Mostrar resultados
    SELECT * FROM tmp_resumen_socios ORDER BY total_prestamos DESC;
END //

DELIMITER ;

-- Prueba
CALL listar_socios_con_prestamos();


-- =====================================================
-- EJERCICIO CURSOR 2 (INTERMEDIO)
-- Procedimiento: calcular_multas_socios
-- Recorre préstamos vencidos, calcula multa con la UDF
-- y actualiza la tabla, registrando en log_multas_cursor.
-- =====================================================

-- Crear tabla de log para registrar el proceso
DROP TABLE IF EXISTS log_multas_cursor;
CREATE TABLE log_multas_cursor (
    id_log INT AUTO_INCREMENT PRIMARY KEY,
    id_prestamo INT,
    id_socio INT,
    dias_retraso INT,
    multa_asignada DECIMAL(8,2),
    fecha_proceso TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

DELIMITER //

CREATE PROCEDURE calcular_multas_socios()
BEGIN
    DECLARE v_id_prestamo INT;
    DECLARE v_id_socio INT;
    DECLARE v_fecha_esperada DATE;
    DECLARE v_categoria VARCHAR(20);
    DECLARE v_dias_retraso INT;
    DECLARE v_multa DECIMAL(8,2);
    DECLARE fin_cursor BOOLEAN DEFAULT FALSE;

    -- Definir cursor para recorrer préstamos vencidos
    DECLARE cur_prestamos CURSOR FOR
        SELECT p.id_prestamo, p.id_socio, p.fecha_devolucion_esperada, s.categoria
        FROM prestamos p
        INNER JOIN socios s ON p.id_socio = s.id_socio
        WHERE p.estado = 'vencido';

    -- Handler para detectar fin
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET fin_cursor = TRUE;

    OPEN cur_prestamos;

    leer_prestamos: LOOP
        FETCH cur_prestamos INTO v_id_prestamo, v_id_socio, v_fecha_esperada, v_categoria;
        IF fin_cursor THEN
            LEAVE leer_prestamos;
        END IF;

        -- Calcular días de retraso
        SET v_dias_retraso = DATEDIFF(CURRENT_DATE, v_fecha_esperada);

        -- Calcular multa usando UDF
        SET v_multa = calcular_multa(v_dias_retraso, v_categoria);

        -- Actualizar préstamo si no tenía multa
        UPDATE prestamos
        SET multa_aplicada = v_multa,
            observaciones = CONCAT(COALESCE(observaciones,''), ' - Multa asignada por cursor')
        WHERE id_prestamo = v_id_prestamo
          AND multa_aplicada = 0;

        -- Insertar en log
        INSERT INTO log_multas_cursor (id_prestamo, id_socio, dias_retraso, multa_asignada)
        VALUES (v_id_prestamo, v_id_socio, v_dias_retraso, v_multa);
    END LOOP;

    CLOSE cur_prestamos;

    -- Mostrar log generado
    SELECT * FROM log_multas_cursor ORDER BY fecha_proceso DESC;
END //

DELIMITER ;

-- Prueba
CALL calcular_multas_socios();



