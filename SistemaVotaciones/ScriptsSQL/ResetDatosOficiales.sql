USE SistemaVotacionesDB;
GO

/* =====================================================
   RESET DE DATOS Y CARGA OFICIAL DEL SISTEMA
   Sistema de Votaciones Escolares
   ===================================================== */

---------------------------------------------------------
-- 1. BORRAR DATOS EN ORDEN CORRECTO
---------------------------------------------------------

DELETE FROM Votos;
DELETE FROM IntegrantesPlancha;
DELETE FROM Planchas;
DELETE FROM Votaciones;
DELETE FROM Usuarios;
DELETE FROM PadronesElectorales;
DELETE FROM Cargos;
DELETE FROM Roles;
GO

---------------------------------------------------------
-- 2. REINICIAR IDENTITY
---------------------------------------------------------

DBCC CHECKIDENT ('Votos', RESEED, 0);
DBCC CHECKIDENT ('IntegrantesPlancha', RESEED, 0);
DBCC CHECKIDENT ('Planchas', RESEED, 0);
DBCC CHECKIDENT ('Votaciones', RESEED, 0);
DBCC CHECKIDENT ('Usuarios', RESEED, 0);
DBCC CHECKIDENT ('PadronesElectorales', RESEED, 0);
DBCC CHECKIDENT ('Cargos', RESEED, 0);
DBCC CHECKIDENT ('Roles', RESEED, 0);
GO

---------------------------------------------------------
-- 3. INSERTAR ROLES
---------------------------------------------------------

INSERT INTO Roles (NombreRol)
VALUES 
('Administrador'),
('Votante'),
('AdministradorPlancha');
GO

---------------------------------------------------------
-- 4. INSERTAR PADRÓN OFICIAL
---------------------------------------------------------

INSERT INTO PadronesElectorales
(Nivel, Grado, Seccion, Modalidad, NombrePadron)
VALUES
('Secundaria', '5to', 'B', 'Informática', 'Secundaria 5to B Informática');
GO

---------------------------------------------------------
-- 5. INSERTAR CARGOS OFICIALES DE PLANCHA
---------------------------------------------------------

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

---------------------------------------------------------
-- 6. VARIABLES BASE
---------------------------------------------------------

DECLARE @IdRolAdmin INT;
DECLARE @IdRolVotante INT;
DECLARE @IdRolAdminPlancha INT;
DECLARE @IdPadron INT;

SELECT @IdRolAdmin = IdRol FROM Roles WHERE NombreRol = 'Administrador';
SELECT @IdRolVotante = IdRol FROM Roles WHERE NombreRol = 'Votante';
SELECT @IdRolAdminPlancha = IdRol FROM Roles WHERE NombreRol = 'AdministradorPlancha';
SELECT @IdPadron = IdPadron FROM PadronesElectorales WHERE NombrePadron = 'Secundaria 5to B Informática';

---------------------------------------------------------
-- 7. INSERTAR USUARIO ADMINISTRADOR GENERAL
---------------------------------------------------------

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('ADM001', 'Administrador General', 'Secundaria', '5to', 'B', 'Informática', 'admin', '1234', @IdRolAdmin, @IdPadron, 1, 0);

---------------------------------------------------------
-- 8. INSERTAR ADMINISTRADORES DE PLANCHA
---------------------------------------------------------

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('AP001', 'Administrador Plancha Azul', 'Secundaria', '5to', 'B', 'Informática', 'adminazul', '1234', @IdRolAdminPlancha, @IdPadron, 1, 0),
('AP002', 'Administrador Plancha Roja', 'Secundaria', '5to', 'B', 'Informática', 'adminroja', '1234', @IdRolAdminPlancha, @IdPadron, 1, 0);

---------------------------------------------------------
-- 9. INSERTAR INTEGRANTES / VOTANTES PLANCHA AZUL
---------------------------------------------------------

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('AZ001', 'Carlos Méndez', 'Secundaria', '5to', 'B', 'Informática', 'azul1', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ002', 'Laura Pérez', 'Secundaria', '5to', 'B', 'Informática', 'azul2', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ003', 'Andrés Ramírez', 'Secundaria', '5to', 'B', 'Informática', 'azul3', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ004', 'María Gómez', 'Secundaria', '5to', 'B', 'Informática', 'azul4', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ005', 'Diego Castillo', 'Secundaria', '5to', 'B', 'Informática', 'azul5', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ006', 'Ana Rodríguez', 'Secundaria', '5to', 'B', 'Informática', 'azul6', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ007', 'Luis Fernández', 'Secundaria', '5to', 'B', 'Informática', 'azul7', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ008', 'Camila Núñez', 'Secundaria', '5to', 'B', 'Informática', 'azul8', '1234', @IdRolVotante, @IdPadron, 1, 0),
('AZ009', 'Javier Santos', 'Secundaria', '5to', 'B', 'Informática', 'azul9', '1234', @IdRolVotante, @IdPadron, 1, 0);

---------------------------------------------------------
-- 10. INSERTAR INTEGRANTES / VOTANTES PLANCHA ROJA
---------------------------------------------------------

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('RJ001', 'Daniel Herrera', 'Secundaria', '5to', 'B', 'Informática', 'roja1', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ002', 'Sofía Martínez', 'Secundaria', '5to', 'B', 'Informática', 'roja2', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ003', 'Miguel Torres', 'Secundaria', '5to', 'B', 'Informática', 'roja3', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ004', 'Valeria Jiménez', 'Secundaria', '5to', 'B', 'Informática', 'roja4', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ005', 'Pedro Morales', 'Secundaria', '5to', 'B', 'Informática', 'roja5', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ006', 'Gabriela Peña', 'Secundaria', '5to', 'B', 'Informática', 'roja6', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ007', 'Samuel Vargas', 'Secundaria', '5to', 'B', 'Informática', 'roja7', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ008', 'Isabella Díaz', 'Secundaria', '5to', 'B', 'Informática', 'roja8', '1234', @IdRolVotante, @IdPadron, 1, 0),
('RJ009', 'Emmanuel Cruz', 'Secundaria', '5to', 'B', 'Informática', 'roja9', '1234', @IdRolVotante, @IdPadron, 1, 0);

---------------------------------------------------------
-- 11. INSERTAR VOTANTES ADICIONALES
---------------------------------------------------------

INSERT INTO Usuarios
(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
VALUES
('VT001', 'Juan López', 'Secundaria', '5to', 'B', 'Informática', 'votante1', '1234', @IdRolVotante, @IdPadron, 1, 0),
('VT002', 'Paola Reyes', 'Secundaria', '5to', 'B', 'Informática', 'votante2', '1234', @IdRolVotante, @IdPadron, 1, 0),
('VT003', 'Ricardo Medina', 'Secundaria', '5to', 'B', 'Informática', 'votante3', '1234', @IdRolVotante, @IdPadron, 1, 0),
('VT004', 'Natalia Batista', 'Secundaria', '5to', 'B', 'Informática', 'votante4', '1234', @IdRolVotante, @IdPadron, 1, 0),
('VT005', 'José Almonte', 'Secundaria', '5to', 'B', 'Informática', 'votante5', '1234', @IdRolVotante, @IdPadron, 1, 0);

---------------------------------------------------------
-- 12. INSERTAR PLANCHAS OFICIALES
---------------------------------------------------------

DECLARE @IdAdminAzul INT;
DECLARE @IdAdminRoja INT;

SELECT @IdAdminAzul = IdUsuario FROM Usuarios WHERE Username = 'adminazul';
SELECT @IdAdminRoja = IdUsuario FROM Usuarios WHERE Username = 'adminroja';

INSERT INTO Planchas
(NombrePlancha, Color, Lema, IdPadron, EstadoPlancha, IdAdminPlancha)
VALUES
('Plancha Azul', 'Azul', 'Unidos por el cambio estudiantil', @IdPadron, 1, @IdAdminAzul),
('Plancha Roja', 'Rojo', 'Liderazgo, compromiso y participación', @IdPadron, 1, @IdAdminRoja);

---------------------------------------------------------
-- 13. INSERTAR VOTACIÓN OFICIAL ABIERTA
---------------------------------------------------------

INSERT INTO Votaciones
(NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion)
VALUES
('Elecciones Estudiantiles 2026', @IdPadron, DATEADD(MINUTE, -30, GETDATE()), DATEADD(HOUR, 5, GETDATE()), 'Abierta');

---------------------------------------------------------
-- 14. ASIGNAR INTEGRANTES A PLANCHA AZUL
---------------------------------------------------------

DECLARE @IdPlanchaAzul INT;
DECLARE @IdPlanchaRoja INT;

SELECT @IdPlanchaAzul = IdPlancha FROM Planchas WHERE NombrePlancha = 'Plancha Azul';
SELECT @IdPlanchaRoja = IdPlancha FROM Planchas WHERE NombrePlancha = 'Plancha Roja';

INSERT INTO IntegrantesPlancha
(IdPlancha, IdUsuario, IdCargo)
SELECT @IdPlanchaAzul, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('azul1', 1),
    ('azul2', 2),
    ('azul3', 3),
    ('azul4', 4),
    ('azul5', 5),
    ('azul6', 6),
    ('azul7', 7),
    ('azul8', 8),
    ('azul9', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;

---------------------------------------------------------
-- 15. ASIGNAR INTEGRANTES A PLANCHA ROJA
---------------------------------------------------------

INSERT INTO IntegrantesPlancha
(IdPlancha, IdUsuario, IdCargo)
SELECT @IdPlanchaRoja, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('roja1', 1),
    ('roja2', 2),
    ('roja3', 3),
    ('roja4', 4),
    ('roja5', 5),
    ('roja6', 6),
    ('roja7', 7),
    ('roja8', 8),
    ('roja9', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;

---------------------------------------------------------
-- 16. VERIFICACIONES FINALES
---------------------------------------------------------

SELECT * FROM Roles;
SELECT * FROM PadronesElectorales;
SELECT * FROM Cargos;

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

SELECT * FROM Planchas;
SELECT * FROM Votaciones;

SELECT 
    P.NombrePlancha,
    C.NombreCargo,
    U.NombreCompleto,
    U.Matricula
FROM IntegrantesPlancha IP
INNER JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
INNER JOIN Cargos C ON IP.IdCargo = C.IdCargo
INNER JOIN Usuarios U ON IP.IdUsuario = U.IdUsuario
ORDER BY P.NombrePlancha, C.Orden;
GO


