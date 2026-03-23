create database Repaso;

use Repaso;

create table Departamento(
	id_departamento int primary key auto_increment,
    departamento varchar(20) not null unique
);

create table Empleados(
	id_empleado int primary key auto_increment,
    nombre varchar(20) not null,
    apellido varchar(20) not null,
    email varchar(30) not null,
    id_departamento int not null,
    constraint fk_departamento foreign key (id_departamento) references Departamento(id_departamento)
);

create table Tareas(
	id_tarea int primary key auto_increment,
    id_proyecto int not null,
    id_empleado_2 int not null,
    descripcion varchar(100) not null,
    horas_estimadas int not null,
    horas_trabajadas int not null,
    constraint fk_empleado foreign key (id_empleado_2) references empleados(id_empleado)
);	


INSERT INTO Departamento (id_departamento, departamento) VALUES
(1, 'Recursos Humanos'),
(2, 'Sistemas'),
(3, 'Contabilidad'),
(4, 'Marketing'),
(5, 'Logística');

INSERT INTO Empleados (id_empleado, nombre, apellido, email, id_departamento) VALUES
(1, 'Juan', 'Pérez', 'juan.perez@empresa.com', 2),
(2, 'María', 'Gómez', 'maria.gomez@empresa.com', 1),
(3, 'Carlos', 'Fernández', 'carlos.fernandez@empresa.com', 3),
(4, 'Lucía', 'Ramírez', 'lucia.ramirez@empresa.com', 4),
(5, 'Andrés', 'López', 'andres.lopez@empresa.com', 5),
(6, 'Sofía', 'Martínez', 'sofia.martinez@empresa.com', 2);

INSERT INTO Tareas (id_tarea, id_proyecto, id_empleado_2, descripcion, horas_estimadas, horas_trabajadas) VALUES
(1, 101, 1, 'Desarrollo del módulo de login', 15, 12),
(2, 101, 6, 'Diseño de base de datos principal', 10, 10),
(3, 102, 2, 'Organización de capacitaciones internas', 8, 6),
(4, 103, 3, 'Revisión de balances trimestrales', 12, 9),
(5, 104, 4, 'Campaña publicitaria en redes', 20, 18),
(6, 105, 5, 'Control de stock y pedidos', 14, 11);
