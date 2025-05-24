-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Tempo de geração: 22/05/2025 às 22:43
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
-- Banco de dados: `disciplina_web`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `alunos`
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
-- Despejando dados para a tabela `alunos`
--

INSERT INTO `alunos` (`id`, `ra`, `nome`, `sobrenome`, `curso`, `email`, `cidade`, `ano_ingresso`, `criado_em`) VALUES
(1, '2023001', 'Ana', 'Silva', 'Ciência da Computação', 'ana.silva@email.com', 'São Paulo', 2023, '2025-05-22 17:00:46'),
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
-- Estrutura para tabela `entrega_de_atividades`
--

CREATE TABLE `entrega_de_atividades` (
  `id` int(11) NOT NULL,
  `data_entrega` varchar(20) NOT NULL,
  `aluno` varchar(100) NOT NULL,
  `atividade` varchar(100) NOT NULL,
  `nota` decimal(5,2) NOT NULL,
  `observacoes` text DEFAULT NULL,
  `criado_em` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `entrega_de_atividades`
--

INSERT INTO `entrega_de_atividades` (`id`, `data_entrega`, `aluno`, `atividade`, `nota`, `observacoes`, `criado_em`) VALUES
(1, '2025-04-01', 'Ana Souza', 'Atividade 1', 8.50, 'Entrega no prazo', '2025-05-22 16:44:01'),
(2, '2025-04-05', 'Ana Souza', 'Atividade 2', 9.00, NULL, '2025-05-22 16:44:01'),
(3, '2025-04-10', 'Ana Souza', 'Atividade 3', 7.80, NULL, '2025-05-22 16:44:01'),
(4, '2025-04-15', 'Ana Souza', 'Atividade 4', 9.50, 'Muito boa', '2025-05-22 16:44:01'),
(5, '2025-04-20', 'Ana Souza', 'Atividade 5', 10.00, 'Excelente', '2025-05-22 16:44:01'),
(6, '2025-04-25', 'Ana Souza', 'Atividade 6', 9.20, NULL, '2025-05-22 16:44:01'),
(7, '2025-04-01', 'Bruno Lima', 'Atividade 1', 7.50, NULL, '2025-05-22 16:44:01'),
(8, '2025-04-05', 'Bruno Lima', 'Atividade 2', 6.50, 'Incompleta', '2025-05-22 16:44:01'),
(9, '2025-04-10', 'Bruno Lima', 'Atividade 3', 8.00, NULL, '2025-05-22 16:44:01'),
(10, '2025-04-15', 'Bruno Lima', 'Atividade 4', 7.00, NULL, '2025-05-22 16:44:01'),
(11, '2025-04-25', 'Bruno Lima', 'Atividade 6', 6.80, NULL, '2025-05-22 16:44:01'),
(12, '2025-04-01', 'Carla Dias', 'Atividade 1', 9.00, NULL, '2025-05-22 16:44:01'),
(13, '2025-04-10', 'Carla Dias', 'Atividade 3', 9.50, NULL, '2025-05-22 16:44:01'),
(14, '2025-04-25', 'Carla Dias', 'Atividade 6', 9.80, NULL, '2025-05-22 16:44:01'),
(15, '2025-04-01', 'Daniel Oliveira', 'Atividade 1', 6.50, NULL, '2025-05-22 16:44:01'),
(16, '2025-04-05', 'Daniel Oliveira', 'Atividade 2', 7.20, NULL, '2025-05-22 16:44:01'),
(17, '2025-04-10', 'Daniel Oliveira', 'Atividade 3', 8.00, NULL, '2025-05-22 16:44:01'),
(18, '2025-04-15', 'Daniel Oliveira', 'Atividade 4', 7.80, NULL, '2025-05-22 16:44:01'),
(19, '2025-04-20', 'Daniel Oliveira', 'Atividade 5', 7.50, NULL, '2025-05-22 16:44:01'),
(20, '2025-04-25', 'Daniel Oliveira', 'Atividade 6', 8.10, NULL, '2025-05-22 16:44:01'),
(21, '2025-04-01', 'Eduardo Pereira', 'Atividade 1', 6.00, NULL, '2025-05-22 16:44:01'),
(22, '2025-04-10', 'Eduardo Pereira', 'Atividade 3', 5.80, NULL, '2025-05-22 16:44:01'),
(23, '2025-04-01', 'Fernanda Torres', 'Atividade 1', 8.80, NULL, '2025-05-22 16:44:01'),
(24, '2025-04-05', 'Fernanda Torres', 'Atividade 2', 8.00, NULL, '2025-05-22 16:44:01'),
(25, '2025-04-10', 'Fernanda Torres', 'Atividade 3', 8.50, NULL, '2025-05-22 16:44:01'),
(26, '2025-04-15', 'Fernanda Torres', 'Atividade 4', 9.00, NULL, '2025-05-22 16:44:01'),
(27, '2025-04-01', 'Gabriel Mendes', 'Atividade 1', 7.00, NULL, '2025-05-22 16:44:01'),
(28, '2025-04-05', 'Gabriel Mendes', 'Atividade 2', 7.50, NULL, '2025-05-22 16:44:01'),
(29, '2025-04-10', 'Gabriel Mendes', 'Atividade 3', 6.80, NULL, '2025-05-22 16:44:01'),
(30, '2025-04-15', 'Gabriel Mendes', 'Atividade 4', 7.20, NULL, '2025-05-22 16:44:01'),
(31, '2025-04-20', 'Gabriel Mendes', 'Atividade 5', 7.90, NULL, '2025-05-22 16:44:01'),
(32, '2025-04-25', 'Gabriel Mendes', 'Atividade 6', 8.00, NULL, '2025-05-22 16:44:01'),
(33, '2025-04-01', 'Helena Castro', 'Atividade 1', 9.00, NULL, '2025-05-22 16:44:01'),
(34, '2025-04-01', 'Igor Martins', 'Atividade 1', 6.50, NULL, '2025-05-22 16:44:01'),
(35, '2025-04-05', 'Igor Martins', 'Atividade 2', 7.50, NULL, '2025-05-22 16:44:01'),
(36, '2025-04-10', 'Igor Martins', 'Atividade 3', 6.20, NULL, '2025-05-22 16:44:01'),
(37, '2025-04-15', 'Igor Martins', 'Atividade 4', 5.50, NULL, '2025-05-22 16:44:01'),
(38, '2025-04-01', 'Júlia Ferreira', 'Atividade 1', 9.00, NULL, '2025-05-22 16:44:01'),
(39, '2025-04-05', 'Júlia Ferreira', 'Atividade 2', 8.50, NULL, '2025-05-22 16:44:01'),
(40, '2025-04-10', 'Júlia Ferreira', 'Atividade 3', 9.20, NULL, '2025-05-22 16:44:01'),
(41, '2025-04-15', 'Júlia Ferreira', 'Atividade 4', 8.00, NULL, '2025-05-22 16:44:01'),
(42, '2025-04-20', 'Júlia Ferreira', 'Atividade 5', 7.90, NULL, '2025-05-22 16:44:01'),
(43, '2025-05-22', 'Helena Castro', '2', 4.00, '', '2025-05-22 16:44:56'),
(44, '2025-05-21', 'Diego', '1', 1.00, '', '2025-05-22 17:02:45');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `alunos`
--
ALTER TABLE `alunos`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ra` (`ra`);

--
-- Índices de tabela `entrega_de_atividades`
--
ALTER TABLE `entrega_de_atividades`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `alunos`
--
ALTER TABLE `alunos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `entrega_de_atividades`
--
ALTER TABLE `entrega_de_atividades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
