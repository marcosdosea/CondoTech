CREATE DATABASE  IF NOT EXISTS `condotech` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `condotech`;
-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: condotech
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `administradores`
--

DROP TABLE IF EXISTS `administradores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administradores` (
  `idPessoa` int NOT NULL,
  `idCondominio` int NOT NULL,
  `tipo` enum('SINDICO','VICE') DEFAULT NULL,
  PRIMARY KEY (`idPessoa`,`idCondominio`),
  KEY `fk_pessoa_has_condominio_condominio2_idx` (`idCondominio`),
  KEY `fk_pessoa_has_condominio_pessoa2_idx` (`idPessoa`),
  CONSTRAINT `fk_pessoa_has_condominio_condominio2` FOREIGN KEY (`idCondominio`) REFERENCES `condominio` (`idCondominio`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_pessoa_has_condominio_pessoa2` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administradores`
--

LOCK TABLES `administradores` WRITE;
/*!40000 ALTER TABLE `administradores` DISABLE KEYS */;
/*!40000 ALTER TABLE `administradores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `areacomum`
--

DROP TABLE IF EXISTS `areacomum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `areacomum` (
  `idAreaComum` int NOT NULL AUTO_INCREMENT,
  `idCondominio` int NOT NULL,
  `nome` varchar(45) NOT NULL,
  `descricao` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idAreaComum`),
  KEY `fk_areaComum_condominio1_idx` (`idCondominio`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `areacomum`
--

LOCK TABLES `areacomum` WRITE;
/*!40000 ALTER TABLE `areacomum` DISABLE KEYS */;
/*!40000 ALTER TABLE `areacomum` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1','CONDOMINO','CONDOMINO',NULL),('2','SINDICO','SINDICO',NULL),('3','VICE_SINDICO','VICE_SINDICO',NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(767) NOT NULL,
  `RoleId` varchar(767) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('b0d99040-23fe-4852-9b9f-fdc917822271','2'),('eae76f95-75e3-4a71-852c-0651495d290d','2'),('19c5e0ef-e7a8-4ecf-b007-b668eec9340e','3');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('19c5e0ef-e7a8-4ecf-b007-b668eec9340e','teste123@gmail.com','TESTE123@GMAIL.COM','teste123@gmail.com','TESTE123@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEAUzABoDtQGNgxGzxDVFyNxqjbsQNsBdUNthotLsMKwpohLR5lDz8EhxsTyeyZEC1w==','WZNREYJ742CJO5LX5E2XBR64AWLXIM4Z','dd200bb1-3785-45e2-abcd-89b9fa04f7ea',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('b0d99040-23fe-4852-9b9f-fdc917822271','sindico@gmail.com','SINDICO@GMAIL.COM','sindico@gmail.com','SINDICO@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEJTYszhDLU/KXneoIE8rmoHADnlkhL7ZSqfHsB0DSldCqeo3NkFZC3Bj4FBeu5vN4w==','O455A34O3NWCAJ6RR35VEW4MPW5NILTG','e1214ff8-9305-40c8-a9d2-487f5b96cede',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('eae76f95-75e3-4a71-852c-0651495d290d','raulcarira@gmail.com','RAULCARIRA@GMAIL.COM','raulcarira@gmail.com','RAULCARIRA@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEBgyU3YLhCMvmMtNGuGAzkFj8T5ndRoT9c88I2E03N7mWwH5QgXp+tddncLQqpAnlA==','YLM26GQF4BRIMF4TOUDL7ZF53AJJEFYP','e68f4e7e-b581-4cc9-a115-a6f94e64bce3',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(767) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
INSERT INTO `aspnetusertokens` VALUES ('19c5e0ef-e7a8-4ecf-b007-b668eec9340e','[AspNetUserStore]','AuthenticatorKey','E3LYEZEHUPQXLGCJZOW7NBMHKBMIV7U2');
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aviso`
--

DROP TABLE IF EXISTS `aviso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aviso` (
  `idAviso` int NOT NULL,
  `descricao` varchar(1000) NOT NULL,
  `data` datetime NOT NULL,
  `idPessoa` int NOT NULL,
  `idCondominio` int NOT NULL,
  PRIMARY KEY (`idAviso`,`idPessoa`,`idCondominio`),
  KEY `fk_avisos_pessoa1_idx` (`idPessoa`),
  KEY `fk_avisos_condominio1_idx` (`idCondominio`),
  CONSTRAINT `fk_avisos_pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aviso`
--

LOCK TABLES `aviso` WRITE;
/*!40000 ALTER TABLE `aviso` DISABLE KEYS */;
/*!40000 ALTER TABLE `aviso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `condominio`
--

DROP TABLE IF EXISTS `condominio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `condominio` (
  `idCondominio` int NOT NULL,
  `cnpj` varchar(18) DEFAULT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `telefone` varchar(14) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `rua` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `numero` int DEFAULT NULL,
  `cep` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCondominio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `condominio`
--

LOCK TABLES `condominio` WRITE;
/*!40000 ALTER TABLE `condominio` DISABLE KEYS */;
INSERT INTO `condominio` VALUES (1,'111111111111111111','condominio com falta de luxo','(79)998836127','Sdasda@askna.com','seinaoaaaaaaaaaaaaa','seinaoaaaaaaaaaaaa',1,'49.500-000aaaaaaaaaa');
/*!40000 ALTER TABLE `condominio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `condomino`
--

DROP TABLE IF EXISTS `condomino`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `condomino` (
  `idPessoa` int NOT NULL,
  `idCondominio` int NOT NULL,
  PRIMARY KEY (`idPessoa`,`idCondominio`),
  KEY `fk_pessoa_has_condominio_condominio1_idx` (`idCondominio`),
  KEY `fk_pessoa_has_condominio_pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_pessoa_has_condominio_condominio1` FOREIGN KEY (`idCondominio`) REFERENCES `condominio` (`idCondominio`),
  CONSTRAINT `fk_pessoa_has_condominio_pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `condomino`
--

LOCK TABLES `condomino` WRITE;
/*!40000 ALTER TABLE `condomino` DISABLE KEYS */;
/*!40000 ALTER TABLE `condomino` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disponibilidadearea`
--

DROP TABLE IF EXISTS `disponibilidadearea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disponibilidadearea` (
  `idDisponibilidadeArea` int NOT NULL AUTO_INCREMENT,
  `diaSemana` enum('SEGUNDA','TERCA','QUARTA','QUINTA','SEXTA','SABADO','DOMINGO') NOT NULL,
  `horaInicio` time NOT NULL,
  `horaFim` time NOT NULL,
  `vagas` int NOT NULL DEFAULT '1',
  `idAreaComum` int NOT NULL,
  PRIMARY KEY (`idDisponibilidadeArea`),
  KEY `fk_DisponibilidadeArea_areaComum1_idx` (`idAreaComum`),
  CONSTRAINT `fk_DisponibilidadeArea_areaComum1` FOREIGN KEY (`idAreaComum`) REFERENCES `areacomum` (`idAreaComum`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disponibilidadearea`
--

LOCK TABLES `disponibilidadearea` WRITE;
/*!40000 ALTER TABLE `disponibilidadearea` DISABLE KEYS */;
/*!40000 ALTER TABLE `disponibilidadearea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `execucaotarefarecorrente`
--

DROP TABLE IF EXISTS `execucaotarefarecorrente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `execucaotarefarecorrente` (
  `idCondominio` int NOT NULL,
  `idTarefaRecorrente` int NOT NULL,
  `dataExecucao` datetime NOT NULL,
  `idPessoa` int NOT NULL,
  PRIMARY KEY (`idCondominio`,`idTarefaRecorrente`),
  KEY `fk_condominio_has_tarefaRecorrente_tarefaRecorrente1_idx` (`idTarefaRecorrente`),
  KEY `fk_condominio_has_tarefaRecorrente_condominio1_idx` (`idCondominio`),
  KEY `fk_ExecucaoTarefaRecorrente_pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_condominio_has_tarefaRecorrente_condominio1` FOREIGN KEY (`idCondominio`) REFERENCES `condominio` (`idCondominio`),
  CONSTRAINT `fk_condominio_has_tarefaRecorrente_tarefaRecorrente1` FOREIGN KEY (`idTarefaRecorrente`) REFERENCES `tarefarecorrente` (`idTarefaRecorrente`),
  CONSTRAINT `fk_ExecucaoTarefaRecorrente_pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `execucaotarefarecorrente`
--

LOCK TABLES `execucaotarefarecorrente` WRITE;
/*!40000 ALTER TABLE `execucaotarefarecorrente` DISABLE KEYS */;
/*!40000 ALTER TABLE `execucaotarefarecorrente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ocorrencias`
--

DROP TABLE IF EXISTS `ocorrencias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ocorrencias` (
  `idOcorrencia` int NOT NULL,
  `descricao` varchar(500) NOT NULL,
  `idPessoa` int NOT NULL,
  `idCondominio` int NOT NULL,
  `idTipoOcorrencia` int NOT NULL,
  PRIMARY KEY (`idOcorrencia`),
  KEY `fk_ocorrencias_pessoa_idx` (`idPessoa`),
  KEY `fk_ocorrencias_condominio1_idx` (`idCondominio`),
  KEY `fk_ocorrencias_tipoOcorrencia1_idx` (`idTipoOcorrencia`),
  CONSTRAINT `fk_ocorrencias_pessoa` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`),
  CONSTRAINT `fk_ocorrencias_tipoOcorrencia1` FOREIGN KEY (`idTipoOcorrencia`) REFERENCES `tipoocorrencia` (`idTipoOcorrencia`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ocorrencias`
--

LOCK TABLES `ocorrencias` WRITE;
/*!40000 ALTER TABLE `ocorrencias` DISABLE KEYS */;
/*!40000 ALTER TABLE `ocorrencias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `idPessoa` int NOT NULL,
  `nome` varchar(45) NOT NULL,
  `cpf` varchar(15) NOT NULL,
  `telefone` varchar(14) NOT NULL,
  `email` varchar(45) NOT NULL,
  `senha` varchar(45) NOT NULL,
  `status` enum('ATIVO','BLOQUEADO','EXCLUIDO') NOT NULL DEFAULT 'BLOQUEADO',
  PRIMARY KEY (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'Raul ','00000000000','79999999999','raul@gmail.com','1234567890','ATIVO'),(2,'Raul ','00000000000','79999999999','raul@gmail.com','1234567890','ATIVO');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `idPessoa` int NOT NULL,
  `idAreaComum` int NOT NULL,
  `idDisponibilidadeArea` int NOT NULL,
  `data` datetime NOT NULL,
  `vagasReservadas` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`idPessoa`,`idAreaComum`),
  KEY `fk_pessoa_has_areaComum_areaComum1_idx` (`idAreaComum`),
  KEY `fk_pessoa_has_areaComum_pessoa1_idx` (`idPessoa`),
  KEY `fk_Reserva_DisponibilidadeArea1_idx` (`idDisponibilidadeArea`),
  CONSTRAINT `fk_pessoa_has_areaComum_areaComum1` FOREIGN KEY (`idAreaComum`) REFERENCES `areacomum` (`idAreaComum`),
  CONSTRAINT `fk_pessoa_has_areaComum_pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`),
  CONSTRAINT `fk_Reserva_DisponibilidadeArea1` FOREIGN KEY (`idDisponibilidadeArea`) REFERENCES `disponibilidadearea` (`idDisponibilidadeArea`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarefarecorrente`
--

DROP TABLE IF EXISTS `tarefarecorrente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tarefarecorrente` (
  `idTarefaRecorrente` int NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `repeticaoDias` int DEFAULT NULL,
  PRIMARY KEY (`idTarefaRecorrente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarefarecorrente`
--

LOCK TABLES `tarefarecorrente` WRITE;
/*!40000 ALTER TABLE `tarefarecorrente` DISABLE KEYS */;
/*!40000 ALTER TABLE `tarefarecorrente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoocorrencia`
--

DROP TABLE IF EXISTS `tipoocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipoocorrencia` (
  `idTipoOcorrencia` int NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) NOT NULL,
  PRIMARY KEY (`idTipoOcorrencia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoocorrencia`
--

LOCK TABLES `tipoocorrencia` WRITE;
/*!40000 ALTER TABLE `tipoocorrencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipoocorrencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'condotech'
--

--
-- Dumping routines for database 'condotech'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-17 21:30:34
