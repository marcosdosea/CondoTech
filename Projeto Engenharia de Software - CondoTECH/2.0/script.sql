CREATE DATABASE projeto

USE projeto

CREATE TABLE TB_PESSOA (
  id_pessoa INT NOT NULL PRIMARY KEY,
  nome VARCHAR(100) NOT NULL,
  telefone VARCHAR(100) NOT NULL,
  email VARCHAR(100) NOT NULL,
  senha VARCHAR(100) NOT NULL,
)

CREATE TABLE TB_OCORRENCIAS (
  id_ocorrencias INT NOT NULL PRIMARY KEY,
  descricao VARCHAR(100) NOT NULL,
  tipo VARCHAR(100) NOT NULL,
)

CREATE TABLE TB_CONDOMINIO (
  id_condominio INT NOT NULL PRIMARY KEY,
  cnpj int NOT NULL,
  nome VARCHAR(100) NOT NULL,
  telefone int NOT NULL,
  email VARCHAR(100) NOT NULL,
  rua VARCHAR(100) NOT NULL,
  bairro VARCHAR(100) NOT NULL,
  numero int NOT NULL,
  cep VARCHAR(45) NOT NULL,
)

CREATE TABLE TB_TAREFA_RECORRENTE (
  id_tarefas_recente INT NOT NULL PRIMARY KEY,
  nome VARCHAR(100) NOT NULL,
  descricao VARCHAR(100) NOT NULL,
  data int NOT NULL,
  frequencia int NOT NULL,
)
CREATE TABLE TB_AREA_COMUM (
  id_area_comum INT NOT NULL PRIMARY KEY,
  descricao VARCHAR(100) NOT NULL,
  horas int NOT NULL,
  dias VARCHAR(100) NOT NULL,
)
CREATE TABLE TB_AVISOS (
  id_avisos INT NOT NULL PRIMARY KEY,
  descricao VARCHAR(100) NOT NULL,
  data int NOT NULL,
)
