USE SistemaVotacionesDB;
GO

/* =====================================================
   DATOS DE PRUEBA PARA SISTEMA DE VOTACIONES ESCOLARES
   ===================================================== */


/* 1. Asegurar rol AdministradorPlancha */
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'AdministradorPlancha')
BEGIN
    INSERT INTO Roles (NombreRol)
    VALUES ('AdministradorPlancha');
END;
GO


/* 2. Asegurar administradores de plancha */
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Username = 'adminp1')
BEGIN
    INSERT INTO Usuarios (
        Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad,
        Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto
    )
    VALUES (
        '2001', 'Admin Plancha 1', 'Secundaria', '5to', 'B', 'Informática',
        'adminp1', '1234', 3, 2, 1, 0
    );
END;

IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Username = 'adminp2')
BEGIN
    INSERT INTO Usuarios (
        Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad,
        Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto
    )
    VALUES (
        '2002', 'Admin Plancha 2', 'Secundaria', '5to', 'B', 'Informática',
        'adminp2', '1234', 3, 2, 1, 0
    );
END;
GO


/* 3. Crear votantes de prueba para padrón 1 */
INSERT INTO Usuarios (
    Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad,
    Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto
)
SELECT *
FROM (
    VALUES
    ('P1001', 'Estudiante P1 01', 'Primaria', '1ro', 'A', 'Académico', 'p1est1', '1234', 2, 1, 1, 0),
    ('P1002', 'Estudiante P1 02', 'Primaria', '1ro', 'A', 'Académico', 'p1est2', '1234', 2, 1, 1, 0),
    ('P1003', 'Estudiante P1 03', 'Primaria', '1ro', 'A', 'Académico', 'p1est3', '1234', 2, 1, 1, 0),
    ('P1004', 'Estudiante P1 04', 'Primaria', '1ro', 'A', 'Académico', 'p1est4', '1234', 2, 1, 1, 0),
    ('P1005', 'Estudiante P1 05', 'Primaria', '1ro', 'A', 'Académico', 'p1est5', '1234', 2, 1, 1, 0),
    ('P1006', 'Estudiante P1 06', 'Primaria', '1ro', 'A', 'Académico', 'p1est6', '1234', 2, 1, 1, 0),
    ('P1007', 'Estudiante P1 07', 'Primaria', '1ro', 'A', 'Académico', 'p1est7', '1234', 2, 1, 1, 0),
    ('P1008', 'Estudiante P1 08', 'Primaria', '1ro', 'A', 'Académico', 'p1est8', '1234', 2, 1, 1, 0),
    ('P1009', 'Estudiante P1 09', 'Primaria', '1ro', 'A', 'Académico', 'p1est9', '1234', 2, 1, 1, 0)
) AS V(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
WHERE NOT EXISTS (
    SELECT 1 
    FROM Usuarios U 
    WHERE U.Username = V.Username OR U.Matricula = V.Matricula
);
GO


/* 4. Crear votantes de prueba para padrón 2 */
INSERT INTO Usuarios (
    Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad,
    Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto
)
SELECT *
FROM (
    VALUES
    ('P2001', 'Estudiante P2 01', 'Secundaria', '5to', 'B', 'Informática', 'p2est1', '1234', 2, 2, 1, 0),
    ('P2002', 'Estudiante P2 02', 'Secundaria', '5to', 'B', 'Informática', 'p2est2', '1234', 2, 2, 1, 0),
    ('P2003', 'Estudiante P2 03', 'Secundaria', '5to', 'B', 'Informática', 'p2est3', '1234', 2, 2, 1, 0),
    ('P2004', 'Estudiante P2 04', 'Secundaria', '5to', 'B', 'Informática', 'p2est4', '1234', 2, 2, 1, 0),
    ('P2005', 'Estudiante P2 05', 'Secundaria', '5to', 'B', 'Informática', 'p2est5', '1234', 2, 2, 1, 0),
    ('P2006', 'Estudiante P2 06', 'Secundaria', '5to', 'B', 'Informática', 'p2est6', '1234', 2, 2, 1, 0),
    ('P2007', 'Estudiante P2 07', 'Secundaria', '5to', 'B', 'Informática', 'p2est7', '1234', 2, 2, 1, 0),
    ('P2008', 'Estudiante P2 08', 'Secundaria', '5to', 'B', 'Informática', 'p2est8', '1234', 2, 2, 1, 0),
    ('P2009', 'Estudiante P2 09', 'Secundaria', '5to', 'B', 'Informática', 'p2est9', '1234', 2, 2, 1, 0)
) AS V(Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad, Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
WHERE NOT EXISTS (
    SELECT 1 
    FROM Usuarios U 
    WHERE U.Username = V.Username OR U.Matricula = V.Matricula
);
GO


/* 5. Asegurar planchas */
IF NOT EXISTS (SELECT 1 FROM Planchas WHERE NombrePlancha = 'Plancha Primaria Azul')
BEGIN
    INSERT INTO Planchas (
        NombrePlancha, Color, Lema, IdPadron, EstadoPlancha, IdAdminPlancha
    )
    VALUES (
        'Plancha Primaria Azul', 'Azul', 'Unidos por el cambio', 1, 1, NULL
    );
END;

IF NOT EXISTS (SELECT 1 FROM Planchas WHERE NombrePlancha = 'Plancha Secundaria Roja')
BEGIN
    INSERT INTO Planchas (
        NombrePlancha, Color, Lema, IdPadron, EstadoPlancha, IdAdminPlancha
    )
    VALUES (
        'Plancha Secundaria Roja', 'Rojo', 'Liderazgo y compromiso', 2, 1, NULL
    );
END;
GO


/* 6. Asegurar votaciones abiertas */
IF NOT EXISTS (SELECT 1 FROM Votaciones WHERE NombreVotacion = 'Elecciones Primaria 1ro A')
BEGIN
    INSERT INTO Votaciones (
        NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion
    )
    VALUES (
        'Elecciones Primaria 1ro A', 1, DATEADD(MINUTE, -30, GETDATE()), DATEADD(HOUR, 5, GETDATE()), 'Abierta'
    );
END;

IF NOT EXISTS (SELECT 1 FROM Votaciones WHERE NombreVotacion = 'Elecciones Secundaria 5to B')
BEGIN
    INSERT INTO Votaciones (
        NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion
    )
    VALUES (
        'Elecciones Secundaria 5to B', 2, DATEADD(MINUTE, -30, GETDATE()), DATEADD(HOUR, 5, GETDATE()), 'Abierta'
    );
END;
GO


/* 7. Reiniciar votos solo de usuarios de prueba */
UPDATE Usuarios
SET YaVoto = 0
WHERE Username LIKE 'p1est%' OR Username LIKE 'p2est%';
GO


/* 8. Insertar integrantes de Plancha Primaria Azul */
DECLARE @PlanchaPrimaria INT;

SELECT @PlanchaPrimaria = IdPlancha
FROM Planchas
WHERE NombrePlancha = 'Plancha Primaria Azul';

DELETE FROM IntegrantesPlancha
WHERE IdPlancha = @PlanchaPrimaria;

INSERT INTO IntegrantesPlancha (IdPlancha, IdUsuario, IdCargo)
SELECT @PlanchaPrimaria, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('p1est1', 1),
    ('p1est2', 2),
    ('p1est3', 3),
    ('p1est4', 4),
    ('p1est5', 5),
    ('p1est6', 6),
    ('p1est7', 7),
    ('p1est8', 8),
    ('p1est9', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;
GO


/* 9. Insertar integrantes de Plancha Secundaria Roja */
DECLARE @PlanchaSecundaria INT;

SELECT @PlanchaSecundaria = IdPlancha
FROM Planchas
WHERE NombrePlancha = 'Plancha Secundaria Roja';

DELETE FROM IntegrantesPlancha
WHERE IdPlancha = @PlanchaSecundaria;

INSERT INTO IntegrantesPlancha (IdPlancha, IdUsuario, IdCargo)
SELECT @PlanchaSecundaria, U.IdUsuario, C.IdCargo
FROM (
    VALUES
    ('p2est1', 1),
    ('p2est2', 2),
    ('p2est3', 3),
    ('p2est4', 4),
    ('p2est5', 5),
    ('p2est6', 6),
    ('p2est7', 7),
    ('p2est8', 8),
    ('p2est9', 9)
) AS Datos(Username, IdCargo)
INNER JOIN Usuarios U ON U.Username = Datos.Username
INNER JOIN Cargos C ON C.IdCargo = Datos.IdCargo;
GO


/* 10. Verificación final */
SELECT IdUsuario, Matricula, NombreCompleto, Username, IdRol, IdPadron, YaVoto
FROM Usuarios
ORDER BY IdUsuario;

SELECT IdPlancha, NombrePlancha, IdPadron, EstadoPlancha
FROM Planchas;

SELECT IdVotacion, NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion
FROM Votaciones;

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