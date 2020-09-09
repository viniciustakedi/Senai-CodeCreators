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
SELECT * FROM DbEmpresas WHERE Email LIKE '@SPACE.COM@' ORDER BY Nome ASC;

SELECT * FROM DbUsuarios WHERE Email LIKE '@GMAIL.COM@' ORDER BY Nome ASC;


--SELECIONA DADOS SIGILOSOS COM TABELA ALUNOS
SELECT * FROM DbUsuarios INNER JOIN DbDados ON DbDados.ID = DbUsuarios.IdDados ORDER BY DataNascimento ASC;

--SELECIONA ALUNO ATRAVÉS DA ESCOLA
SELECT Nome,DataNascimento,Sexo,Email,Telefone,Turno,Curso FROM DbUsuarios
WHERE Escola LIKE '@Senai Informatica@' ORDER BY Nome ASC;


--SELECIONA EMPRESA E VAGA 
SELECT Nome,CNPJ,Telefone,NomeRecrutador,Salario,LocalVaga,Descricao  FROM DbEmpresas 
INNER JOIN DbVagas ON DbVagas.IdEmpresa = DbEmpresas.ID 
INNER JOIN DbInscricao ON DbInscricao.IdVaga = DbVagas.ID
ORDER BY DataInscricao ASC;


--SELECIONA VAGAS E INSCRIÇÕES
SELECT DbVagas.ID,NomeRecrutador,LocalVaga,TipoContrato,Cargo,QntVagas,Salario,
Descricao,StatusInscricao,DataInscricao FROM DbVagas INNER JOIN DbInscricao ON
DbInscricao.IdVaga = DbVagas.ID ORDER BY DataInscricao ASC;


--SELECIONA ALUNOS E INSCRIÇÕES
SELECT nome,Sexo,Email,Telefone,Curso,StatusInscricao,DataInscricao,Cpf,NumMatricula
FROM DbUsuarios INNER JOIN DbInscricao ON DbInscricao.IdUsuario = DbUsuarios.ID INNER JOIN DbDados ON
DbDados.ID = DbUsuarios.ID;


--SELECIONA ALUNOS E VAGAS 
SELECT NomeRecrutador,LocalVaga,Cargo,Salario,Descricao,nome,
DataNascimento,Sexo,Email,Telefone,Turno,Curso FROM DbUsuarios
INNER JOIN DbInscricao ON DbInscricao.IdUsuario = DbUsuarios.ID
INNER JOIN DbVagas ON DbVagas.ID = DbInscricao.IdVaga;


--SELECIONA EMPRESA, VAGA E OS ALUNOS CADASTRADOS NELA
SELECT DbEmpresas.Nome,CNPJ,Cargo,NomeRecrutador,Salario,LocalVaga,Descricao, DbUsuarios.Nome AS Aluno_Cadastrado FROM DbEmpresas 
INNER JOIN DbVagas ON DbVagas.IdEmpresa = DbEmpresas.ID 
INNER JOIN DbInscricao ON DbInscricao.IdVaga = DbVagas.ID
INNER JOIN DbUsuarios ON DbUsuarios.ID = DbInscricao.IdUsuario 
ORDER BY DataInscricao ASC;

--FUNÇÃO ENCONTRA ALUNO PELO NOME
CREATE FUNCTION ConsultaAluno(@Product VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT DbUsuarios.ID, Nome,DataNascimento,Sexo,Escola,Email,Telefone,EstadoCivil,
Nivel,TipoCurso,Curso,Turma,Turno,Termo,IdTipoUsuario,DbUsuarios.IdDados,NumMatricula,Cpf FROM DbUsuarios 
INNER JOIN DbDados ON DbDados.ID = DbUsuarios.IdDados where Nome like @Product);  

SELECT * FROM ConsultaAluno('Henrique');

  
 --FUNÇÃO ENCONTRA ALUNO PELO CPF
CREATE FUNCTION ConsultaCPF (@ProductID VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT DbUsuarios.ID, Nome,DataNascimento,Sexo,Escola,Email,Telefone,EstadoCivil,
Nivel,TipoCurso,Curso,Turma,Turno,Termo,IdTipoUsuario,DbUsuarios.IdDados,NumMatricula,Cpf FROM DbUsuarios 
INNER JOIN DbDados ON DbDados.ID = DbUsuarios.IdDados where Cpf like @ProductID);  

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
RETURN(SELECT DbEmpresas.Nome,Cargo,NomeRecrutador,Salario,LocalVaga,Descricao,DbUsuarios.Nome AS Aluno_Cadastrado,
DbUsuarios.Email,DbUsuarios.Telefone FROM DbEmpresas INNER JOIN DbVagas ON DbVagas.IdEmpresa = DbEmpresas.ID 
INNER JOIN DbInscricao ON DbInscricao.IdVaga = DbVagas.ID
INNER JOIN DbUsuarios ON DbUsuarios.ID = DbInscricao.IdUsuario WHERE CNPJ = @ProductID);  

SELECT * FROM ConsultaInscricaoPelaEmpresa('323.323.434/0001');
