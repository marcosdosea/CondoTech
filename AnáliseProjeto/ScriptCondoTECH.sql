-- MySQL Script generated by MySQL Workbench
-- Fri Oct 29 14:12:39 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema CondoTech
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema CondoTech
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `CondoTech` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema new_schema1
-- -----------------------------------------------------
USE `CondoTech` ;

-- -----------------------------------------------------
-- Table `CondoTech`.`pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`pessoa` (
  `id_pessoa` INT NOT NULL,
  `nome` VARCHAR(45) NULL,
  `cpf` VARCHAR(15) NULL,
  `telefone` VARCHAR(14) NULL,
  `email` VARCHAR(45) NULL,
  `senha` VARCHAR(45) NULL,
  PRIMARY KEY (`id_pessoa`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`condominio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`condominio` (
  `id_condominio` INT NOT NULL,
  `cnpj` VARCHAR(18) NULL,
  `nome` VARCHAR(45) NULL,
  `telefone` VARCHAR(14) NULL,
  `email` VARCHAR(45) NULL,
  `rua` VARCHAR(45) NULL,
  `bairro` VARCHAR(45) NULL,
  `numero` INT NULL,
  `cep` VARCHAR(45) NULL,
  PRIMARY KEY (`id_condominio`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`ocorrencias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`ocorrencias` (
  `id_ocorrencias` INT NOT NULL,
  `descricao` VARCHAR(45) NULL,
  `tipo` VARCHAR(45) NULL,
  `pessoa_id_pessoa` INT NOT NULL,
  `condominio_id_condominio` INT NOT NULL,
  PRIMARY KEY (`id_ocorrencias`),
  INDEX `fk_ocorrencias_pessoa_idx` (`pessoa_id_pessoa` ASC) VISIBLE,
  INDEX `fk_ocorrencias_condominio1_idx` (`condominio_id_condominio` ASC) VISIBLE,
  CONSTRAINT `fk_ocorrencias_pessoa`
    FOREIGN KEY (`pessoa_id_pessoa`)
    REFERENCES `CondoTech`.`pessoa` (`id_pessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ocorrencias_condominio1`
    FOREIGN KEY (`condominio_id_condominio`)
    REFERENCES `CondoTech`.`condominio` (`id_condominio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`avisos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`avisos` (
  `id_avisos` INT NOT NULL,
  `descricao` VARCHAR(45) NULL,
  `data` DATE NULL,
  `pessoa_id_pessoa` INT NOT NULL,
  `condominio_id_condominio` INT NOT NULL,
  PRIMARY KEY (`id_avisos`, `pessoa_id_pessoa`, `condominio_id_condominio`),
  INDEX `fk_avisos_pessoa1_idx` (`pessoa_id_pessoa` ASC) VISIBLE,
  INDEX `fk_avisos_condominio1_idx` (`condominio_id_condominio` ASC) VISIBLE,
  CONSTRAINT `fk_avisos_pessoa1`
    FOREIGN KEY (`pessoa_id_pessoa`)
    REFERENCES `CondoTech`.`pessoa` (`id_pessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_avisos_condominio1`
    FOREIGN KEY (`condominio_id_condominio`)
    REFERENCES `CondoTech`.`condominio` (`id_condominio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`areaComum`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`areaComum` (
  `id_areaComum` INT NOT NULL,
  `descricao` VARCHAR(45) NULL,
  `hora` TIME NULL,
  `dias` VARCHAR(45) NULL,
  `condominio_id_condominio` INT NOT NULL,
  PRIMARY KEY (`id_areaComum`, `condominio_id_condominio`),
  INDEX `fk_areaComum_condominio1_idx` (`condominio_id_condominio` ASC) VISIBLE,
  CONSTRAINT `fk_areaComum_condominio1`
    FOREIGN KEY (`condominio_id_condominio`)
    REFERENCES `CondoTech`.`condominio` (`id_condominio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`tarefaRecorrente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`tarefaRecorrente` (
  `id_tarefaRecorrente` INT NOT NULL,
  `nome` VARCHAR(45) NULL,
  `descricao` VARCHAR(45) NULL,
  `data` DATE NULL,
  `frequencia` INT NULL,
  `pessoa_id_pessoa` INT NOT NULL,
  PRIMARY KEY (`id_tarefaRecorrente`),
  INDEX `fk_tarefaRecorrente_pessoa1_idx` (`pessoa_id_pessoa` ASC) VISIBLE,
  CONSTRAINT `fk_tarefaRecorrente_pessoa1`
    FOREIGN KEY (`pessoa_id_pessoa`)
    REFERENCES `CondoTech`.`pessoa` (`id_pessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`condominio_has_tarefaRecorrente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`condominio_has_tarefaRecorrente` (
  `condominio_id_condominio` INT NOT NULL,
  `tarefaRecorrente_id_tarefaRecorrente` INT NOT NULL,
  PRIMARY KEY (`condominio_id_condominio`, `tarefaRecorrente_id_tarefaRecorrente`),
  INDEX `fk_condominio_has_tarefaRecorrente_tarefaRecorrente1_idx` (`tarefaRecorrente_id_tarefaRecorrente` ASC) VISIBLE,
  INDEX `fk_condominio_has_tarefaRecorrente_condominio1_idx` (`condominio_id_condominio` ASC) VISIBLE,
  CONSTRAINT `fk_condominio_has_tarefaRecorrente_condominio1`
    FOREIGN KEY (`condominio_id_condominio`)
    REFERENCES `CondoTech`.`condominio` (`id_condominio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_condominio_has_tarefaRecorrente_tarefaRecorrente1`
    FOREIGN KEY (`tarefaRecorrente_id_tarefaRecorrente`)
    REFERENCES `CondoTech`.`tarefaRecorrente` (`id_tarefaRecorrente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`pessoa_has_areaComum`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`pessoa_has_areaComum` (
  `pessoa_id_pessoa` INT NOT NULL,
  `areaComum_id_areaComum` INT NOT NULL,
  PRIMARY KEY (`pessoa_id_pessoa`, `areaComum_id_areaComum`),
  INDEX `fk_pessoa_has_areaComum_areaComum1_idx` (`areaComum_id_areaComum` ASC) VISIBLE,
  INDEX `fk_pessoa_has_areaComum_pessoa1_idx` (`pessoa_id_pessoa` ASC) VISIBLE,
  CONSTRAINT `fk_pessoa_has_areaComum_pessoa1`
    FOREIGN KEY (`pessoa_id_pessoa`)
    REFERENCES `CondoTech`.`pessoa` (`id_pessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_pessoa_has_areaComum_areaComum1`
    FOREIGN KEY (`areaComum_id_areaComum`)
    REFERENCES `CondoTech`.`areaComum` (`id_areaComum`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CondoTech`.`pessoa_has_condominio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `CondoTech`.`pessoa_has_condominio` (
  `pessoa_id_pessoa` INT NOT NULL,
  `condominio_id_condominio` INT NOT NULL,
  PRIMARY KEY (`pessoa_id_pessoa`, `condominio_id_condominio`),
  INDEX `fk_pessoa_has_condominio_condominio1_idx` (`condominio_id_condominio` ASC) VISIBLE,
  INDEX `fk_pessoa_has_condominio_pessoa1_idx` (`pessoa_id_pessoa` ASC) VISIBLE,
  CONSTRAINT `fk_pessoa_has_condominio_pessoa1`
    FOREIGN KEY (`pessoa_id_pessoa`)
    REFERENCES `CondoTech`.`pessoa` (`id_pessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_pessoa_has_condominio_condominio1`
    FOREIGN KEY (`condominio_id_condominio`)
    REFERENCES `CondoTech`.`condominio` (`id_condominio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
