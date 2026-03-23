create database TP_JOINS;

use TP_JOINS;

CREATE TABLE Alumnos (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Edad INT,
    CorreoElectronico VARCHAR(100)
);

CREATE TABLE Materias (
    MateriaID INT PRIMARY KEY AUTO_INCREMENT,
    NombreMateria VARCHAR(50)
);

CREATE TABLE AlumnosXMateria (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    AlumnoID INT,
    MateriaID INT,
    FOREIGN KEY (AlumnoID) REFERENCES Alumnos(ID),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID)
);

CREATE TABLE CalificacionesXAlumno (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    AlumnoID INT,
    MateriaID INT,
    FechaExamen DATE,
    Calificacion INT,
    FOREIGN KEY (AlumnoID) REFERENCES Alumnos(ID),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID)
);

INSERT INTO Alumnos (Nombre, Apellido, Edad, CorreoElectronico) VALUES
('Juan', 'Pérez', 20, 'juan.perez@example.com'),
('María', 'Gómez', 22, 'maria.gomez@example.com'),
('Luis', 'Rodríguez', 21, 'luis.rodriguez@example.com'),
('Ana', 'López', 23, 'ana.lopez@example.com');

INSERT INTO Materias (NombreMateria) VALUES
('Matemáticas'),
('Historia'),
('Biología'),
('Programación');

INSERT INTO AlumnosXMateria (AlumnoID, MateriaID) VALUES
(1, 1), -- Juan inscrito en Matemáticas
(1, 4), -- Juan inscrito en Programación
(2, 1), -- María en Matemáticas
(2, 2), -- María en Historia
(3, 3), -- Luis en Biología
(4, 4), -- Ana en Programación
(4, 2); -- Ana en Historia

INSERT INTO CalificacionesXAlumno (AlumnoID, MateriaID, FechaExamen, Calificacion) VALUES
(1, 1, '2025-04-10', 85),
(1, 4, '2025-04-15', 90),
(2, 1, '2025-04-10', 78),
(2, 2, '2025-04-12', 88),
(3, 3, '2025-04-11', 92),
(4, 2, '2025-04-12', 75),
(4, 4, '2025-04-15', 89);

INSERT INTO Alumnos (Nombre, Apellido, Edad, CorreoElectronico) VALUES
('Carlos', 'Martínez', 18, 'carlos.martinez@example.com'),
('Sofía', 'Torres', 24, 'sofia.torres@example.com');

INSERT INTO AlumnosXMateria (AlumnoID, MateriaID) VALUES
(5, 1), -- Carlos en Matemáticas
(5, 2), -- Carlos en Historia
(5, 3), -- Carlos en Biología
(5, 4), -- Carlos en Programación
(6, 1), -- Sofía en Matemáticas
(6, 2), -- Sofía en Historia
(6, 4), -- Sofía en Programación
(6, 3); -- Sofía en Biología

INSERT INTO CalificacionesXAlumno (AlumnoID, MateriaID, FechaExamen, Calificacion) VALUES
(1, 1, '2025-04-18', 95), -- Juan en Matemáticas
(1, 2, '2025-04-20', 88), -- Juan en Historia
(1, 3, '2025-04-22', 92), -- Juan en Biología
(1, 4, '2025-04-25', 91), -- Juan en Programación
(2, 1, '2025-04-18', 80), -- María en Matemáticas
(2, 2, '2025-04-20', 85), -- María en Historia
(2, 3, '2025-04-23', 79), -- María en Biología
(2, 4, '2025-04-26', 90), -- María en Programación
(3, 1, '2025-04-18', 86), -- Luis en Matemáticas
(3, 2, '2025-04-21', 91), -- Luis en Historia
(3, 3, '2025-04-23', 95), -- Luis en Biología
(3, 4, '2025-04-27', 88), -- Luis en Programación
(4, 1, '2025-04-20', 77), -- Ana en Matemáticas
(4, 2, '2025-04-21', 80), -- Ana en Historia
(4, 3, '2025-04-24', 85), -- Ana en Biología
(4, 4, '2025-04-28', 90), -- Ana en Programación
(5, 1, '2025-04-20', 92), -- Carlos en Matemáticas
(5, 2, '2025-04-22', 84), -- Carlos en Historia
(5, 3, '2025-04-25', 89), -- Carlos en Biología
(5, 4, '2025-04-29', 87), -- Carlos en Programación
(6, 1, '2025-04-19', 83), -- Sofía en Matemáticas
(6, 2, '2025-04-21', 86), -- Sofía en Historia
(6, 3, '2025-04-23', 90), -- Sofía en Biología
(6, 4, '2025-04-26', 93); -- Sofía en Programación

INSERT INTO Alumnos (Nombre, Apellido, Edad, CorreoElectronico) VALUES
('Pedro', 'Gutiérrez', 30, 'pedro.gutierrez@example.com'),
('Elena', 'Ferrer', 28, 'elena.ferrer@example.com');

INSERT INTO AlumnosXMateria (AlumnoID, MateriaID) VALUES
(7, 1), -- Pedro en Matemáticas
(7, 2), -- Pedro en Historia
(7, 3), -- Pedro en Biología
(7, 4), -- Pedro en Programación
(8, 1), -- Elena en Matemáticas
(8, 2), -- Elena en Historia
(8, 4), -- Elena en Programación
(8, 3); -- Elena en Biología

INSERT INTO CalificacionesXAlumno (AlumnoID, MateriaID, FechaExamen, Calificacion) VALUES
(7, 1, '2025-04-20', 80), -- Pedro en Matemáticas
(7, 2, '2025-04-22', 75), -- Pedro en Historia
(7, 3, '2025-04-25', 88), -- Pedro en Biología
(7, 4, '2025-04-29', 91), -- Pedro en Programación
(8, 1, '2025-04-20', 85), -- Elena en Matemáticas
(8, 2, '2025-04-21', 87), -- Elena en Historia
(8, 3, '2025-04-23', 92), -- Elena en Biología
(8, 4, '2025-04-26', 90); -- Elena en Programación


-- Ejercicio 1

select * from alumnos where edad > 20;

-- Ejercicio 2

select distinct correoelectronico from alumnos;

-- Ejercicio 3

select * from alumnos where apellido like 'G%';

-- Ejercicio 4

select a.Nombre, m.NombreMateria 
from alumnos as a 
inner join materias as m inner join alumnosxmateria 
on a.ID = alumnosxmateria.AlumnoID and m.MateriaID = alumnosxmateria.MateriaID
where a.ID = 1;

-- Ejercicio 5

select a.nombre, a.apellido, m.nombremateria
from alumnos as a inner join alumnosxmateria as am on a.ID = am.AlumnoID
inner join materias as m on am.MateriaID = m.MateriaID
where m.MateriaID = 2
order by a.apellido;

-- Ejercicio 6

select a.Nombre, a.Apellido, m.NombreMateria, ca.Calificacion, ca.FechaExamen
from Alumnos as a inner join CalificacionesXAlumno as ca on a.ID = ca.AlumnoID
inner join Materias as m on ca.MateriaID = m.MateriaID
where ca.calificacion > 85
order by m.NombreMateria, ca.calificacion desc;

-- Ejercicio 7

select m.NombreMateria, a.Nombre, a.Apellido, ca.Calificacion
from Alumnos as a inner join CalificacionesXAlumno as ca on a.ID = ca.AlumnoId
inner join Materias as m on m.MateriaID = ca.MateriaId
where ca.Calificacion between 70 and 90
order by m.NombreMateria, ca.Calificacion desc;

-- Ejercicio 9

select m.NombreMateria, count(am.AlumnoID) as Cant_Alumnos
from materias as m inner join alumnosxmateria as am on m.MateriaID = am.MateriaID
group by m.NombreMateria;

-- Ejercicio 10

-- Solo para chequear, voy a agregar un alumno sin calificacion

insert into CalificacionesXAlumno (AlumnoID, MateriaID, FechaExamen) values
(1, 3, '2025-5-5');

insert into alumnos (Nombre, Apellido, Edad, CorreoElectronico) VALUES
('Ramiro', 'Rolon', 24, 'mamamia@gmail.com');

select a.Nombre, a.Apellido, ca.calificacion
from alumnos as a left join calificacionesxalumno as ca on a.ID = ca.AlumnoID
where ca.calificacion is null;

-- Ejercicio 11

select a.nombre, a.apellido, count(am.MateriaID) as cantMaterias
from alumnos as a inner join alumnosxmateria as am on a.ID = am.AlumnoID
group by a.nombre, a.apellido
having cantMaterias > 1;

-- Ejercicio 12

select a.nombre, a.apellido, m.NombreMateria
from alumnos as a inner join alumnosXMateria as am on a.ID = am.AlumnoID
inner join materias as m on m.MateriaID = am.MateriaID
where m.NombreMateria = 'Matematicas' || m.NombreMateria = 'Fisica';

-- Ejercicio 13

select m.NombreMateria, max(ca.FechaExamen), a.Nombre, a.Apellido, ca.Calificacion
from CalificacionesxAlumno as ca inner join Alumnos as a on ca.AlumnoID = a.ID
inner join materias as m on m.MateriaID = ca.MateriaID
group by m.NombreMateria
order by FechaExamen desc;

-- sobre el punto anterior quiero verificar algo

select  m.NombreMateria, ca.FechaExamen, a.Nombre, a.Apellido, ca.Calificacion
from CalificacionesxAlumno as ca inner join Alumnos as a on ca.AlumnoID = a.ID
inner join materias as m on m.MateriaID = ca.MateriaID
where a.nombre = 'Juan' && m.NombreMateria = 'Programación';

-- O sea que el punto 13 esta bien si saco el pedido de nombre, apellido y la calificacion
-- Pero como soy cabeza dura lo voy a hacer igual JIJOOO

-- Al final no pude :c Chat me dijo que lo podia hacer son subconsultas pero no lo vimos
-- Y prefiero que Aroca me explique antes que el Chat

-- Asi seria solo con la fecha y el nombre de la materia:

select m.NombreMateria, max(ca.FechaExamen)
from CalificacionesxAlumno as ca right join materias as m on m.MateriaID = ca.MateriaID
group by m.NombreMateria
order by FechaExamen desc;

-- Ejercicio 14

select m.NombreMateria, max(ca.Calificacion)
from materias as m inner join calificacionesxalumno as ca on m.MateriaID = ca.MateriaID
group by m.NombreMateria;

-- Ejercicio 15

select m.NombreMateria, avg(ca.calificacion) as PromedioNotas
from materias as m inner join calificacionesxalumno as ca on m.MateriaId = ca.MateriaID
group by m.NombreMateria
having PromedioNotas > 85;

-- Ejercicio 16

select m.NombreMateria, ca.calificacion
from materias as m left join calificacionesxalumno as ca on m.MateriaID = ca.MateriaID
where ca.calificacion is null;

-- Ejercicio 17

select a.nombre, a.apellido, m.nombremateria, ca.calificacion
from alumnos as a inner join calificacionesxalumno as ca on ca.AlumnoID = a.ID
inner join materias as m on m.MateriaID = ca.MateriaID
group by m.nombremateria
having max(ca.calificacion);

-- Ejercicio 18

select m.nombremateria, a.nombre, a.apellido, ca.calificacion
from materias as m inner join calificacionesxalumno as ca on m.MateriaID = ca.MateriaID
inner join alumnos as a on ca.AlumnoID = a.ID
where calificacion < 80; -- Lo tuve que hacer con 80 porque mis alumnos son muy inteligentes

-- Ejercicio 19

select a.nombre, a.apellido, m.nombremateria, ca.fechaexamen, ca.calificacion
from alumnos as a inner join calificacionesxalumno as ca on a.ID = ca.AlumnoID
inner join materias as m on m.MateriaId = ca.MateriaID
where ca.FechaExamen = '2025-04-25';

-- Ejercicio 20

insert into alumnos (Nombre, Apellido, Edad, CorreoElectronico) values
('Carlos', 'Bianchi', 75, 'elvirrey@gmail.com');

select a.nombre, a.apellido, count(ca.AlumnoID)
from alumnos as a left join calificacionesxalumno as ca on a.ID = ca.AlumnoId
group by a.nombre, a.apellido
having count(ca.AlumnoID) = 0;