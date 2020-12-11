/*drop database salutem;*/
CREATE DATABASE salutem DEFAULT CHARACTER SET utf8;

USE salutem;

CREATE TABLE salutem.tb_vendedores (
  cod_vendedor INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  cpf_vendedor VARCHAR(14) NOT NULL,
  nome_vendedor VARCHAR(255) NOT NULL,
  latitude_vendedor VARCHAR(255) NOT NULL,
  longitude_vendedor VARCHAR(255) NOT NULL,
  dt_cad_vendedor DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE salutem.tb_clientes (
  cod_cliente INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  cod_vendedor INT,
  cnpj_cliente VARCHAR(18) NOT NULL,
  razao_social_cliente VARCHAR(255) NOT NULL,
  latitude_cliente VARCHAR(255) NOT NULL,
  longitude_cliente VARCHAR(255) NOT NULL,
  distancia VARCHAR(255),
  dt_cad_cliente DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  CONSTRAINT fk_vendedor FOREIGN KEY (cod_vendedor) REFERENCES tb_vendedores (cod_vendedor))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

