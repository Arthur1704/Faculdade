-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 05-Jun-2025 às 06:05
-- Versão do servidor: 10.4.32-MariaDB
-- versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `disciplina_web`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `alunos`
--

CREATE TABLE `alunos` (
  `id` int(11) NOT NULL,
  `ra` varchar(20) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `sobrenome` varchar(100) NOT NULL,
  `curso` varchar(100) NOT NULL,
  `email` varchar(150) NOT NULL,
  `cidade` varchar(100) NOT NULL,
  `ano_ingresso` int(11) NOT NULL,
  `criado_em` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Extraindo dados da tabela `alunos`
--

INSERT INTO `alunos` (`id`, `ra`, `nome`, `sobrenome`, `curso`, `email`, `cidade`, `ano_ingresso`, `criado_em`) VALUES
(2, '2023002', 'Bruno', 'Oliveira', 'TADS', 'bruno.oliveira@email.com', 'Campinas', 2022, '2025-05-22 17:00:46'),
(3, '2023003', 'Carla', 'Souza', 'Ciência da Computação', 'carla.souza@email.com', 'Ribeirão Preto', 2023, '2025-05-22 17:00:46'),
(4, '2023004', 'Diego', 'Santos', 'TADS', 'diego.santos@email.com', 'Sorocaba', 2021, '2025-05-22 17:00:46'),
(5, '2023005', 'Eduarda', 'Ferreira', 'Ciência da Computação', 'eduarda.ferreira@email.com', 'Bauru', 2024, '2025-05-22 17:00:46'),
(6, '2023006', 'Felipe', 'Pereira', 'TADS', 'felipe.pereira@email.com', 'São Carlos', 2023, '2025-05-22 17:00:46'),
(7, '2023007', 'Gabriela', 'Martins', 'Ciência da Computação', 'gabriela.martins@email.com', 'Araraquara', 2022, '2025-05-22 17:00:46'),
(8, '2023008', 'Henrique', 'Rodrigues', 'TADS', 'henrique.rodrigues@email.com', 'Franca', 2023, '2025-05-22 17:00:46'),
(9, '2023009', 'Isabela', 'Lima', 'Ciência da Computação', 'isabela.lima@email.com', 'Jundiaí', 2021, '2025-05-22 17:00:46'),
(10, '2023010', 'João', 'Almeida', 'TADS', 'joao.almeida@email.com', 'Piracicaba', 2024, '2025-05-22 17:00:46');

-- --------------------------------------------------------

--
-- Estrutura da tabela `atividades`
--

CREATE TABLE `atividades` (
  `cod_atividade` int(11) NOT NULL,
  `nome_atividade` varchar(50) NOT NULL,
  `data_entrega` date NOT NULL,
  `data_inicio` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `atividades`
--

INSERT INTO `atividades` (`cod_atividade`, `nome_atividade`, `data_entrega`, `data_inicio`) VALUES
(1, 'Atividade Ranking', '0000-00-00', '2025-06-05 04:46:16'),
(2, 'Atividade SQL', '2025-06-12', '2025-06-05 04:47:16');

-- --------------------------------------------------------

--
-- Estrutura da tabela `entrega_de_atividades`
--

CREATE TABLE `entrega_de_atividades` (
  `id` int(11) NOT NULL,
  `data_entrega` varchar(20) NOT NULL,
  `aluno` varchar(100) NOT NULL,
  `cod_atividade` int(11) NOT NULL,
  `nota` decimal(5,2) NOT NULL,
  `observacoes` text DEFAULT NULL,
  `criado_em` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Extraindo dados da tabela `entrega_de_atividades`
--

INSERT INTO `entrega_de_atividades` (`id`, `data_entrega`, `aluno`, `cod_atividade`, `nota`, `observacoes`, `criado_em`) VALUES
(1, '2025-04-01', 'Ana Souza', 1, 8.50, 'Entrega no prazo', '2025-05-22 16:44:01'),
(2, '2025-04-05', 'Ana Souza', 1, 9.00, NULL, '2025-05-22 16:44:01'),
(3, '2025-04-10', 'Ana Souza', 1, 7.80, NULL, '2025-05-22 16:44:01'),
(4, '2025-04-15', 'Ana Souza', 1, 9.50, 'Muito boa', '2025-05-22 16:44:01'),
(5, '2025-04-20', 'Ana Souza', 1, 10.00, 'Excelente', '2025-05-22 16:44:01'),
(6, '2025-04-25', 'Ana Souza', 1, 9.20, NULL, '2025-05-22 16:44:01'),
(7, '2025-04-01', 'Bruno Lima', 1, 7.50, NULL, '2025-05-22 16:44:01'),
(8, '2025-04-05', 'Bruno Lima', 1, 6.50, 'Incompleta', '2025-05-22 16:44:01'),
(9, '2025-04-10', 'Bruno Lima', 1, 8.00, NULL, '2025-05-22 16:44:01'),
(10, '2025-04-15', 'Bruno Lima', 1, 7.00, NULL, '2025-05-22 16:44:01'),
(11, '2025-04-25', 'Bruno Lima', 1, 6.80, NULL, '2025-05-22 16:44:01'),
(12, '2025-04-01', 'Carla Dias', 1, 9.00, NULL, '2025-05-22 16:44:01'),
(13, '2025-04-10', 'Carla Dias', 1, 9.50, NULL, '2025-05-22 16:44:01'),
(14, '2025-04-25', 'Carla Dias', 1, 9.80, NULL, '2025-05-22 16:44:01'),
(15, '2025-04-01', 'Daniel Oliveira', 1, 6.50, NULL, '2025-05-22 16:44:01'),
(16, '2025-04-05', 'Daniel Oliveira', 1, 7.20, NULL, '2025-05-22 16:44:01'),
(17, '2025-04-10', 'Daniel Oliveira', 1, 8.00, NULL, '2025-05-22 16:44:01'),
(18, '2025-04-15', 'Daniel Oliveira', 1, 7.80, NULL, '2025-05-22 16:44:01'),
(19, '2025-04-20', 'Daniel Oliveira', 1, 7.50, NULL, '2025-05-22 16:44:01'),
(20, '2025-04-25', 'Daniel Oliveira', 1, 8.10, NULL, '2025-05-22 16:44:01'),
(21, '2025-04-01', 'Eduardo Pereira', 1, 6.00, NULL, '2025-05-22 16:44:01'),
(22, '2025-04-10', 'Eduardo Pereira', 2, 5.80, NULL, '2025-05-22 16:44:01'),
(23, '2025-04-01', 'Fernanda Torres', 3, 8.80, NULL, '2025-05-22 16:44:01'),
(24, '2025-04-05', 'Fernanda Torres', 1, 8.00, NULL, '2025-05-22 16:44:01'),
(25, '2025-04-10', 'Fernanda Torres', 1, 8.50, NULL, '2025-05-22 16:44:01'),
(26, '2025-04-15', 'Fernanda Torres', 1, 9.00, NULL, '2025-05-22 16:44:01'),
(27, '2025-04-01', 'Gabriel Mendes', 1, 7.00, NULL, '2025-05-22 16:44:01'),
(28, '2025-04-05', 'Gabriel Mendes', 1, 7.50, NULL, '2025-05-22 16:44:01'),
(29, '2025-04-10', 'Gabriel Mendes', 1, 6.80, NULL, '2025-05-22 16:44:01'),
(30, '2025-04-15', 'Gabriel Mendes', 1, 7.20, NULL, '2025-05-22 16:44:01'),
(31, '2025-04-20', 'Gabriel Mendes', 1, 7.90, NULL, '2025-05-22 16:44:01'),
(32, '2025-04-25', 'Gabriel Mendes', 1, 8.00, NULL, '2025-05-22 16:44:01'),
(33, '2025-04-01', 'Helena Castro', 1, 9.00, NULL, '2025-05-22 16:44:01'),
(34, '2025-04-01', 'Igor Martins', 1, 6.50, NULL, '2025-05-22 16:44:01'),
(35, '2025-04-05', 'Igor Martins', 1, 7.50, NULL, '2025-05-22 16:44:01'),
(36, '2025-04-10', 'Igor Martins', 1, 6.20, NULL, '2025-05-22 16:44:01'),
(37, '2025-04-15', 'Igor Martins', 1, 5.50, NULL, '2025-05-22 16:44:01'),
(38, '2025-04-01', 'Júlia Ferreira', 1, 9.00, NULL, '2025-05-22 16:44:01'),
(39, '2025-04-05', 'Júlia Ferreira', 1, 8.50, NULL, '2025-05-22 16:44:01'),
(40, '2025-04-10', 'Júlia Ferreira', 1, 9.20, NULL, '2025-05-22 16:44:01'),
(41, '2025-04-15', 'Júlia Ferreira', 1, 8.00, NULL, '2025-05-22 16:44:01'),
(42, '2025-04-20', 'Júlia Ferreira', 1, 7.90, NULL, '2025-05-22 16:44:01'),
(43, '2025-05-22', 'Helena Castro', 2, 4.00, '', '2025-05-22 16:44:56'),
(44, '2025-05-21', 'Diego', 1, 1.00, '', '2025-05-22 17:02:45'),
(45, '2025-06-05', 'Arthur', 0, 10.00, 'Top demais a Atividade', '2025-06-05 05:06:18'),
(46, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 05:08:52'),
(47, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 05:11:09'),
(48, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(49, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(50, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(51, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(52, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(53, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(54, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(55, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(56, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(57, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(58, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(59, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(60, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(61, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(62, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(63, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(64, '2025-06-05', 'Arthur', 0, 10.00, 'wdqw', '2025-06-05 00:00:00'),
(65, '2025-06-05', 'Arthur', 1, 10.00, '', '2025-06-05 00:00:00'),
(66, '2025-06-05', 'Arthur', 2, 10.00, '', '2025-06-05 00:00:00'),
(67, '2025-06-05', 'Arthur', 2, 10.00, '', '2025-06-05 00:00:00'),
(68, '2025-06-05', 'Arthur', 2, 10.00, '', '2025-06-05 00:00:00'),
(69, '2025-06-05', 'Arthur', 1, 10.00, 'axsas', '2025-06-05 00:00:00');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `alunos`
--
ALTER TABLE `alunos`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ra` (`ra`);

--
-- Índices para tabela `atividades`
--
ALTER TABLE `atividades`
  ADD PRIMARY KEY (`cod_atividade`);

--
-- Índices para tabela `entrega_de_atividades`
--
ALTER TABLE `entrega_de_atividades`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `alunos`
--
ALTER TABLE `alunos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de tabela `atividades`
--
ALTER TABLE `atividades`
  MODIFY `cod_atividade` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `entrega_de_atividades`
--
ALTER TABLE `entrega_de_atividades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=70;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
