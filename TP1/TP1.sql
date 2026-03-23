CREATE DATABASE TP1;

USE TP1;

CREATE TABLE Usuarios(
	ID_USUARIOS INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    Edad INT CHECK (Edad > 0),
    CorreoElectronico VARCHAR(100) UNIQUE,
    FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO usuarios(Nombre, Edad, CorreoElectronico)VALUES
('Ramiro', 24, 'ramirorolon1301@gmail.com'),
('Kevin', 29, 'kevoludito@gmail.com'),
('Abigail', 29, 'abispaquepica@gmail.com'),
('Nicolas', 80, 'abuelosansilecio@gmail.com'),
('Renzo', 20, 'tirsomiamor@gmail.com');

/* Ejercicio 3 */

SET SQL_SAFE_UPDATES = 0;

update Usuarios set Edad = 79 where Nombre = 'Nicolas';

/* Ejercicio 4 */

delete from usuarios where CorreoElectronico = 'tirsomiamor@gmail.com';

select
	*
from
	Usuarios;
    
delete from usuarios where CorreoElectronico is null;

/* Ejercicio 5 */

select
	*
from
	usuarios
where
	usuarios.edad > 25;
    
select
	*
from
	usuarios
where
	usuarios.nombre like 'a%';
    
select
	*
from
	usuarios
where
	usuarios.CorreoElectronico not like 'l%';
    
/* Ejercicio 6 */

select
	*
from
	usuarios
order by
	nombre;
    
select
	*
from
	usuarios
where
	edad between 20 and 30
order by
	nombre desc;
    
select distinct nombre
from
	usuarios;
    
/* Ejercicio 7 */

select 
	*
from
	usuarios
where
	nombre in ('Juan', 'Maria', 'Pedro', 'Ana');
    
/* Ejercicio 8 */

update usuarios set edad = edad + 1 ;

/* Ejercicio 9 */

select distinct CorreoElectronico
from usuarios
where edad > 25;

/* Ejercicio 10 */

select avg(edad) as promedio
from usuarios;

select nombre, min(edad)
from usuarios;

select nombre, max(edad)
from usuarios;

/* Voy a agregar mas usuarios a mi tabla para ver mejor el trabajo */

INSERT INTO usuarios(Nombre, Edad, CorreoElectronico) VALUES
('Camila', 22, 'cami22@gmail.com'),
('Joaquín', 31, 'joaco_boss@gmail.com'),
('Lucía', 27, 'lucilove93@hotmail.com'),
('Mateo', 35, 'mateo.retro@gmail.com'),
('Florencia', 28, 'florflor@gmail.com'),
('Martín', 40, 'martin.eljefe@gmail.com'),
('Valentina', 23, 'valen_risingstar@gmail.com'),
('Bruno', 19, 'brunitopunk@gmail.com'),
('Agustina', 33, 'agus33@gmail.com'),
('Santiago', 25, 'santimail25@gmail.com');

INSERT INTO usuarios(Nombre, Edad, CorreoElectronico) VALUES
('Ramiro', 26, 'rami_dos@gmail.com'),
('Camila', 30, 'cami30@hotmail.com'),
('Kevin', 24, 'kevin_thebest@gmail.com'),
('Lucía', 29, 'lucia29@gmail.com'),
('Mateo', 35, 'mateo.second@gmail.com'),
('Abigail', 22, 'abigail_rockstar@gmail.com'),
('Bruno', 21, 'bruno_21@gmail.com'),
('Florencia', 33, 'flor.second@gmail.com'),
('Ramiro', 24, 'rami_extra@gmail.com'),
('Santiago', 27, 'santi.extra@gmail.com');

/* Ejercicio 11*/

select nombre, avg(edad) as promedio
from usuarios group by nombre;

/* Ejercicio 12 */

select nombre, avg(edad) as promedio
from usuarios group by nombre having promedio > 40; 

/* Ejercicio 15 */

create table Pedidos(
	ID_Pedido INT auto_increment primary key,
    ID_Us INT,
    FechaPedido date not null,
    Monto decimal(10,2) check (Monto > 0),
    constraint FK_ID_Usuarios FOREIGN KEY (ID_Us) References usuarios(ID_USUARIOS)
);

drop table Pedidos;

ALTER TABLE Pedidos add Estado varchar(20) not null default 'Pendiente';

/* Ejercicios 16 */

insert into Pedidos (ID_Us, FechaPedido, Monto) values
(9, '2024-03-25', 450.60),
(2, '2024-03-30', 980.10),
(14, '2024-04-02', 1800.00),
(6, '2024-04-05', 300.00),
(10, '2024-04-08', 750.25);

/* Ejercicio 17 */

insert into usuarios(Edad, CorreoElectronico)values
(25, 'motorola@gmail.com');

delete from usuarios where CorreoElectronico = 'motorola@gmail.com';

/* 1 ME TIRA EL SIGUIENTE WARNING	29	19:57:37	insert into usuarios(Edad, CorreoElectronico)values
 (25, 'motorola@gmail.com')	1 row(s) affected, 1 warning(s):
 1364 Field 'Nombre' doesn't have a default value	0.000 sec

Explicacion del Chat:

Estás intentando insertar un nuevo usuario sin indicar el campo Nombre, lo cual no está permitido, pero dependiendo del modo de SQL, MySQL puede:
- Aceptarlo igual y poner un valor vacío o NULL, pero lanzar un warning, o
- Directamente tirar error, si el modo STRICT está activado.

 */
 
 INSERT INTO usuarios(Nombre, Edad, CorreoElectronico) VALUES
('Ramiro', 26, 'rami_dos@gmail.com');

/* Aca directamente te tira error */
 
 /* Ejercicio 18 */ 
 
insert into usuarios (Nombre, Edad, CorreoElectronico) values
('Renzo', 19, 'renzoenmexicojijolines@gmail.com');

select * from usuarios where CorreoElectronico = 'renzoenmexicojijolines@gmail.com';

/* Ejercicio 19 */

select us.nombre, p.monto from usuarios as us inner join pedidos as p;

/* Ejercicio 20 */

select us.nombre, p.monto from usuarios as us left join pedidos as p on us.ID_USUARIOS = p.ID_Us;

/* Ejercicio 21 */

select us.nombre, p.monto from usuarios as us right join pedidos as p on us.ID_USUARIOS = p. ID_Us;

/* Ejercicio 22 */

select us.nombre, p.monto, p.fechapedido from usuarios as us inner join pedidos as p on us.ID_USUARIOS = p.ID_Us where p.monto > 100 order by p.fechapedido;

/* Ejercicio 13*/

select * from usuarios order by edad limit 3;

select * from usuarios order by edad desc limit 2;

/* Ejercicio 14 */

select distinct nombre from usuarios where edad between 20 and 35 order by nombre limit 5;