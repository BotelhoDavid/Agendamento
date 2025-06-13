-- Criar banco de dados Agendamento, se não existir
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Agendamento')
BEGIN
    CREATE DATABASE Agendamento;
END
GO

USE Agendamento;
GO

-- Tabela: Usuario
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuario' AND xtype='U')
BEGIN
    CREATE TABLE Usuario (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Email NVARCHAR(255) NOT NULL UNIQUE,
        SenhaHash NVARCHAR(255) NOT NULL,
        Nome NVARCHAR(100) NOT NULL
    );
END

-- Tabela: Medico
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Medico' AND xtype='U')
BEGIN
    CREATE TABLE Medico (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Especialidade NVARCHAR(100) NOT NULL,
        CRM NVARCHAR(20) NOT NULL UNIQUE,
        DataCadastro DATETIME NOT NULL
    );
END

-- Tabela: Paciente
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Paciente' AND xtype='U')
BEGIN
    CREATE TABLE Paciente (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        CPF NVARCHAR(14) NOT NULL UNIQUE,
        DataNascimento DATE NOT NULL,
        DataCadastro DATETIME NOT NULL
    );
END

-- Tabela: Consulta
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Consulta' AND xtype='U')
BEGIN
    CREATE TABLE Consulta (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        PacienteId UNIQUEIDENTIFIER NOT NULL,
        MedicoId UNIQUEIDENTIFIER NOT NULL,
        Data DATE NOT NULL,
        Horario TIME NOT NULL,
        Especialidade NVARCHAR(100) NOT NULL,

        FOREIGN KEY (PacienteId) REFERENCES Paciente(Id),
        FOREIGN KEY (MedicoId) REFERENCES Medico(Id)
    );
END

-- Inserções
DECLARE @Now DATETIME = GETDATE();

-- Usuário administrador
IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Email = 'admin@agendamento.com')
BEGIN
    INSERT INTO Usuario (Id, Email, SenhaHash, Nome)
    VALUES (
        NEWID(),
        'admin@agendamento.com',
        '$2a$11$9tKkMomqUcc/gtJQ1wTcj.fG5wc1UWivBmznCpeFu8F5IUjG/sZdW', -- bcrypt hash de exemplo
        'Administrador'
    );
END

-- Médicos atualizados (5 especialidades, 2 médicos por especialidade)
IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '10001-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dr. André Ramos', 'Cardiologia', '10001-SP', @Now);
IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '10002-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dra. Beatriz Lemos', 'Cardiologia', '10002-SP', @Now);

IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '20001-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dr. Carlos Fonseca', 'Dermatologia', '20001-SP', @Now);
IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '20002-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dra. Daniela Freitas', 'Dermatologia', '20002-SP', @Now);

IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '30001-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dr. Eduardo Nogueira', 'Ortopedia', '30001-SP', @Now);
IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '30002-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dra. Fabiana Teixeira', 'Ortopedia', '30002-SP', @Now);

IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '40001-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dr. Gustavo Amaral', 'Neurologia', '40001-SP', @Now);
IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '40002-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dra. Helena Rocha', 'Neurologia', '40002-SP', @Now);

IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '50001-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dr. Igor Mendes', 'Pediatria', '50001-SP', @Now);
IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '50002-SP')
    INSERT INTO Medico VALUES (NEWID(), 'Dra. Juliana Cardoso', 'Pediatria', '50002-SP', @Now);

-- Pacientes
IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '123.456.789-00')
    INSERT INTO Paciente VALUES (NEWID(), 'João da Silva', '123.456.789-00', '1990-03-15', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '987.654.321-00')
    INSERT INTO Paciente VALUES (NEWID(), 'Maria Oliveira', '987.654.321-00', '1985-07-22', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '321.654.987-00')
    INSERT INTO Paciente VALUES (NEWID(), 'Carlos Henrique', '321.654.987-00', '2000-01-10', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '456.789.123-00')
    INSERT INTO Paciente VALUES (NEWID(), 'Aline Santos', '456.789.123-00', '1992-11-30', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '111.222.333-44')
    INSERT INTO Paciente VALUES (NEWID(), 'Bruno Martins', '111.222.333-44', '1978-05-09', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '555.666.777-88')
    INSERT INTO Paciente VALUES (NEWID(), 'Fernanda Souza', '555.666.777-88', '1983-09-14', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '999.000.111-22')
    INSERT INTO Paciente VALUES (NEWID(), 'Thiago Nunes', '999.000.111-22', '1995-04-23', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '888.777.666-55')
    INSERT INTO Paciente VALUES (NEWID(), 'Camila Lopes', '888.777.666-55', '2001-12-01', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '444.555.666-77')
    INSERT INTO Paciente VALUES (NEWID(), 'Rafael Dias', '444.555.666-77', '1989-06-18', @Now);

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '222.333.444-55')
    INSERT INTO Paciente VALUES (NEWID(), 'Patrícia Moura', '222.333.444-55', '1975-08-30', @Now);

-- Consultas: associando pacientes com médicos aleatoriamente (com validação IF NOT EXISTS)
-- Exemplo: 1 consulta por paciente

DECLARE @PacienteId UNIQUEIDENTIFIER, @MedicoId UNIQUEIDENTIFIER, @Especialidade NVARCHAR(100);
DECLARE @DataConsulta DATE = CAST(GETDATE() AS DATE);
DECLARE @HorarioConsulta TIME = '09:00';

-- Associar CPF a consulta
-- Exemplo: João da Silva com Dr. André Ramos (Cardiologia)
SELECT TOP 1 @PacienteId = Id FROM Paciente WHERE CPF = '123.456.789-00';
SELECT TOP 1 @MedicoId = Id, @Especialidade = Especialidade FROM Medico WHERE CRM = '10001-SP';
IF NOT EXISTS (SELECT 1 FROM Consulta WHERE PacienteId = @PacienteId AND MedicoId = @MedicoId)
    INSERT INTO Consulta VALUES (NEWID(), @PacienteId, @MedicoId, @DataConsulta, @HorarioConsulta, @Especialidade);

-- Maria Oliveira com Dra. Daniela Freitas (Dermatologia)
SELECT TOP 1 @PacienteId = Id FROM Paciente WHERE CPF = '987.654.321-00';
SELECT TOP 1 @MedicoId = Id, @Especialidade = Especialidade FROM Medico WHERE CRM = '20002-SP';
IF NOT EXISTS (SELECT 1 FROM Consulta WHERE PacienteId = @PacienteId AND MedicoId = @MedicoId)
    INSERT INTO Consulta VALUES (NEWID(), @PacienteId, @MedicoId, @DataConsulta, '10:00', @Especialidade);

-- Carlos Henrique com Dr. Eduardo Nogueira (Ortopedia)
SELECT TOP 1 @PacienteId = Id FROM Paciente WHERE CPF = '321.654.987-00';
SELECT TOP 1 @MedicoId = Id, @Especialidade = Especialidade FROM Medico WHERE CRM = '30001-SP';
IF NOT EXISTS (SELECT 1 FROM Consulta WHERE PacienteId = @PacienteId AND MedicoId = @MedicoId)
    INSERT INTO Consulta VALUES (NEWID(), @PacienteId, @MedicoId, @DataConsulta, '11:00', @Especialidade);

-- Aline Santos com Dra. Helena Rocha (Neurologia)
SELECT TOP 1 @PacienteId = Id FROM Paciente WHERE CPF = '456.789.123-00';
SELECT TOP 1 @MedicoId = Id, @Especialidade = Especialidade FROM Medico WHERE CRM = '40002-SP';
IF NOT EXISTS (SELECT 1 FROM Consulta WHERE PacienteId = @PacienteId AND MedicoId = @MedicoId)
    INSERT INTO Consulta VALUES (NEWID(), @PacienteId, @MedicoId, @DataConsulta, '14:00', @Especialidade);

-- Bruno Martins com Dra. Juliana Cardoso (Pediatria)
SELECT TOP 1 @PacienteId = Id FROM Paciente WHERE CPF = '111.222.333-44';
SELECT TOP 1 @MedicoId = Id, @Especialidade = Especialidade FROM Medico WHERE CRM = '50002-SP';
IF NOT EXISTS (SELECT 1 FROM Consulta WHERE PacienteId = @PacienteId AND MedicoId = @MedicoId)
    INSERT INTO Consulta VALUES (NEWID(), @PacienteId, @MedicoId, @DataConsulta, '15:00', @Especialidade);
