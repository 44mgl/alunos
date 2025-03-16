-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 21/02/2025 às 01:25
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `bdagenda`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbalunos`
--

CREATE TABLE `tbalunos` (
  `ID` int(11) NOT NULL,
  `nome` varchar(30) DEFAULT NULL,
  `classe` varchar(5) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbalunos`
--

INSERT INTO `tbalunos` (`ID`, `nome`, `classe`, `email`) VALUES
(1, 'Miguel', 'BSI', 'miguel@gmail.com'),
(2, 'Matheus', 'ENG', 'matheus@gmail.com'),
(3, 'Andrea', 'PORT', 'andrea@gmail.com'),
(4, 'Marcos', 'TURB', 'marcos@gmail.com'),
(5, 'Ohanna', 'MEDIC', 'ohanna@gmail.com');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `tbalunos`
--
ALTER TABLE `tbalunos`
  ADD PRIMARY KEY (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
