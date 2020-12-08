CREATE DATABASE salutem DEFAULT CHARACTER SET utf8;

USE salutem;

CREATE TABLE salutem.tb_clientes (
  cod_cliente INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  cnpj_cliente VARCHAR(18) NOT NULL,
  razao_social_cliente varchar(255) not null,
  latitude_cliente varchar(255),
  longitude_cliente varchar(255))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE salutem.tb_vendedores (
  cod_vendedor INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  cpf_vendedor VARCHAR(11) NOT NULL,
  nome_vendedor varchar(255) not null,
  latitude_vendedor varchar(255),
  longitude_vendedor varchar(255))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;