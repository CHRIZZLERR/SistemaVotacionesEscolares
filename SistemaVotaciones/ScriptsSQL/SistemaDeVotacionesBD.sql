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

    USE SistemaVotacionesDB;
GO

SELECT * FROM Usuarios;


USE SistemaVotacionesDB;
GO

-- 1. Votaciones
CREATE TABLE Votaciones (
    IdVotacion INT PRIMARY KEY IDENTITY,
    NombreVotacion VARCHAR(100) NOT NULL,
    IdPadron INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    EstadoVotacion VARCHAR(20) NOT NULL,

    FOREIGN KEY (IdPadron) REFERENCES PadronesElectorales(IdPadron)
);
GO

-- 2. Planchas
CREATE TABLE Planchas (
    IdPlancha INT PRIMARY KEY IDENTITY,
    NombrePlancha VARCHAR(100) NOT NULL,
    Color VARCHAR(50),
    Lema VARCHAR(200),
    IdPadron INT NOT NULL,
    EstadoPlancha BIT NOT NULL,

    FOREIGN KEY (IdPadron) REFERENCES PadronesElectorales(IdPadron)
);
GO

-- 3. Cargos oficiales
CREATE TABLE Cargos (
    IdCargo INT PRIMARY KEY IDENTITY,
    NombreCargo VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(150),
    Orden INT NOT NULL
);
GO

-- 4. Integrantes de plancha
CREATE TABLE IntegrantesPlancha (
    IdIntegrante INT PRIMARY KEY IDENTITY,
    IdPlancha INT NOT NULL,
    IdUsuario INT NOT NULL,
    IdCargo INT NOT NULL,

    FOREIGN KEY (IdPlancha) REFERENCES Planchas(IdPlancha),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdCargo) REFERENCES Cargos(IdCargo)
);
GO

-- 5. Votos
CREATE TABLE Votos (
    IdVoto INT PRIMARY KEY IDENTITY,
    IdUsuario INT NOT NULL,
    IdVotacion INT NOT NULL,
    IdPlancha INT NULL,
    EsNulo BIT NOT NULL,
    FechaVoto DATETIME NOT NULL,

    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdVotacion) REFERENCES Votaciones(IdVotacion),
    FOREIGN KEY (IdPlancha) REFERENCES Planchas(IdPlancha)
);
GO

-- 6. Insertar cargos oficiales
INSERT INTO Cargos (NombreCargo, Descripcion, Orden)
VALUES
('Presidente', 'Presidente de la plancha', 1),
('Vicepresidente', 'Vicepresidente de la plancha', 2),
('Secretario', 'Secretario de la plancha', 3),
('Tesorero', 'Tesorero de la plancha', 4),
('Vocal 1', 'Coordinador de estudios', 5),
('Vocal 2', 'Coordinador de orden y disciplina', 6),
('Vocal 3', 'Coordinador de ornato y limpieza', 7),
('Vocal 4', 'Coordinador de apoyo a la tecnología', 8),
('Vocal 5', 'Coordinador de festejo', 9);
GO

-- 7. Verificar tablas
    SELECT TABLE_NAME
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_TYPE = 'BASE TABLE';
    GO

-- 8. Verificar cargos
SELECT * FROM Cargos;
GO


select  * from Votaciones;


ALTER TABLE Planchas
ADD IdAdminPlancha INT NULL;
GO

ALTER TABLE Planchas
ADD CONSTRAINT FK_Planchas_Admin
FOREIGN KEY (IdAdminPlancha) REFERENCES Usuarios(IdUsuario);
GO


INSERT INTO Roles (NombreRol)
VALUES ('AdministradorPlancha');



SELECT IdUsuario, NombreCompleto, Username, IdRol
FROM Usuarios
WHERE IdRol = 3;



INSERT INTO Usuarios (
    Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad,
    Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto
)
VALUES
('2001', 'Admin Plancha 1', 'Secundaria', '5to', 'B', 'Informática',
 'adminp1', '1234', 3, 2, 1, 0),

('2002', 'Admin Plancha 2', 'Secundaria', '5to', 'B', 'Informática',
 'adminp2', '1234', 3, 2, 1, 0);



 USE SistemaVotacionesDB;
GO

SELECT * FROM Votaciones;




USE SistemaVotacionesDB;
GO

SELECT IdUsuario, NombreCompleto, Username, IdPadron, YaVoto
FROM Usuarios
WHERE Username = 'TU_USUARIO_VOTANTE';

SELECT IdVotacion, NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion
FROM Votaciones;

SELECT IdPlancha, NombrePlancha, IdPadron, EstadoPlancha
FROM Planchas;



UPDATE Votaciones
SET EstadoVotacion = 'Abierta',
    FechaInicio = DATEADD(MINUTE, -10, GETDATE()),
    FechaFin = DATEADD(HOUR, 2, GETDATE())
WHERE IdPadron = 2;


SELECT * FROM Planchas WHERE IdPadron = 2;



INSERT INTO Planchas
(NombrePlancha, Color, Lema, IdPadron, EstadoPlancha, IdAdminPlancha)
VALUES
('Plancha Azul', 'Azul', 'Unidos por el cambio', 2, 1, NULL);





USE SistemaVotacionesDB;
GO

-- 1. Ver usuarios votantes
SELECT 
    IdUsuario,
    NombreCompleto,
    Username,
    IdRol,
    IdPadron,
    YaVoto
FROM Usuarios
ORDER BY IdUsuario;

-- 2. Ver votaciones
SELECT 
    IdVotacion,
    NombreVotacion,
    IdPadron,
    FechaInicio,
    FechaFin,
    EstadoVotacion,
    GETDATE() AS FechaActualSQL
FROM Votaciones;

-- 3. Ver planchas
SELECT 
    IdPlancha,
    NombrePlancha,
    IdPadron,
    EstadoPlancha
FROM Planchas;

-- 4. Ver padrones
SELECT *
FROM PadronesElectorales;




INSERT INTO Votaciones
(NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion)
VALUES
('Elecciones Primaria 1ro A', 1, DATEADD(MINUTE, -30, GETDATE()), DATEADD(HOUR, 5, GETDATE()), 'Abierta');

INSERT INTO Planchas
(NombrePlancha, Color, Lema, IdPadron, EstadoPlancha, IdAdminPlancha)
VALUES
('Plancha Primaria Azul', 'Azul', 'Unidos por el cambio', 1, 1, NULL);





SELECT IdUsuario, Username, YaVoto
FROM Usuarios
WHERE Username = 'Jael01';