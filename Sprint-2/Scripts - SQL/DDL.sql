--Criar banco de dados
CREATE DATABASE RealVagas

--Usar o banco de dados criado
USE RealVagas

--Criações das tabelas DLL
CREATE TABLE DbDados (
	ID	INT PRIMARY KEY IDENTITY,
	Cpf					VARCHAR (14),
	NumMatricula		VARCHAR (255),
	Senha				VARCHAR (255),
);

CREATE TABLE DbTipoUsuario (
	ID	INT PRIMARY KEY IDENTITY,
	Titulo			VARCHAR (255),
);


CREATE TABLE DbEmpresas (
	ID		INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR (255),
	Email			VARCHAR (255),
	Telefone		VARCHAR (20),
	CNPJ			VARCHAR	(20),
	RazaoSocial		VARCHAR (255),
	NomeResponsavel	VARCHAR (255),
	Senha			VARCHAR (255),
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (ID)
);

CREATE TABLE DbUsuarios (
	ID				INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (255),
	DataNascimento		DATE,
	Sexo				VARCHAR (255),
	Escola				VARCHAR (255),
	Email				VARCHAR (255),
	Telefone			VARCHAR (255),
	EstadoCivil			VARCHAR (255),
	Nivel				VARCHAR (255),
	TipoCurso			VARCHAR (255),
	Curso				VARCHAR (255),
	Turma				VARCHAR (255),
	Turno				VARCHAR (255),
	Termo				INT,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (ID),
	IdDados	INT FOREIGN KEY REFERENCES DbDados (ID)
);

CREATE TABLE DbVagas (
	ID				INT PRIMARY KEY IDENTITY,
	NomeRecrutador		VARCHAR (255),
	LocalVaga			VARCHAR (255),
	TipoContrato		VARCHAR (255),
	DataPublicacao		DATE,
	Cargo				VARCHAR (255),
	QntVagas			INT,
	Salario				DECIMAL (18,2),
	Descricao			TEXT,
	Foto				IMAGE,
	StatusVaga			BIT,
	IdEmpresa			INT FOREIGN KEY REFERENCES	Empresas (IdEmpresa),
);

CREATE TABLE DbInscricao (
	ID			INT PRIMARY KEY IDENTITY,
	StatusInscricao		BIT,
	DataInscricao		DATE,
	IdVaga				INT FOREIGN KEY REFERENCES	Vagas  (IdVaga),
	IdAluno				INT FOREIGN KEY REFERENCES	Alunos (IdAluno),
);



