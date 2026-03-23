-- Ejercicio CTE 1

WITH CTE_1 AS(
	SELECT
		l.titulo AS Titulo, l.isbn AS ISBN, l.genero AS Genero, l.precio AS precio, l.stock_disponible AS Stock_Disponible,
        l.estado AS Estado, concat(a.nombre, ' ', a.apellido) AS Autor, a.nacionalidad AS Nacionalidad, l.fecha_publicacion AS Fecha_Publicacion
    FROM
		autores AS a INNER JOIN libros AS l ON l.id_autor = a.id_autor
)

SELECT *
FROM CTE_1
WHERE Genero = 'Realismo mágico'
ORDER BY year(Fecha_Publicacion);

-- EJERCICIO CTE 2

WITH CTE_2 AS(
	SELECT
		CONCAT(s.nombre, ' ', s.apellido) AS Socio, s.categoria AS Categoria, s.estado AS Estado, COUNT(p.id_socio) AS Prestamos,
        SUM(CASE WHEN p.estado = 'Activo' THEN 1 ELSE 0 END) AS Activos, SUM(CASE WHEN p.estado = 'Devuelto' THEN 1 ELSE 0 END) AS Devueltos, 
        SUM(CASE WHEN p.estado = 'Vencido' THEN 1 ELSE 0 END) AS Vencidos, SUM(p.multa_aplicada) AS Cumulo_Multas,
        AVG(DATEDIFF(fecha_devolucion_real, p.fecha_prestamo)) AS Promedio_Dias_Prestamos
    FROM
		Socios AS s INNER JOIN prestamos AS p ON s.id_socio = p.id_socio
	GROUP BY 
		p.id_socio
)

SELECT *, CASE WHEN CTE_2.Cumulo_Multas > 0 THEN 'Deudor' ELSE 'No deudor' END AS Tipo
FROM CTE_2
ORDER BY Prestamos desc, Cumulo_Multas desc;

-- EJERCICIO CTE 3

WITH CTE_3 AS(
	SELECT
		l.Titulo AS Titulo, COUNT(p.id_libro) AS Cantidad_Prestamos, CONCAT(a.nombre, ' ', a.apellido) AS Autor,
        l.genero AS Genero, SUM(CASE WHEN p.estado = 'Activo' THEN 1 ELSE 0 END) AS Prestamos_Activos, SUM(p.multa_aplicada) AS Cumulo_Multas,
        l.stock_disponible AS Stock, (l.stock_disponible - SUM(CASE WHEN p.estado = 'Activo' THEN 1 ELSE 0 END)) AS Cant_disponible
	FROM
		libros AS l INNER JOIN prestamos AS p ON l.id_libro = p.id_libro
        INNER JOIN autores as a ON a.id_autor = l.id_autor
	GROUP BY
		p.id_libro
)

SELECT *, CASE WHEN Cantidad_Prestamos > 3 THEN 'Muy popular' ELSE 'Poco popular' END AS Popularidad
FROM CTE_3
ORDER BY Cantidad_Prestamos DESC
LIMIT 8;

-- EJERCICIO VISTA 1

CREATE OR REPLACE VIEW vista_libros_autores AS
	SELECT
		l.id_libro AS ID, l.titulo AS TITULO, l.isbn AS ISBN, l.genero AS GENERO, l.precio AS PRECIO, l.stock_disponible AS STOCK, l.estado AS ESTADO,
        concat(a.nombre, ' ', a.apellido) AS Autor, a.nacionalidad AS NACIONALIDAD, l.fecha_publicacion AS FECHA_PUBLICACION
    FROM
		libros AS l INNER JOIN autores AS a ON l.id_autor = a.id_autor;
        
SELECT * FROM vista_libros_autores WHERE GENERO = 'Realismo magico';

-- EJERCICIO VISTA 2

CREATE OR REPLACE VIEW vista_estadisticas_socios AS
	SELECT
		s.nombre AS SOCIO, s.email AS EMAIL, s.categoria AS CATEGORIA, s.estado AS ESTADO,
        COUNT(p.id_socio) AS PRESTAMOS, SUM(CASE WHEN p.estado = 'Activo' THEN 1 ELSE 0 END) AS ACTIVOS,
        SUM(CASE WHEN p.estado = 'Devuelto' THEN 1 ELSE 0 END) AS DEVUELTOS, SUM(CASE WHEN p.estado = 'Vencido' THEN 1 ELSE 0 END) AS VENCIDOS,
        SUM(p.multa_aplicada) AS MULTAS_ACUMULADAS
    FROM
		socios AS s INNER JOIN prestamos AS p ON s.id_socio = p.id_socio