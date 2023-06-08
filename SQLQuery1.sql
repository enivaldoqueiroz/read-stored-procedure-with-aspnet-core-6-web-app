USE TESTE
GO

CREATE PROCEDURE MinhaStoredProcedure
AS
BEGIN
    SELECT Id, Nome
    FROM MinhaTabela
END
GO

USE TESTE
GO


CREATE TABLE MinhaTabela (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(50)
)


USE TESTE
GO
DROP TABLE MinhaTabela

INSERT INTO MinhaTabela (Nome)
VALUES ('Enivaldo Queiroz'),
       ('Lana Queiroz'),
       ('Mila Queiroz');

SELECT * FROM MinhaTabela


USE TESTE
GO

CREATE TABLE Alunos (
    AlunoId INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(50),
    Idade INT,
    EstaMatriculado BIT,
    Disciplina NVARCHAR(50)
)

SELECT * FROM Alunos


INSERT INTO Alunos (Nome, Idade, EstaMatriculado, Disciplina)
VALUES ('João', 20, 1, 'Matemática'),
       ('Maria', 22, 1, 'História'),
       ('Pedro', 18, 0, 'Geografia');

USE TESTE
GO

CREATE PROCEDURE GetAlunos
AS
BEGIN
    SELECT AlunoId, Nome, Idade, EstaMatriculado, Disciplina
    FROM Alunos
END
GO