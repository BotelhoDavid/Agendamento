IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Agendamento')
BEGIN
    CREATE DATABASE Agendamento;
END
GO

USE Agendamento;
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Medico' AND xtype='U')
BEGIN
    CREATE TABLE Medico (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Especialidade NVARCHAR(100) NOT NULL,
        CRM NVARCHAR(20) NOT NULL,
        DataCadastro DATETIME NOT NULL
    );
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Paciente' AND xtype='U')
BEGIN
    CREATE TABLE Paciente (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        CPF NVARCHAR(14) NOT NULL,
        DataNascimento DATE NOT NULL,
        DataCadastro DATETIME NOT NULL
    );
END

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

-- Inserir médicos se não existirem
IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '12345-SP')
BEGIN
    INSERT INTO Medico (Id, Nome, Especialidade, CRM, DataCadastro)
    VALUES (NEWID(), 'Dra. Ana Souza', 'Cardiologia', '12345-SP', GETDATE());
END

IF NOT EXISTS (SELECT 1 FROM Medico WHERE CRM = '67890-SP')
BEGIN
    INSERT INTO Medico (Id, Nome, Especialidade, CRM, DataCadastro)
    VALUES (NEWID(), 'Dr. Paulo Lima', 'Dermatologia', '67890-SP', GETDATE());
END

-- Inserir pacientes se não existirem
IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '123.456.789-00')
BEGIN
    INSERT INTO Paciente (Id, Nome, CPF, DataNascimento, DataCadastro)
    VALUES (NEWID(), 'João da Silva', '123.456.789-00', '1990-03-15', GETDATE());
END

IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CPF = '987.654.321-00')
BEGIN
    INSERT INTO Paciente (Id, Nome, CPF, DataNascimento, DataCadastro)
    VALUES (NEWID(), 'Maria Oliveira', '987.654.321-00', '1985-07-22', GETDATE());
END

-- Inserir consulta apenas se não existir para aquele paciente, médico e data/hora
DECLARE @MedicoId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Medico WHERE CRM = '12345-SP');
DECLARE @PacienteId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Paciente WHERE CPF = '123.456.789-00');

IF NOT EXISTS (
    SELECT 1 FROM Consulta
    WHERE PacienteId = @PacienteId AND MedicoId = @MedicoId
      AND Data = '2025-06-20' AND Horario = '14:30:00'
)
BEGIN
    INSERT INTO Consulta (Id, PacienteId, MedicoId, Data, Horario, Especialidade)
    VALUES (NEWID(), @PacienteId, @MedicoId, '2025-06-20', '14:30:00', 'Cardiologia');
END
