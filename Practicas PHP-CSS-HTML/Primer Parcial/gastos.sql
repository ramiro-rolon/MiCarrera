-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-07-2026 a las 16:53:29
-- Versión del servidor: 10.4.27-MariaDB
-- Versión de PHP: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sistemas_gastos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gastos`
--

CREATE TABLE `gastos` (
  `gasto_id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `categoria` varchar(50) NOT NULL,
  `monto` decimal(10,0) NOT NULL,
  `fecha` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `gastos`
--

INSERT INTO `gastos` (`gasto_id`, `descripcion`, `categoria`, `monto`, `fecha`) VALUES
(1, 'Netflix', 'Entretenimiento', '9', '2026-07-14'),
(2, 'Netflix', 'Entretenimiento', '9', '2026-07-14'),
(3, 'Viaje', '5', '35', '2026-07-14'),
(4, 'Viaje', 'Entretenimiento', '347', '2026-07-14'),
(5, 'Viaje', 'Entretenimiento', '347', '2026-07-14'),
(6, 'Viaje', 'Entretenimiento', '347', '2026-07-14'),
(7, 'Viaje', 'Entretenimiento', '347', '2026-07-14'),
(8, 'Viaje', 'Entretenimiento', '347', '2026-07-14'),
(9, 'Carne', 'Alimentos', '35', '2026-07-14'),
(10, 'Carne', 'Alimentos', '35', '2026-07-14'),
(11, 'Carne', 'Alimentos', '35', '2026-07-14'),
(12, 'Carne', 'Alimentos', '35', '2026-07-14'),
(13, 'Computadora', 'Servicios', '36', '2026-07-14'),
(14, 'Computadora', 'Servicios', '36', '2026-07-14'),
(15, 'Cine', 'Entretenimiento', '13', '2026-07-14'),
(16, 'Cine', 'Entretenimiento', '13', '2026-07-14'),
(17, 'Cine', 'Entretenimiento', '13', '2026-07-14'),
(18, 'Cine', 'Entretenimiento', '13', '2026-07-14'),
(19, 'Cine', 'Entretenimiento', '13', '2026-07-14'),
(20, 'Cine', 'Entretenimiento', '13', '2026-07-14'),
(21, 'Computadora', 'Entretenimiento', '526', '2026-07-14');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `gastos`
--
ALTER TABLE `gastos`
  ADD PRIMARY KEY (`gasto_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `gastos`
--
ALTER TABLE `gastos`
  MODIFY `gasto_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
