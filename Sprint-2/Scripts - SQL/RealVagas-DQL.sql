--Usar o banco de dados criado
USE RealVagas

--SELECIONA TODAS AS TABELAS.

SELECT * FROM DadosSigilosos;
SELECT * FROM TipoUsuario;
SELECT * FROM Adm;
SELECT * FROM Empresas;
SELECT * FROM Alunos;
SELECT * FROM Vagas;
SELECT * FROM Inscricao;


--SELECIONA PELO EMAIL DO ALUNO, EMPRESA OU ADMINISTRADOR
SELECT NomeAdm FROM Adm WHERE NomeAdm LIKE '@SENAI.COM@' ORDER BY DataNascimento ASC;

SELECT Email FROM Empresas WHERE Email LIKE '@SPACE.COM@' ORDER BY NomeEmpresa ASC;

SELECT Email FROM Alunos WHERE Email LIKE '@GMAIL.COM@' ORDER BY NomeAluno ASC;


--SELECIONA DADOS SIGILOSOS COM TABELA ALUNOS
SELECT * FROM Alunos INNER JOIN DadosSigilosos ON DadosSigilosos.IdDadosSigilosos = Alunos.IdDadosSigiolosos ORDER BY DataNascimento ASC;

--SELECIONA ALUNO ATRAVÉS DA ESCOLA
SELECT NomeAluno,DataNascimento,Sexo,Email,Telefone,Turno,Curso FROM Alunos
WHERE Escola LIKE '@Senai Informatica@' ORDER BY NomeAluno ASC;


--SELECIONA EMPRESA E VAGA 
SELECT NomeEmpresa,CNPJ,Telefone,NomeRecrutador,Salario,LocalVaga,Descricao  FROM Empresas 
INNER JOIN Vagas ON Vagas.IdEmpresa = Empresas.IdEmpresa 
INNER JOIN Inscricao ON Inscricao.IdVaga = Vagas.IdVaga
ORDER BY DataInscricao ASC;


--SELECIONA VAGAS E INSCRIÇÕES
SELECT Vagas.IdVaga,NomeRecrutador,LocalVaga,TipoContrato,Cargo,QntVagas,Salario,
Descricao,StatusInscricao,DataInscricao FROM Vagas INNER JOIN Inscricao ON
Inscricao.IdVaga = Vagas.IdVaga ORDER BY DataInscricao ASC;


--SELECIONA ALUNOS E INSCRIÇÕES
SELECT NomeAluno,Sexo,Email,Telefone,Curso,StatusInscricao,DataInscricao,Cpf,NumMatricula
FROM Alunos INNER JOIN Inscricao ON Inscricao.IdAluno = Alunos.IdAluno INNER JOIN DadosSigilosos ON
DadosSigilosos.IdDadosSigilosos = Alunos.IdDadosSigiolosos;


--SELECIONA ALUNOS E VAGAS 
SELECT NomeRecrutador,LocalVaga,Cargo,Salario,Descricao,NomeAluno,
DataNascimento,Sexo,Email,Telefone,Turno,Curso FROM Alunos
INNER JOIN Inscricao ON Inscricao.IdAluno = Alunos.IdAluno
INNER JOIN Vagas ON Vagas.IdVaga = Inscricao.IdVaga;


--SELECIONA EMPRESA, VAGA E OS ALUNOS CADASTRADOS NELA
SELECT NomeEmpresa,CNPJ,Cargo,NomeRecrutador,Salario,LocalVaga,Descricao,NomeAluno AS Aluno_Cadastrado FROM Empresas 
INNER JOIN Vagas ON Vagas.IdEmpresa = Empresas.IdEmpresa 
INNER JOIN Inscricao ON Inscricao.IdVaga = Vagas.IdVaga
INNER JOIN Alunos ON Alunos.IdAluno = Inscricao.IdAluno 
ORDER BY DataInscricao ASC;

--FUNÇÃO ENCONTRA ALUNO PELO NOME
CREATE FUNCTION ConsultaAluno(@ProductID VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT * FROM Alunos  INNER JOIN DadosSigilosos
ON DadosSigilosos.IdDadosSigilosos = Alunos.IdDadosSigiolosos
	WHERE NomeAluno LIKE '@@ProductID@');  

SELECT * FROM ConsultaAluno('Henrique');


--FUNÇÃO ENCONTRA ALUNO PELO CPF
CREATE FUNCTION ConsultaCPF(@ProductID VARCHAR(14))  
RETURNS TABLE  
AS   
RETURN(SELECT * FROM Alunos INNER JOIN DadosSigilosos
ON DadosSigilosos.IdDadosSigilosos = Alunos.IdDadosSigiolosos
WHERE Cpf = @ProductID);  

SELECT * FROM ConsultaCPF('123.456.789-10');


--FUNÇÃO ENCONTRA EMPRESA PELO CNPJ
CREATE FUNCTION ConsultaCNPJ(@ProductID VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT * FROM Empresas WHERE CNPJ = @ProductID);  

SELECT * FROM ConsultaCNPJ('323.323.434/0001');


--FUNÇÃO ENCONTRA INSCRIÇÕES PELO CNPJ DA EMPRESA
CREATE FUNCTION ConsultaInscricaoPelaEmpresa(@ProductID VARCHAR(255))  
RETURNS TABLE  
AS   
RETURN(SELECT NomeEmpresa,Cargo,NomeRecrutador,Salario,LocalVaga,Descricao,NomeAluno AS Aluno_Cadastrado,
Alunos.Email,Alunos.Telefone FROM Empresas INNER JOIN Vagas ON Vagas.IdEmpresa = Empresas.IdEmpresa 
INNER JOIN Inscricao ON Inscricao.IdVaga = Vagas.IdVaga
INNER JOIN Alunos ON Alunos.IdAluno = Inscricao.IdAluno WHERE CNPJ = @ProductID);  

SELECT * FROM ConsultaInscricaoPelaEmpresa('323.323.434/0001');
