CREATE DATABASE SistemaVotacionesDB;
GO

USE SistemaVotacionesDB;
GO

CREATE TABLE Roles (
    IdRol INT PRIMARY KEY IDENTITY,
    NombreRol VARCHAR(50) NOT NULL
);

CREATE TABLE PadronesElectorales (
    IdPadron INT PRIMARY KEY IDENTITY,
    Nivel VARCHAR(50),
    Grado VARCHAR(10),
    Seccion VARCHAR(5),
    Modalidad VARCHAR(50),
    NombrePadron VARCHAR(100)
);

CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY,
    Matricula VARCHAR(20) UNIQUE,
    NombreCompleto VARCHAR(100),
    Nivel VARCHAR(50),
    Grado VARCHAR(10),
    Seccion VARCHAR(5),
    Modalidad VARCHAR(50),
    Username VARCHAR(50),
    Password VARCHAR(100),
    IdRol INT,
    IdPadron INT,
    EstadoUsuario BIT,
    YaVoto BIT,

    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol),
    FOREIGN KEY (IdPadron) REFERENCES PadronesElectorales(IdPadron)
);

INSERT INTO Roles (NombreRol)
VALUES ('Administrador'), ('Votante');

INSERT INTO PadronesElectorales (Nivel, Grado, Seccion, Modalidad, NombrePadron)
VALUES 
('Primaria', '1ro', 'A', 'Académico', 'Primaria 1ro A'),
('Secundaria', '5to', 'B', 'Informática', 'Secundaria 5to B Informática');

INSERT INTO Usuarios (
Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad,
Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES (
'0001', 'Administrador General', 'Admin', '0', 'A', 'N/A',
'admin', '1234', 1, 1, 1, 0
);