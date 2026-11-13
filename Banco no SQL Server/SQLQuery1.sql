CREATE DATABASE dbCursosUniversitarios;
GO


USE dbCursosUniversitarios;
GO

-- 1. TABELA ALUNO

CREATE TABLE Aluno (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeCompleto VARCHAR(150) NOT NULL,
    CPF VARCHAR(11) NOT NULL UNIQUE,
    Email VARCHAR(150) NOT NULL,
    Telefone VARCHAR(20)
);
GO

-- 2. TABELA CURSO


CREATE TABLE Curso (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeCurso VARCHAR(150) NOT NULL,
    Turno VARCHAR(30) NOT NULL,
    CargaHoraria INT NOT NULL,
    VagasDisponiveis INT NOT NULL,

    CONSTRAINT CK_Curso_CargaHoraria
        CHECK (CargaHoraria > 0),

    CONSTRAINT CK_Curso_Vagas
        CHECK (VagasDisponiveis >= 0)
);
GO

-- 3. TABELA USUARIO

CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Login VARCHAR(100) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL,
    Perfil VARCHAR(50) NOT NULL
);
GO

-- 4. TABELA ESCOLHACURSO

CREATE TABLE EscolhaCurso (
    Id INT IDENTITY(1,1) PRIMARY KEY,

    AlunoId INT NOT NULL,
    CursoId INT NOT NULL,

    OrdemPreferencia INT NOT NULL,
    DataEscolha DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_EscolhaCurso_Aluno
        FOREIGN KEY (AlunoId)
        REFERENCES Aluno(Id),

    CONSTRAINT FK_EscolhaCurso_Curso
        FOREIGN KEY (CursoId)
        REFERENCES Curso(Id),

    CONSTRAINT CK_EscolhaCurso_Ordem
        CHECK (OrdemPreferencia BETWEEN 1 AND 3),

    CONSTRAINT UQ_EscolhaCurso_Aluno_Ordem
        UNIQUE (AlunoId, OrdemPreferencia),

    CONSTRAINT UQ_EscolhaCurso_Aluno_Curso
        UNIQUE (AlunoId, CursoId)
);
GO


INSERT INTO Usuario (Nome, Login, Senha, Perfil)
VALUES
('Administrador', 'admin', 'admin123', 'Administrador'),
('Operador', 'operador', 'operador123', 'Operador');
GO


INSERT INTO Curso
(NomeCurso, Turno, CargaHoraria, VagasDisponiveis)
VALUES
('Ciência da Computação', 'Noturno', 3200, 40),
('Engenharia de Software', 'Matutino', 3200, 35),
('Direito', 'Noturno', 3700, 50),
('Administração', 'Matutino', 3000, 45),
('Enfermagem', 'Integral', 4000, 30);
GO


INSERT INTO Aluno
(NomeCompleto, CPF, Email, Telefone)
VALUES
('João da Silva', '12345678901',
 'joao@email.com', '79999990001'),

('Maria Oliveira', '98765432100',
 'maria@email.com', '79999990002');
GO


INSERT INTO EscolhaCurso
(AlunoId, CursoId, OrdemPreferencia)
VALUES
(1, 1, 1),
(1, 2, 2),
(1, 3, 3),
(2, 4, 1),
(2, 5, 2);
GO

SELECT * FROM Aluno;
SELECT * FROM Curso;
SELECT * FROM Usuario;
SELECT * FROM EscolhaCurso;