--Usar o banco de dados criado
USE RealVagas

--SELECIONA TODAS AS TABELAS.

SELECT * FROM DbDados;
SELECT * FROM DbTipoUsuario;
SELECT * FROM DbAdministradores;
SELECT * FROM DbEmpresas;
SELECT * FROM DbAlunos;
SELECT * FROM DbVagas;
SELECT * FROM DbInscricao;


--SELECIONA PELO EMAIL DO ALUNO, EMPRESA OU ADMINISTRADOR
SELECT NomeAdm FROM DbAdministradores WHERE Email LIKE '@SENAI.COM@' ORDER BY Nome ASC;

SELECT Email FROM DbEmpresas WHERE Email LIKE '@SPACE.COM@' ORDER BY Nome ASC;

SELECT Email FROM DbAlunos WHERE Email LIKE '@GMAIL.COM@' ORDER BY Nome ASC;


--SELECIONA DADOS SIGILOSOS COM TABELA ALUNOS
SELECT * FROM DbAlunos INNER JOIN DbDados ON DbDados.ID  = DbAlunos.IdDados ORDER BY DataNascimento ASC;

--SELECIONA ALUNO ATRAVÉS DA ESCOLA
SELECT NomeAluno,DataNascimento,Sexo,Email,Telefone,Turno,Curso FROM DbAlunos
WHERE Escola LIKE '@Senai Informatica@' ORDER BY Nome ASC;


--SELECIONA EMPRESA E VAGA 
SELECT NomeEmpresa,CNPJ,Telefone,NomeRecrutador,Salario,LocalVaga,Descricao  FROM DbEmpresas 
INNER JOIN DbVagas ON DbVagas.IdEmpresa = DbEmpresas.ID 
INNER JOIN DbInscricao ON DbInscricao.IdVaga = DbVagas.IdVaga
ORDER BY DataInscricao ASC;


--SELECIONA VAGAS E INSCRIÇÕES
SELECT DbVagas.IdVaga,NomeRecrutador,LocalVaga,TipoContrato,Cargo,QntVagas,Salario,
Descricao,StatusInscricao,DataInscricao FROM DbVagas INNER JOIN DbInscricao ON
DbInscricao.IdVaga = DbVagas.IdVaga ORDER BY DataInscricao ASC;


--SELECIONA ALUNOS E INSCRIÇÕES
SELECT NomeAluno,Sexo,Email,Telefone,Curso,StatusInscricao,DataInscricao,Cpf,NumMatricula
FROM DbAlunos INNER JOIN DbInscricao ON DbInscricao.IdAluno = DbAlunos.ID INNER JOIN DbDados ON
DbDados.ID = DbAlunos.IdDados;


--SELECIONA ALUNOS E VAGAS 
SELECT NomeRecrutador,LocalVaga,Cargo,Salario,Descricao,NomeAluno,
DataNascimento,Sexo,Email,Telefone,Turno,Curso FROM DbAlunos
INNER JOIN DbInscricao ON DbInscricao.IdAluno = DbAlunos.ID
INNER JOIN DbVagas ON DbVagas.ID = DbInscricao.IdVaga;


--SELECIONA EMPRESA, VAGA E OS ALUNOS CADASTRADOS NELA
SELECT NomeEmpresa,CNPJ,Cargo,NomeRecrutador,Salario,LocalVaga,Descricao,NomeAluno AS Aluno_Cadastrado FROM DbEmpresas 
INNER JOIN DbVagas ON DbVagas.IdEmpresa = Empresas.ID 
INNER JOIN DbInscricao ON DbInscricao.IdVaga = DbVagas.ID
INNER JOIN DbAlunos ON DbAlunos.ID = DbInscricao.IdAluno 
ORDER BY DataInscricao ASC;

--FUNÇÃO ENCONTRA ALUNO PELO NOME
CREATE FUNCTION ConsultaAluno(@ProductID VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT * FROM DbAlunos  INNER JOIN DbDados
ON DbDados.ID = DbAlunos.IdDados
	WHERE Nome LIKE '@@ProductID@');  

SELECT * FROM ConsultaAluno('Henrique');


--FUNÇÃO ENCONTRA ALUNO PELO CPF
CREATE FUNCTION ConsultaCPF(@ProductID VARCHAR(14))  
RETURNS TABLE  
AS   
RETURN(SELECT * FROM DbAlunos INNER JOIN DbDados
ON DbDados.ID = Alunos.IdDados
WHERE Cpf = @ProductID);  

SELECT * FROM ConsultaCPF('123.456.789-10');


--FUNÇÃO ENCONTRA EMPRESA PELO CNPJ
CREATE FUNCTION ConsultaCNPJ(@ProductID VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT * FROM DbEmpresas WHERE CNPJ = @ProductID);  

SELECT * FROM ConsultaCNPJ('323.323.434/0001');


--FUNÇÃO ENCONTRA INSCRIÇÕES PELO CNPJ DA EMPRESA
CREATE FUNCTION ConsultaInscricaoPelaEmpresa(@ProductID VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT NomeEmpresa,Cargo,NomeRecrutador,Salario,LocalVaga,Descricao,NomeAluno AS Aluno_Cadastrado,
Alunos.Email,Alunos.Telefone FROM DbEmpresas INNER JOIN DbVagas ON DbVagas.IdEmpresa = Empresas.ID 
INNER JOIN DbInscricao ON DbInscricao.IdVaga = Vagas.IdVaga
INNER JOIN DbAlunos ON DbAlunos.ID = DbInscricao.IdAluno WHERE CNPJ = @ProductID);  

SELECT * FROM ConsultaInscricaoPelaEmpresa('323.323.434/0001');
