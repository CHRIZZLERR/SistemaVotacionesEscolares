/* =============================================================
   SISTEMA DE VOTACIONES ESCOLARES - SCRIPT FINAL COMPLETO
   Base de datos: SistemaVotacionesDB
   Uso: ejecutar completo en SQL Server Management Studio.

   IMPORTANTE:
   - Este script BORRA y CREA de nuevo la base de datos.
   - Úsalo en la otra computadora para dejar la BD lista.
   - Si ya tienes datos importantes en SistemaVotacionesDB, NO lo ejecutes
     sin hacer backup primero.
   ============================================================= */

USE master;
GO

IF DB_ID('SistemaVotacionesDB') IS NOT NULL
BEGIN
    ALTER DATABASE SistemaVotacionesDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SistemaVotacionesDB;
END;
GO

CREATE DATABASE SistemaVotacionesDB;
GO

USE SistemaVotacionesDB;
GO

/* =============================================================
   1. TABLAS PRINCIPALES
   ============================================================= */

CREATE TABLE Roles (
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE PadronesElectorales (
    IdPadron INT IDENTITY(1,1) PRIMARY KEY,
    Nivel VARCHAR(50) NOT NULL,
    Grado VARCHAR(10) NOT NULL,
    Seccion VARCHAR(5) NOT NULL,
    Modalidad VARCHAR(50) NOT NULL,
    NombrePadron VARCHAR(150) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Matricula VARCHAR(20) NOT NULL UNIQUE,
    NombreCompleto VARCHAR(120) NOT NULL,
    Nivel VARCHAR(50) NOT NULL,
    Grado VARCHAR(10) NOT NULL,
    Seccion VARCHAR(5) NOT NULL,
    Modalidad VARCHAR(50) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    [Password] VARCHAR(100) NOT NULL,
    IdRol INT NOT NULL,
    IdPadron INT NOT NULL,
    EstadoUsuario BIT NOT NULL DEFAULT 1,
    YaVoto BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (IdRol) REFERENCES Roles(IdRol),
    CONSTRAINT FK_Usuarios_Padrones FOREIGN KEY (IdPadron) REFERENCES PadronesElectorales(IdPadron)
);
GO

CREATE TABLE Votaciones (
    IdVotacion INT IDENTITY(1,1) PRIMARY KEY,
    NombreVotacion VARCHAR(150) NOT NULL,
    IdPadron INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    EstadoVotacion VARCHAR(20) NOT NULL,
    CONSTRAINT FK_Votaciones_Padrones FOREIGN KEY (IdPadron) REFERENCES PadronesElectorales(IdPadron),
    CONSTRAINT CK_Votaciones_Estado CHECK (EstadoVotacion IN ('Pendiente', 'Abierta', 'Cerrada'))
);
GO

CREATE TABLE Planchas (
    IdPlancha INT IDENTITY(1,1) PRIMARY KEY,
    NombrePlancha VARCHAR(120) NOT NULL,
    Color VARCHAR(50) NULL,
    Lema VARCHAR(250) NULL,
    IdPadron INT NOT NULL,
    EstadoPlancha BIT NOT NULL DEFAULT 1,
    IdAdminPlancha INT NULL,
    ImagenPath NVARCHAR(300) NULL,
    CONSTRAINT FK_Planchas_Padrones FOREIGN KEY (IdPadron) REFERENCES PadronesElectorales(IdPadron),
    CONSTRAINT FK_Planchas_Admin FOREIGN KEY (IdAdminPlancha) REFERENCES Usuarios(IdUsuario)
);
GO

CREATE TABLE Cargos (
    IdCargo INT IDENTITY(1,1) PRIMARY KEY,
    NombreCargo VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(150) NULL,
    Orden INT NOT NULL
);
GO

CREATE TABLE IntegrantesPlancha (
    IdIntegrante INT IDENTITY(1,1) PRIMARY KEY,
    IdPlancha INT NOT NULL,
    IdUsuario INT NOT NULL,
    IdCargo INT NOT NULL,
    CONSTRAINT FK_Integrantes_Plancha FOREIGN KEY (IdPlancha) REFERENCES Planchas(IdPlancha),
    CONSTRAINT FK_Integrantes_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    CONSTRAINT FK_Integrantes_Cargo FOREIGN KEY (IdCargo) REFERENCES Cargos(IdCargo),
    CONSTRAINT UQ_Integrante_Unico UNIQUE (IdPlancha, IdUsuario),
    CONSTRAINT UQ_Cargo_Plancha UNIQUE (IdPlancha, IdCargo)
);
GO

CREATE TABLE Votos (
    IdVoto INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdVotacion INT NOT NULL,
    IdPlancha INT NULL,
    EsNulo BIT NOT NULL,
    FechaVoto DATETIME NOT NULL,
    CONSTRAINT FK_Votos_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    CONSTRAINT FK_Votos_Votacion FOREIGN KEY (IdVotacion) REFERENCES Votaciones(IdVotacion),
    CONSTRAINT FK_Votos_Plancha FOREIGN KEY (IdPlancha) REFERENCES Planchas(IdPlancha),
    CONSTRAINT UQ_Voto_Unico UNIQUE (IdUsuario, IdVotacion)
);
GO

/* =============================================================
   2. ROLES
   OJO: el código C# espera estos IdRol:
   1 = Administrador
   2 = Votante
   3 = AdministradorPlancha
   4 = Candidato
   ============================================================= */

INSERT INTO Roles (NombreRol)
VALUES
('Administrador'),
('Votante'),
('AdministradorPlancha'),
('Candidato');
GO

/* =============================================================
   3. PADRONES ELECTORALES COMPLETOS
   - Primaria: 1ro a 6to, A/B/C, Académico
   - Secundaria académica: 1ro a 6to, A/B/C, Académico
   - Secundaria técnica: 4to a 6to, A/B/C, Informática/Gestión/Electrónica/Música
   ============================================================= */

DECLARE @GradosPrimaria TABLE (Grado VARCHAR(10));
DECLARE @GradosSecundaria TABLE (Grado VARCHAR(10));
DECLARE @GradosTecnicos TABLE (Grado VARCHAR(10));
DECLARE @Secciones TABLE (Seccion VARCHAR(5));
DECLARE @ModalidadesTecnicas TABLE (Modalidad VARCHAR(50));

INSERT INTO @GradosPrimaria VALUES ('1ro'), ('2do'), ('3ro'), ('4to'), ('5to'), ('6to');
INSERT INTO @GradosSecundaria VALUES ('1ro'), ('2do'), ('3ro'), ('4to'), ('5to'), ('6to');
INSERT INTO @GradosTecnicos VALUES ('4to'), ('5to'), ('6to');
INSERT INTO @Secciones VALUES ('A'), ('B'), ('C');
INSERT INTO @ModalidadesTecnicas VALUES ('Informática'), ('Gestión'), ('Electrónica'), ('Música');

INSERT INTO PadronesElectorales (Nivel, Grado, Seccion, Modalidad, NombrePadron)
SELECT
    'Primaria',
    GP.Grado,
    S.Seccion,
    'Académico',
    'Primaria ' + GP.Grado + ' ' + S.Seccion + ' Académico'
FROM @GradosPrimaria GP
CROSS JOIN @Secciones S;

INSERT INTO PadronesElectorales (Nivel, Grado, Seccion, Modalidad, NombrePadron)
SELECT
    'Secundaria',
    GS.Grado,
    S.Seccion,
    'Académico',
    'Secundaria ' + GS.Grado + ' ' + S.Seccion + ' Académico'
FROM @GradosSecundaria GS
CROSS JOIN @Secciones S;

INSERT INTO PadronesElectorales (Nivel, Grado, Seccion, Modalidad, NombrePadron)
SELECT
    'Secundaria',
    GT.Grado,
    S.Seccion,
    MT.Modalidad,
    'Secundaria ' + GT.Grado + ' ' + S.Seccion + ' ' + MT.Modalidad
FROM @GradosTecnicos GT
CROSS JOIN @Secciones S
CROSS JOIN @ModalidadesTecnicas MT;
GO

/* =============================================================
   4. CARGOS OFICIALES
   ============================================================= */

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

/* =============================================================
   5. VARIABLES BASE
   ============================================================= */

DECLARE @IdRolAdmin INT = (SELECT IdRol FROM Roles WHERE NombreRol = 'Administrador');
DECLARE @IdRolVotante INT = (SELECT IdRol FROM Roles WHERE NombreRol = 'Votante');
DECLARE @IdRolAdminPlancha INT = (SELECT IdRol FROM Roles WHERE NombreRol = 'AdministradorPlancha');
DECLARE @IdRolCandidato INT = (SELECT IdRol FROM Roles WHERE NombreRol = 'Candidato');

DECLARE @Padron5BInfo INT = (SELECT IdPadron FROM PadronesElectorales WHERE NombrePadron = 'Secundaria 5to B Informática');
DECLARE @Padron5AInfo INT = (SELECT IdPadron FROM PadronesElectorales WHERE NombrePadron = 'Secundaria 5to A Informática');
DECLARE @PadronPrimaria6A INT = (SELECT IdPadron FROM PadronesElectorales WHERE NombrePadron = 'Primaria 6to A Académico');

/* =============================================================
   6. USUARIOS ADMINISTRADORES
   ============================================================= */

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, [Password], IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('ADM001', 'Administrador General', 'Secundaria', '5to', 'B', 'Informática', 'admin', '1234', @IdRolAdmin, @Padron5BInfo, 1, 0),
('AP001', 'Administrador Plancha Azul', 'Secundaria', '5to', 'B', 'Informática', 'adminazul', '1234', @IdRolAdminPlancha, @Padron5BInfo, 1, 0),
('AP002', 'Administrador Plancha Roja', 'Secundaria', '5to', 'B', 'Informática', 'adminroja', '1234', @IdRolAdminPlancha, @Padron5BInfo, 1, 0),
('AP003', 'Administrador Plancha Verde', 'Primaria', '6to', 'A', 'Académico', 'adminverde', '1234', @IdRolAdminPlancha, @PadronPrimaria6A, 1, 0),
('AP004', 'Administrador Plancha Amarilla', 'Primaria', '6to', 'A', 'Académico', 'adminamarilla', '1234', @IdRolAdminPlancha, @PadronPrimaria6A, 1, 0);

/* =============================================================
   7. CANDIDATOS SECUNDARIA 5TO B - PLANCHA AZUL
   ============================================================= */

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, [Password], IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('AZ001', 'Carlos Méndez', 'Secundaria', '5to', 'B', 'Informática', 'azul1', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ002', 'Laura Pérez', 'Secundaria', '5to', 'B', 'Informática', 'azul2', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ003', 'Andrés Ramírez', 'Secundaria', '5to', 'B', 'Informática', 'azul3', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ004', 'María Gómez', 'Secundaria', '5to', 'B', 'Informática', 'azul4', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ005', 'Diego Castillo', 'Secundaria', '5to', 'B', 'Informática', 'azul5', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ006', 'Ana Rodríguez', 'Secundaria', '5to', 'B', 'Informática', 'azul6', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ007', 'Luis Fernández', 'Secundaria', '5to', 'B', 'Informática', 'azul7', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ008', 'Camila Núñez', 'Secundaria', '5to', 'B', 'Informática', 'azul8', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('AZ009', 'Javier Santos', 'Secundaria', '5to', 'B', 'Informática', 'azul9', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0);

/* =============================================================
   8. CANDIDATOS SECUNDARIA 5TO B - PLANCHA ROJA
   ============================================================= */

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, [Password], IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('RJ001', 'Daniel Herrera', 'Secundaria', '5to', 'B', 'Informática', 'roja1', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ002', 'Sofía Martínez', 'Secundaria', '5to', 'B', 'Informática', 'roja2', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ003', 'Miguel Torres', 'Secundaria', '5to', 'B', 'Informática', 'roja3', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ004', 'Valeria Jiménez', 'Secundaria', '5to', 'B', 'Informática', 'roja4', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ005', 'Pedro Morales', 'Secundaria', '5to', 'B', 'Informática', 'roja5', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ006', 'Gabriela Peña', 'Secundaria', '5to', 'B', 'Informática', 'roja6', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ007', 'Samuel Vargas', 'Secundaria', '5to', 'B', 'Informática', 'roja7', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ008', 'Isabella Díaz', 'Secundaria', '5to', 'B', 'Informática', 'roja8', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0),
('RJ009', 'Emmanuel Cruz', 'Secundaria', '5to', 'B', 'Informática', 'roja9', '1234', @IdRolCandidato, @Padron5BInfo, 1, 0);

/* =============================================================
   9. CANDIDATOS PRIMARIA 6TO A - VERDE Y AMARILLA
   ============================================================= */

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, [Password], IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('PV001', 'Mateo García', 'Primaria', '6to', 'A', 'Académico', 'Mateo01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV002', 'Luciana Pérez', 'Primaria', '6to', 'A', 'Académico', 'Luciana01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV003', 'Sebastián Núñez', 'Primaria', '6to', 'A', 'Académico', 'Sebastian01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV004', 'Emma Rosario', 'Primaria', '6to', 'A', 'Académico', 'Emma01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV005', 'Lucas Ramírez', 'Primaria', '6to', 'A', 'Académico', 'Lucas01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV006', 'Valentina Cruz', 'Primaria', '6to', 'A', 'Académico', 'Valentina01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV007', 'Santiago Díaz', 'Primaria', '6to', 'A', 'Académico', 'Santiago01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV008', 'Camila Torres', 'Primaria', '6to', 'A', 'Académico', 'CamilaP01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PV009', 'Diego Morales', 'Primaria', '6to', 'A', 'Académico', 'DiegoP01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA001', 'Isabella Herrera', 'Primaria', '6to', 'A', 'Académico', 'Isabella01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA002', 'Adrián Jiménez', 'Primaria', '6to', 'A', 'Académico', 'Adrian01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA003', 'Renata Vargas', 'Primaria', '6to', 'A', 'Académico', 'Renata01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA004', 'Nicolás Santos', 'Primaria', '6to', 'A', 'Académico', 'Nicolas01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA005', 'Paula Méndez', 'Primaria', '6to', 'A', 'Académico', 'Paula01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA006', 'Alejandro Peña', 'Primaria', '6to', 'A', 'Académico', 'Alejandro01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA007', 'Daniela Castillo', 'Primaria', '6to', 'A', 'Académico', 'DanielaP01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA008', 'Gabriel Rojas', 'Primaria', '6to', 'A', 'Académico', 'Gabriel01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0),
('PA009', 'Victoria Almonte', 'Primaria', '6to', 'A', 'Académico', 'Victoria01', '1234', @IdRolCandidato, @PadronPrimaria6A, 1, 0);

/* =============================================================
   10. VOTANTES NORMALES
   ============================================================= */

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, [Password], IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('VT001', 'Juan López', 'Secundaria', '5to', 'B', 'Informática', 'votante1', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT002', 'Paola Reyes', 'Secundaria', '5to', 'B', 'Informática', 'votante2', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT003', 'Ricardo Medina', 'Secundaria', '5to', 'B', 'Informática', 'votante3', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT004', 'Natalia Batista', 'Secundaria', '5to', 'B', 'Informática', 'votante4', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT005', 'José Almonte', 'Secundaria', '5to', 'B', 'Informática', 'votante5', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT006', 'Marcos Santana', 'Secundaria', '5to', 'B', 'Informática', 'Marcos01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT007', 'Elena Vásquez', 'Secundaria', '5to', 'B', 'Informática', 'Elena01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT008', 'Roberto Peña', 'Secundaria', '5to', 'B', 'Informática', 'Roberto01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT009', 'Daniela Guzmán', 'Secundaria', '5to', 'B', 'Informática', 'Daniela01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT010', 'Fernando Rivas', 'Secundaria', '5to', 'B', 'Informática', 'Fernando01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT011', 'Lucía Cabrera', 'Secundaria', '5to', 'B', 'Informática', 'Lucia01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT012', 'Héctor Núñez', 'Secundaria', '5to', 'B', 'Informática', 'Hector01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT013', 'Carolina Mejía', 'Secundaria', '5to', 'B', 'Informática', 'Carolina01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT014', 'Ángel Castillo', 'Secundaria', '5to', 'B', 'Informática', 'Angel01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('VT015', 'Gabriela Rosario', 'Secundaria', '5to', 'B', 'Informática', 'Gabriela01', '1234', @IdRolVotante, @Padron5BInfo, 1, 0),
('PRU001', 'Estudiante Primaria Prueba', 'Primaria', '6to', 'A', 'Académico', 'Primaria01', '1234', @IdRolVotante, @PadronPrimaria6A, 1, 0),
('PRU002', 'Estudiante Primaria Dos', 'Primaria', '6to', 'A', 'Académico', 'Primaria02', '1234', @IdRolVotante, @PadronPrimaria6A, 1, 0),
('PRU003', 'Estudiante Primaria Tres', 'Primaria', '6to', 'A', 'Académico', 'Primaria03', '1234', @IdRolVotante, @PadronPrimaria6A, 1, 0),
('TEC001', 'Estudiante Técnica Prueba', 'Secundaria', '5to', 'A', 'Informática', 'Tecnico01', '1234', @IdRolVotante, @Padron5AInfo, 1, 0);

/* =============================================================
   11. PLANCHAS
   ============================================================= */

DECLARE @IdAdminAzul INT = (SELECT IdUsuario FROM Usuarios WHERE Username = 'adminazul');
DECLARE @IdAdminRoja INT = (SELECT IdUsuario FROM Usuarios WHERE Username = 'adminroja');
DECLARE @IdAdminVerde INT = (SELECT IdUsuario FROM Usuarios WHERE Username = 'adminverde');
DECLARE @IdAdminAmarilla INT = (SELECT IdUsuario FROM Usuarios WHERE Username = 'adminamarilla');

INSERT INTO Planchas
(NombrePlancha, Color, Lema, IdPadron, EstadoPlancha, IdAdminPlancha, ImagenPath)
VALUES
('Plancha Azul', 'Azul', 'Unidos por el cambio estudiantil', @Padron5BInfo, 1, @IdAdminAzul, NULL),
('Plancha Roja', 'Rojo', 'Liderazgo, compromiso y participación', @Padron5BInfo, 1, @IdAdminRoja, NULL),
('Plancha Verde Primaria', 'Verde', 'Unidos por una primaria mejor', @PadronPrimaria6A, 1, @IdAdminVerde, NULL),
('Plancha Amarilla Primaria', 'Amarillo', 'Participación y compromiso escolar', @PadronPrimaria6A, 1, @IdAdminAmarilla, NULL);

/* =============================================================
   12. VOTACIONES ABIERTAS
   ============================================================= */

INSERT INTO Votaciones
(NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion)
VALUES
('Elecciones Estudiantiles 2026 - 5to B Informática', @Padron5BInfo, DATEADD(MINUTE, -30, GETDATE()), DATEADD(HOUR, 5, GETDATE()), 'Abierta'),
('Elecciones Primaria 6to A 2026', @PadronPrimaria6A, DATEADD(MINUTE, -30, GETDATE()), DATEADD(HOUR, 5, GETDATE()), 'Abierta');

/* =============================================================
   13. INTEGRANTES DE PLANCHAS
   ============================================================= */

DECLARE @IdPlanchaAzul INT = (SELECT IdPlancha FROM Planchas WHERE NombrePlancha = 'Plancha Azul');
DECLARE @IdPlanchaRoja INT = (SELECT IdPlancha FROM Planchas WHERE NombrePlancha = 'Plancha Roja');
DECLARE @IdPlanchaVerde INT = (SELECT IdPlancha FROM Planchas WHERE NombrePlancha = 'Plancha Verde Primaria');
DECLARE @IdPlanchaAmarilla INT = (SELECT IdPlancha FROM Planchas WHERE NombrePlancha = 'Plancha Amarilla Primaria');

INSERT INTO IntegrantesPlancha (IdPlancha, IdUsuario, IdCargo)
SELECT @IdPlanchaAzul, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('azul1', 1), ('azul2', 2), ('azul3', 3), ('azul4', 4), ('azul5', 5),
    ('azul6', 6), ('azul7', 7), ('azul8', 8), ('azul9', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;

INSERT INTO IntegrantesPlancha (IdPlancha, IdUsuario, IdCargo)
SELECT @IdPlanchaRoja, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('roja1', 1), ('roja2', 2), ('roja3', 3), ('roja4', 4), ('roja5', 5),
    ('roja6', 6), ('roja7', 7), ('roja8', 8), ('roja9', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;

INSERT INTO IntegrantesPlancha (IdPlancha, IdUsuario, IdCargo)
SELECT @IdPlanchaVerde, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('Mateo01', 1), ('Luciana01', 2), ('Sebastian01', 3), ('Emma01', 4), ('Lucas01', 5),
    ('Valentina01', 6), ('Santiago01', 7), ('CamilaP01', 8), ('DiegoP01', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;

INSERT INTO IntegrantesPlancha (IdPlancha, IdUsuario, IdCargo)
SELECT @IdPlanchaAmarilla, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('Isabella01', 1), ('Adrian01', 2), ('Renata01', 3), ('Nicolas01', 4), ('Paula01', 5),
    ('Alejandro01', 6), ('DanielaP01', 7), ('Gabriel01', 8), ('Victoria01', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;
GO

/* =============================================================
   14. VERIFICACIÓN FINAL
   ============================================================= */

SELECT * FROM Roles ORDER BY IdRol;

SELECT COUNT(*) AS TotalPadrones FROM PadronesElectorales;

SELECT 
    U.IdUsuario,
    U.Matricula,
    U.NombreCompleto,
    U.Username,
    R.NombreRol,
    PE.NombrePadron,
    U.EstadoUsuario,
    U.YaVoto
FROM Usuarios U
INNER JOIN Roles R ON U.IdRol = R.IdRol
INNER JOIN PadronesElectorales PE ON U.IdPadron = PE.IdPadron
ORDER BY U.IdUsuario;

SELECT 
    P.IdPlancha,
    P.NombrePlancha,
    P.Color,
    P.Lema,
    PE.NombrePadron,
    U.NombreCompleto AS AdminPlancha,
    P.EstadoPlancha,
    P.ImagenPath
FROM Planchas P
INNER JOIN PadronesElectorales PE ON P.IdPadron = PE.IdPadron
LEFT JOIN Usuarios U ON P.IdAdminPlancha = U.IdUsuario
ORDER BY P.IdPlancha;

SELECT 
    V.IdVotacion,
    V.NombreVotacion,
    PE.NombrePadron,
    V.FechaInicio,
    V.FechaFin,
    V.EstadoVotacion
FROM Votaciones V
INNER JOIN PadronesElectorales PE ON V.IdPadron = PE.IdPadron
ORDER BY V.IdVotacion;

SELECT 
    P.NombrePlancha,
    C.NombreCargo,
    U.NombreCompleto,
    U.Username
FROM IntegrantesPlancha IP
INNER JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
INNER JOIN Cargos C ON IP.IdCargo = C.IdCargo
INNER JOIN Usuarios U ON IP.IdUsuario = U.IdUsuario
ORDER BY P.NombrePlancha, C.Orden;
GO
select * from Usuarios




SELECT 
    U.IdUsuario,
    U.Username,
    U.NombreCompleto,
    U.IdPadron,
    P.NombrePadron
FROM Usuarios U
INNER JOIN PadronesElectorales P ON U.IdPadron = P.IdPadron
WHERE U.Username = 'admin';

-----------------------------

USE SistemaVotacionesDB;
GO

SELECT 
    U.IdUsuario,
    U.Username,
    U.NombreCompleto,
    R.NombreRol,
    U.IdPadron,
    P.NombrePadron,
    U.YaVoto
FROM Usuarios U
INNER JOIN Roles R ON U.IdRol = R.IdRol
INNER JOIN PadronesElectorales P ON U.IdPadron = P.IdPadron
WHERE R.NombreRol = 'Votante'
ORDER BY U.IdUsuario;



USE SistemaVotacionesDB;
GO

SELECT 
    P.IdPlancha,
    P.NombrePlancha,
    PE.IdPadron,
    PE.NombrePadron,
    P.EstadoPlancha
FROM Planchas P
INNER JOIN PadronesElectorales PE ON P.IdPadron = PE.IdPadron
WHERE P.EstadoPlancha = 1
ORDER BY PE.NombrePadron, P.NombrePlancha;



USE SistemaVotacionesDB;
GO

SELECT 
    V.IdVotacion,
    V.NombreVotacion,
    PE.IdPadron,
    PE.NombrePadron,
    V.EstadoVotacion,
    V.FechaInicio,
    V.FechaFin
FROM Votaciones V
INNER JOIN PadronesElectorales PE ON V.IdPadron = PE.IdPadron
WHERE V.EstadoVotacion = 'Abierta'
ORDER BY V.IdVotacion;



-------------------------

USE SistemaVotacionesDB;
GO

DECLARE @PadronMarcos INT;

SELECT @PadronMarcos = IdPadron
FROM Usuarios
WHERE Username = 'Marcos01';

-- Asegurar que Marcos sea votante activo y no haya votado
UPDATE Usuarios
SET 
    IdRol = 2,
    EstadoUsuario = 1,
    YaVoto = 0
WHERE Username = 'Marcos01';

-- Activar planchas de su padrón
UPDATE Planchas
SET EstadoPlancha = 1
WHERE IdPadron = @PadronMarcos;

-- Si no hay votación abierta para ese padrón, crear una
IF NOT EXISTS (
    SELECT 1
    FROM Votaciones
    WHERE IdPadron = @PadronMarcos
    AND EstadoVotacion = 'Abierta'
    AND GETDATE() BETWEEN FechaInicio AND FechaFin
)
BEGIN
    INSERT INTO Votaciones
    (NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion)
    VALUES
    (
        'Elecciones de prueba Marcos01',
        @PadronMarcos,
        DATEADD(MINUTE, -10, GETDATE()),
        DATEADD(HOUR, 5, GETDATE()),
        'Abierta'
    );
END
ELSE
BEGIN
    UPDATE Votaciones
    SET 
        EstadoVotacion = 'Abierta',
        FechaInicio = DATEADD(MINUTE, -10, GETDATE()),
        FechaFin = DATEADD(HOUR, 5, GETDATE())
    WHERE IdPadron = @PadronMarcos;
END
GO