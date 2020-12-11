-- phpMyAdmin SQL Dump
-- version 4.8.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 10-Dez-2020 às 23:53
-- Versão do servidor: 10.1.31-MariaDB
-- PHP Version: 7.2.4

SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `salutem`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_clientes`
--

CREATE TABLE `tb_clientes` (
  `cod_cliente` int(11) NOT NULL,
  `cod_vendedor` int(11) DEFAULT NULL,
  `cnpj_cliente` varchar(18) NOT NULL,
  `razao_social_cliente` varchar(255) NOT NULL,
  `latitude_cliente` varchar(255) NOT NULL,
  `longitude_cliente` varchar(255) NOT NULL,
  `distancia` varchar(255) DEFAULT NULL,
  `dt_cad_cliente` datetime NOT NULL
) ;

--
-- Extraindo dados da tabela `tb_clientes`
--

INSERT INTO `tb_clientes` (`cod_cliente`, `cod_vendedor`, `cnpj_cliente`, `razao_social_cliente`, `latitude_cliente`, `longitude_cliente`, `distancia`, `dt_cad_cliente`) VALUES
(1, NULL, '15.028.346/0001-75', 'CASA DAS CARNES', '-21.359414732721056', '-51.86107644223186', NULL, '2020-12-10 18:23:11'),
(2, NULL, '34.023.206/0001-59', 'MERCADO FORTALEZA', '-21.485814434571548', '-51.52499550229352', NULL, '2020-12-10 18:24:34'),
(3, NULL, '42.199.901/0001-02', 'MERCADO TROYANO', '-21.486250968532453', '-51.54448267616066', NULL, '2020-12-10 18:25:22'),
(4, NULL, '51.499.524/0001-00', 'MERCADO RECANTO', '-21.490429285750043', '-51.55879443050004', NULL, '2020-12-10 18:26:24');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_vendedores`
--

CREATE TABLE `tb_vendedores` (
  `cod_vendedor` int(11) NOT NULL,
  `cpf_vendedor` varchar(14) NOT NULL,
  `nome_vendedor` varchar(255) NOT NULL,
  `latitude_vendedor` varchar(255) NOT NULL,
  `longitude_vendedor` varchar(255) NOT NULL,
  `dt_cad_vendedor` datetime NOT NULL
) ;

--
-- Extraindo dados da tabela `tb_vendedores`
--

INSERT INTO `tb_vendedores` (`cod_vendedor`, `cpf_vendedor`, `nome_vendedor`, `latitude_vendedor`, `longitude_vendedor`, `dt_cad_vendedor`) VALUES
(1, '436.645.578-16', 'ALEX JUNIO SAPUCAIA VIANA', '-21.4795709346627', ' -51.51685665933627', '2020-12-10 18:18:00'),
(2, '070.883.310-12', 'MARIA JOSE GONCALVES SAPUCAIA', '-21.493061654660394', '-51.5569563305', '2020-12-10 18:18:55'),
(3, '034.232.420-94', 'JOSE DA SILVA', '-21.349736337279573', '-51.75509932411767', '2020-12-10 18:20:53');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_clientes`
--
ALTER TABLE `tb_clientes`
  ADD PRIMARY KEY (`cod_cliente`),
  ADD KEY `fk_vendedor` (`cod_vendedor`);

--
-- Indexes for table `tb_vendedores`
--
ALTER TABLE `tb_vendedores`
  ADD PRIMARY KEY (`cod_vendedor`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_clientes`
--
ALTER TABLE `tb_clientes`
  MODIFY `cod_cliente` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_vendedores`
--
ALTER TABLE `tb_vendedores`
  MODIFY `cod_vendedor` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `tb_clientes`
--
ALTER TABLE `tb_clientes`
  ADD CONSTRAINT `fk_vendedor` FOREIGN KEY (`cod_vendedor`) REFERENCES `tb_vendedores` (`cod_vendedor`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
