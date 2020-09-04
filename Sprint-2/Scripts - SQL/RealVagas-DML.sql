--Criar banco de dados
CREATE DATABASE RealVagas

--Usar o banco de dados criado
USE RealVagas

--Criações das tabelas DLL
CREATE TABLE DadosSigilosos (
	IdDadosSigilosos	INT PRIMARY KEY IDENTITY,
	Cpf					VARCHAR (14),
	NumMatricula		VARCHAR (20),
	Senha				VARCHAR (255),
);

CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Titulo			VARCHAR (255),
);

CREATE TABLE Adm (
	IdAdm			INT PRIMARY KEY IDENTITY,
	NomeAdm			VARCHAR (255),
	DataNascimento	DATE,
	Sexo			BIT,
);

CREATE TABLE Empresas (
	IdEmpresa		INT PRIMARY KEY IDENTITY,
	NomeEmpresa		VARCHAR (255),
	Email			VARCHAR (255),
	Telefone		VARCHAR (20),
	CNPJ			VARCHAR	(20),
	RazaoSocial		VARCHAR (255),
	Senha			VARCHAR (255),
	NomeResponsavel	VARCHAR (255),
);

CREATE TABLE Alunos (
	IdAluno				INT PRIMARY KEY IDENTITY,
	NomeAluno			VARCHAR (255),
	DataNascimento		DATE,
	Sexo				BIT,
	Escola				VARCHAR (255),
	Email				VARCHAR (255),
	Telefone			VARCHAR (20),
	EstadoCivil			VARCHAR (120),
	Nivel				VARCHAR (255),
	TipoCurso			VARCHAR (255),
	Curso				VARCHAR (255),
	Turma				VARCHAR (120),
	Turno				VARCHAR (120),
	Termo				INT,
	IdDadosSigiolosos	INT FOREIGN KEY REFERENCES DadosSigilosos (IdDadosSigilosos)
);

CREATE TABLE Vagas (
	IdVaga				INT PRIMARY KEY IDENTITY,
	NomeRecrutador		VARCHAR (255),
	LocalVaga			VARCHAR (255),
	TipoContrato		VARCHAR (255),
	Cargo				VARCHAR (255),
	QntVagas			INT,
	Salario				VARCHAR (255),
	Descricao			VARCHAR (255),
	Foto				IMAGE,
	StatusVaga			BIT,
	IdEmpresa			INT FOREIGN KEY REFERENCES	Empresas (IdEmpresa),
);

CREATE TABLE Inscricao (
	IdInscricao			INT PRIMARY KEY IDENTITY,
	StatusInscricao		BIT,
	DataInscricao		DATE,
	IdVaga				INT FOREIGN KEY REFERENCES	Vagas  (IdVaga),
	IdAluno				INT FOREIGN KEY REFERENCES	Alunos (IdAluno),
);


--Alterar uma coluna da tabela Vagas
ALTER TABLE Vagas
ALTER COLUMN Salario DECIMAL (18,2)

ALTER TABLE VAGAS
ALTER COLUMN Descricao TEXT
