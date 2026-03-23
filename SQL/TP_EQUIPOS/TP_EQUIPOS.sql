create database TP_Equipos;

use TP_Equipos;

-- Script para la tabla 'partido'
CREATE TABLE partido (
    id_partido INT NOT NULL auto_increment,
    id_equipo_local INT NOT NULL,
    id_equipo_visitante INT NOT NULL,
    fecha DATETIME,
    PRIMARY KEY (id_partido),
    FOREIGN KEY (id_equipo_local) REFERENCES equipo(id_equipo),
    FOREIGN KEY (id_equipo_visitante) REFERENCES equipo(id_equipo)
);

-- Script para la tabla 'equipo'
CREATE TABLE equipo (
    id_equipo INT NOT NULL auto_increment,
    nombre_equipo VARCHAR(50),
    PRIMARY KEY (id_equipo)
);

-- Script para la tabla 'jugadores'
CREATE TABLE jugadores (
    id_jugador INT NOT NULL auto_increment,
    id_equipo INT NOT NULL,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    PRIMARY KEY (id_jugador),
    FOREIGN KEY (id_equipo) REFERENCES equipo(id_equipo)
);

-- Script para la tabla 'jugadores_x_equipo_x_partido'
CREATE TABLE jugadores_x_equipo_x_partido (
    id_jugador INT NOT NULL,
    id_partido INT NOT NULL,
    puntos INT,
    rebotes INT,
    asistencias INT,
    minutos INT,
    faltas INT,
    PRIMARY KEY (id_jugador, id_partido),
    FOREIGN KEY (id_jugador) REFERENCES jugadores(id_jugador),
    FOREIGN KEY (id_partido) REFERENCES partido(id_partido)
);


-- LLENAMOS LAS TABLAS

INSERT INTO equipo (nombre_equipo) VALUES 
('Boca Juniors'),
('River Plate'),
('Independiente'),
('Racing Club'),
('San Lorenzo'),
('Huracán'),
('Vélez Sarsfield'),
('Estudiantes de La Plata'),
('Gimnasia y Esgrima La Plata'),
('Rosario Central');

INSERT INTO jugadores (id_equipo, nombre, apellido) VALUES
(1, 'Carlos', 'Tevez'),
(1, 'Frank', 'Fabra'),

(2, 'Enzo', 'Pérez'),
(2, 'Franco', 'Armani'),

(3, 'Sergio', 'Agüero'),
(3, 'Alan', 'Velasco'),

(4, 'Lautaro', 'Martínez'),
(4, 'Gabriel', 'Hauche'),

(5, 'Ángel', 'Romero'),
(5, 'Nicolás', 'Blandi'),

(6, 'Lucas', 'Merolla'),
(6, 'Santiago', 'Hezze'),

(7, 'Lucas', 'Pratto'),
(7, 'Matías', 'De los Santos'),

(8, 'Mariano', 'Andújar'),
(8, 'José', 'Sosa'),

(9, 'Lucas', 'Licht'),
(9, 'Brahian', 'Aleman'),

(10, 'Ángel', 'Di María'),
(10, 'Facundo', 'Mallo');

INSERT INTO partido (id_equipo_local, id_equipo_visitante, fecha) VALUES
(1, 2, '2025-04-01 17:00:00'),
(3, 4, '2025-04-02 18:00:00'),
(5, 6, '2025-04-03 16:30:00'),
(7, 8, '2025-04-04 19:00:00'),
(9, 10, '2025-04-05 15:00:00'),
(2, 5, '2025-04-06 17:30:00'),
(4, 1, '2025-04-07 20:00:00'),
(6, 3, '2025-04-08 18:45:00'),
(8, 9, '2025-04-09 16:15:00'),
(10, 7, '2025-04-10 19:30:00'),
(1, 3, '2025-04-11 17:00:00'),
(2, 4, '2025-04-12 16:00:00'),
(5, 7, '2025-04-13 18:00:00'),
(6, 8, '2025-04-14 19:00:00'),
(9, 1, '2025-04-15 15:30:00'),
(10, 2, '2025-04-16 20:00:00'),
(3, 5, '2025-04-17 17:45:00'),
(4, 6, '2025-04-18 18:15:00'),
(7, 9, '2025-04-19 19:30:00'),
(8, 10, '2025-04-20 16:45:00'),
(1, 6, '2025-04-21 17:00:00'),
(2, 7, '2025-04-22 18:00:00'),
(3, 8, '2025-04-23 19:15:00'),
(4, 9, '2025-04-24 20:00:00'),
(5, 10, '2025-04-25 15:00:00');

INSERT INTO jugadores_x_equipo_x_partido 
(id_jugador, id_partido, puntos, rebotes, asistencias, minutos, faltas) VALUES
(1, 1, 2, 1, 0, 90, 1),
(2, 1, 0, 0, 1, 88, 2),
(3, 1, 1, 2, 0, 25, 0),  -- jugó poco
(4, 1, 3, 1, 2, 70, 3),

(5, 2, 0, 1, 1, 90, 2),
(6, 2, 2, 2, 1, 85, 1),
(7, 2, 1, 0, 0, 38, 0),  -- jugó poco
(8, 2, 3, 3, 1, 74, 2),

(9, 3, 2, 0, 2, 90, 1),
(10, 3, 1, 1, 0, 77, 2),
(11, 3, 3, 2, 3, 68, 1),
(12, 3, 0, 1, 1, 41, 0),  -- menos de 45

(13, 4, 4, 3, 2, 89, 2),
(14, 4, 0, 0, 0, 26, 3),  -- suplente
(15, 4, 1, 2, 1, 75, 1),
(16, 4, 2, 0, 0, 81, 0),

(17, 5, 3, 3, 2, 90, 2),
(18, 5, 0, 0, 1, 86, 2),
(19, 5, 2, 2, 1, 44, 1),  -- justo en el umbral
(20, 5, 1, 1, 0, 73, 0),

(1, 6, 1, 2, 1, 90, 1),
(2, 6, 0, 1, 0, 87, 2),
(3, 6, 2, 0, 2, 42, 1),  -- jugó menos de 45
(4, 6, 0, 1, 0, 76, 0),

(5, 7, 3, 3, 1, 90, 1),
(6, 7, 0, 0, 2, 79, 2),
(7, 7, 1, 1, 0, 35, 1),  -- suplente
(8, 7, 2, 2, 1, 81, 0),

(9, 8, 1, 2, 1, 83, 1),
(10, 8, 2, 1, 0, 88, 1),
(11, 8, 0, 1, 1, 90, 2),
(12, 8, 1, 0, 2, 41, 0),  -- poco tiempo

(13, 9, 3, 2, 0, 89, 2),
(14, 9, 0, 0, 0, 22, 3),  -- suplente
(15, 9, 1, 1, 1, 77, 1),
(16, 9, 2, 1, 2, 90, 0),

(17, 10, 2, 2, 1, 86, 1),
(18, 10, 0, 1, 0, 72, 2),
(19, 10, 1, 0, 0, 39, 0),  -- entró de suplente
(20, 10, 3, 3, 3, 90, 1);

-- Ejercicio 1

select j.nombre, j.apellido, e.nombre_equipo
from jugadores as j inner join equipo as e on e.id_equipo = j.id_equipo;

-- Ejercicio 2

insert into jugadores (id_jugador, id_equipo, nombre, apellido) values
(21, 1, 'Pablo', 'Perez');

select j.nombre, j.apellido
from jugadores as j
where j.nombre like 'P%';

-- Ejercicio 3

insert into equipo (nombre_equipo) values
('Atletico Tucuman');

select e.nombre_equipo
from equipo as e
where e.nombre_equipo like '%Atletico%';

-- Ejercicio 4

select e.nombre_equipo, j.Nombre, j.Apellido, count(jep.id_jugador) as cantidad_partidos
from equipo as e inner join jugadores as j on e.id_equipo = j.id_equipo
inner join jugadores_x_equipo_x_partido as jep on jep.id_jugador = j.id_jugador
group by e.nombre_equipo, j.nombre, j.apellido
having cantidad_partidos > 1;

-- Para jugar un poco con el punto anterior, voy a agregar mas registros a la tabla jep

INSERT INTO jugadores_x_equipo_x_partido 
(id_jugador, id_partido, puntos, rebotes, asistencias, minutos, faltas) VALUES
(1, 5, 3, 1, 0, 90, 0);

delete from jugadores_x_equipo_x_partido where id_jugador = 1 and id_partido = 5;

-- Ejercicio 5

select p.fecha, elocal.nombre_equipo, evisitante.nombre_equipo
from partido as p inner join equipo as evisitante on evisitante.id_equipo = p.id_equipo_visitante 
inner join equipo as elocal on elocal.id_equipo = p.id_equipo_local
order by p.fecha;

-- Ejercicio 6

select e.nombre_equipo, count(j.id_jugador)
from equipo as e left join jugadores as j on j.id_equipo = e.id_equipo
group by e.nombre_equipo;

-- Ejercicio 7

select j.apellido, j.nombre, count(p.id_partido) as Cant_Partidos_Jugados
from jugadores as j inner join jugadores_x_equipo_x_partido as jep on j.id_jugador = jep.id_jugador
inner join partido as p on p.id_partido = jep.id_partido
group by j.nombre, j.apellido
order by j.apellido;

-- Ejercicio 8

select j.apellido, j.nombre, sum(jep.puntos) as Total_Goles, e.nombre_equipo
from jugadores as j inner join jugadores_x_equipo_x_partido as jep on j.id_jugador = jep.id_jugador
inner join equipo as e on e.id_equipo = j.id_equipo
group by j.apellido, j.nombre, e.nombre_equipo
order by Total_Goles desc;

-- Ejercicio 9

select j.apellido, j.nombre, avg(jep.puntos) as Promedio_Goles, e.nombre_equipo
from jugadores as j inner join jugadores_x_equipo_x_partido as jep on j.id_jugador = jep.id_jugador
inner join equipo as e on e.id_equipo = j.id_equipo
group by j.apellido, j.nombre, e.nombre_equipo
order by Promedio_Goles desc;

-- ejercicio 10

select j.apellido, j.nombre, e.nombre_equipo, max(p.fecha) as Ultimo_Partido, min(p.fecha) Primer_Partido
from jugadores as j inner join jugadores_x_equipo_x_partido as jep on j.id_jugador = jep.id_jugador
inner join partido as p on p.id_partido = jep.id_partido
inner join equipo as e on j.id_equipo = e.id_equipo
group by j.apellido, j.nombre, e.nombre_equipo
order by j.apellido;

-- Ejercicio 11

select e.nombre_equipo, count(j.id_equipo) as Cant_Jugadores
from equipo as e inner join jugadores as j on j.id_equipo = e.id_equipo
group by e.nombre_equipo
having Cant_Jugadores > 10; -- no va a mostrar nada porque todos los equipos tienen solo 2 jugadores (re vago el Chat)

-- Ejercicio 12 

select j.apellido, j.nombre, e.nombre_equipo, count(jep.id_jugador) as Cant_Partidos, avg(jep.puntos) Promedio_Goles
from jugadores as j inner join jugadores_x_equipo_x_partido as jep on j.id_jugador = jep.id_jugador
inner join equipo as e on e.id_equipo = j.id_equipo
group by j.apellido, j.nombre, e.nombre_equipo
having Cant_Partidos > 5; -- Lo mismo que en el anterior JIJO

-- Ejercicio 13 

select j.apellido, j.nombre, e.nombre_equipo, avg(jep.puntos) as Prom_Goles, avg(jep.asistencias) as Prom_Asistencias, avg(jep.rebotes) as Prom_Rebotes
from jugadores as j inner join jugadores_x_equipo_x_partido as jep on j.id_jugador = jep.id_jugador
inner join equipo as e on j.id_equipo = e.id_equipo
group by j.apellido, j.nombre, e.nombre_equipo
having Prom_Goles > 10 && Prom_Asistencias > 10 && Prom_Rebotes > 10;
-- 10 puntos 10 asistencias y 10 reBOTES JAJAJAJJAJAJAJAJA PROFE ESTO NO ES LA NBA

-- ejercicio 14

select e.nombre_equipo, count(jep.puntos)
from equipo as e inner join partido as p on e.id_equipo = p.id_Equipo_local
inner join jugadores_x_equipo_x_partido as jep on p.id_partido = jep.id_partido
group by e.nombre_equipo;

-- Ejercicio 15

select e.nombre_equipo, count(p.Id_Equipo_Local) as Cant_Partidos_Como_Local
from equipo as e inner join partido as p on e.id_equipo = p.id_equipo_local
group by e.nombre_equipo
order by Cant_Partidos_Como_Local desc;