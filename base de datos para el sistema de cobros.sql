
CREATE DATABASE SISTEMA_COBROS2
GO

USE SISTEMA_COBROS2

GO

create table rol(
idrol int primary key identity,
descripcion varchar(50)
)

go

create table Concepto(
idConcepto int primary key identity,
Descripcion varchar(50)
)
go

create table Horarios(
idHorario int primary key identity,
Hora varchar(50)
)
go

create table Tipos(
idTipos int primary key identity,
Tipo varchar(50)
)
go

create table Dias(
idDias int primary key identity,
Dia varchar(50)
)
go

create table permiso(
idpermiso int primary key identity,
idrol int references rol(idrol),
NombreMenu varchar(100)
)

go

create table Estudiantes(
idEstudiantes int primary key identity,
NombreCompleto varchar (50),
Cedula varchar(50),
Correo varchar(50),
Telefono varchar(50),
)

go


create table Usuario(
idUsuario int primary key identity,
idrol int references rol(idrol),
NombreCompleto varchar (50),
Clave varchar(50)
)

go

create table Cursos(
idCursos int primary key identity,
NombreCurso varchar (50),
duracionCurso int
)

go

create table Pagos(
idPagos int primary key identity,
idEstudiantes int references Estudiantes(idEstudiantes),
idCursos int references Cursos(idCursos),
NombreCompleto varchar (50),
Cedula varchar(50),
MontoTotal decimal(10,2),
fecharegistro datetime default getdate(),
Estado bit,
idUsuario int references Usuario(idUsuario),
Referencia varchar(50),
idTipos int references Tipos(idTipos),
Bancos varchar(50),
idConcepto int,
idDias int,
idHorario int
)

go

create table Estado_de_Cuenta(
idEstudiantes int,
idConcepto int references Concepto(idConcepto),
idCursos int references Cursos(idCursos),
idHorario int references Horarios(idHorario),
idDias int references Dias(idDias),
MontoTotal varchar(50),
idTipos int references Tipos(idTipos),
Banco varchar(50),
Referencia varchar(50),
FechaInicio date,
FechaFin date,
Estado bit,
NumeroClase int,
idEstado int primary key identity
)
go

create table Camisa(
idTipoCam int primary key identity,
Talla varchar (10)
)

go

create table Pantalon(
idTipoPan int primary key identity,
Talla varchar (10)
)

go

create table Uniformes(
idEstudiante int,
idTipoCam int,
idTipoPan int,
idCursos int,
idConcepto int,
MontoTotal varchar(50),
idTipos int,
Banco varchar(50),
Referencia varchar(50),
NumeroAbono int,
FechaPago date,
Estado bit
)
go

create table Contador(
contador int
)
go

create table Contador1(
contador int
)
go

create table Contador2(
contador int
)
go

/*Procedimientos almacenados*/

create type [dbo].[Inscripciones_nuevas] as table(
	/*[idEstudiantes] int null,*/
	[NombreCompleto] varchar(50) null,
	[Cedula] varchar(50) null,
	[Telefono] varchar(50) null,
	[Correo] varchar(50) null,
	[idCursos] int null,
	[idHorario] int null,
	[Montoini] varchar(50) null,
	[idDias] int null,
	[fechacreacion] datetime null,
	[idTipos] int null,
	[Referencia] varchar(50) null,
	[Bancos] varchar(50) null,
	[idConcepto] int null
)
go


/* */
CREATE PROCEDURE sp_Inscripciones(
    @NombreCompleto  VARCHAR(50),
    @Cedula          VARCHAR(50),
    @Telefono        VARCHAR(50),
    @Correo          VARCHAR(50),
    @idCursos        INT,
    @idHorario       INT,
    @Montoini        VARCHAR(50),  -- Monto total de la inscripción (sin dividir)
    @idDias          INT,          -- Día de la semana deseado (1=lunes, …, 7=domingo) para el vencimiento de pago
    @fechacreacion   DATETIME,     -- Fecha en la que se realiza la inscripción
    @idTipos         INT,
    @Referencia      VARCHAR(50),
    @Bancos          VARCHAR(50),
    @idConcepto      INT,
    @Inscripcion     [Inscripciones_nuevas] READONLY,  -- Otros datos adicionales si se requieren
    @Resultado       BIT OUTPUT,
    @Mensaje         VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        -- Declaración de variables necesarias
        DECLARE @idEstudiante    INT = 0,
                @duracionCurso   INT,
                @totalPagos      INT, 
                @i               INT = 0;
                
        SET @Resultado = 1;
        SET @Mensaje = '';

        BEGIN TRANSACTION registro;

            -------------------------
            -- 1. Registro del estudiante
            -------------------------
            INSERT INTO Estudiantes (NombreCompleto, Cedula, Correo, Telefono)
            VALUES (@NombreCompleto, @Cedula, @Correo, @Telefono);

            SET @idEstudiante = SCOPE_IDENTITY();
            IF @idEstudiante IS NULL OR @idEstudiante = 0
            BEGIN
                SET @Resultado = 0;
                SET @Mensaje = 'Error al obtener idEstudiante. Valor: ' + CAST(@idEstudiante AS VARCHAR(10));
                ROLLBACK TRANSACTION registro;
                RETURN;
            END;

            -------------------------
            -- 2. Obtención de la duración del curso (en meses)
            -------------------------
            SELECT @duracionCurso = duracionCurso
            FROM Cursos
            WHERE idCursos = @idCursos;

            IF @duracionCurso IS NULL OR @duracionCurso <= 0
            BEGIN
                SET @Resultado = 0;
                SET @Mensaje = 'Error: Curso no encontrado o duración inválida.';
                ROLLBACK TRANSACTION registro;
                RETURN;
            END;

            -- Se calcula el total de pagos según la duración:
            -- Para un curso de 6 meses: se generan pagos desde 0 hasta 24 (25 registros).
            -- Para un curso de 3 meses: se generan pagos desde 0 hasta 12 (13 registros).
            SET @totalPagos = CASE 
                                WHEN @duracionCurso = 6 THEN 24 + 1
                                WHEN @duracionCurso = 3 THEN 12 + 1
                                ELSE (@duracionCurso * 4) + 1  -- Generalización para otros casos, si hubiera.
                             END;

            -------------------------
            -- 4. Registro de los pagos en la tabla Estado_de_Cuenta
            -------------------------
            WHILE @i < @totalPagos
            BEGIN
                IF @i = 0
                BEGIN
                    INSERT INTO Estado_de_Cuenta (
                        idEstudiantes,
                        idCursos,
                        NumeroClase,
                        FechaInicio,
                        MontoTotal,
                        Estado,
                        idDias,
                        idHorario,
                        idTipos,
                        Referencia,
                        Banco,
                        idConcepto
                    )
                    VALUES (
                        @idEstudiante,
                        @idCursos,
                        0,
                        @fechacreacion,
                        CAST(@Montoini AS DECIMAL(18,2)),
                        1,       -- Estado Solvente (Inscripción)
                        @idDias,
                        @idHorario,
                        @idTipos,
                        @Referencia,
                        @Bancos,
                        @idConcepto
                    );
                END
                ELSE
                BEGIN
                    INSERT INTO Estado_de_Cuenta (
                        idEstudiantes,
                        idCursos,
                        NumeroClase,
                        MontoTotal,
                        Estado,
                        idDias,
                        idHorario,
                        idTipos,
                        Referencia,
                        Banco,
                        idConcepto
                    )
                    VALUES (
                        @idEstudiante,
                        @idCursos,
                        @i,
                        NULL,    -- MontoTotal se dejará como NULL hasta que se programe el pago
                        0,       -- Estado pendiente o inactivo
                        @idDias,
                        @idHorario,
                        @idTipos,
                        @Referencia,
                        @Bancos,
                        @idConcepto
                    );
                END;

                SET @i = @i + 1;
            END;

        COMMIT TRANSACTION registro;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION registro;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO



create type [dbo].[Registro de Pagos] as table(
	[NombreCompleto] varchar(50) null,
	[Cedula] varchar(50) null,
	[idCursos] int null,
	[idHorario] int null,
	[MontoTotal] varchar(50) null,
	[idDias] int null,
	[fechacreacion] datetime null,
	[idTipos] int null,
	[Referencia] varchar(50) null,
	[Bancos] varchar(50) null,
	[idConcepto] int null,
	[NumeroClase] int null
)
go


CREATE PROCEDURE sp_RegistroPagos
(
    @NombreCompleto  VARCHAR(50),
    @Cedula          VARCHAR(50),
    @idCursos        INT,
    @idHorario       INT,
    @MontoTotal      VARCHAR(50),  
    @idDias          INT,         
    @fechacreacion   DATETIME,     
    @idTipos         INT,
    @Referencia      VARCHAR(50),
    @Bancos          VARCHAR(50),
    @idConcepto      INT,
    @NumeroClase     VARCHAR(10),
    @Pago            dbo.[Registro de Pagos] READONLY,  
    @Resultado       BIT OUTPUT,
    @Mensaje         VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
		DECLARE @IdEstudianteFound INT;
        SELECT @IdEstudianteFound = E.idEstudiantes
        FROM Estado_de_Cuenta ES
		inner join Estudiantes E on E.idEstudiantes = ES.idEstudiantes
		inner join Cursos C on C.idCursos = ES.idCursos
		inner join Horarios H on H.idHorario = ES.idHorario
		inner join Dias D on D.idDias = ES.idDias
        WHERE E.Cedula = @Cedula and E.NombreCompleto = @NombreCompleto and ES.idCursos = @idCursos and ES.idHorario = @idHorario and ES.idDias = @idDias;

        IF (@IdEstudianteFound IS NULL)
        BEGIN
            ROLLBACK TRANSACTION;
            SET @Resultado = 0;
            SET @Mensaje = 'El estudiante que usted ha escrito no existe en el curso, el horario o el día que usted seleccionó, por favor verifique la cédula y el nombre o alguno de los datos anteriores.';
            RETURN;
        END;
		 IF (CONVERT(INT, @NumeroClase) = 1)
		begin

		DECLARE @DuracionCurso INT;
		SELECT @DuracionCurso = duracionCurso
		FROM Cursos
		WHERE idCursos = @idCursos;

		IF (@DuracionCurso IS NULL)
		BEGIN
			ROLLBACK TRANSACTION;
			SET @Resultado = 0;
			SET @Mensaje = 'No se encontró la duración para el curso proporcionado.';
			RETURN;
		END;

		DECLARE @totalCuotas INT;
		SET @totalCuotas = CASE 
							 WHEN @DuracionCurso = 6 THEN 24  
							 WHEN @DuracionCurso = 3 THEN 12  
							 ELSE 0  -- Se puede ajustar para otras duraciones
						   END;

		IF (@totalCuotas = 0)
		BEGIN
			ROLLBACK TRANSACTION;
			SET @Resultado = 0;
			SET @Mensaje = 'La duración del curso debe ser de 3 o 6 meses.';
			RETURN;
		END;

		IF (@idConcepto = 2)
		BEGIN
			/* Actualización de la cuota que se está pagando: NumeroClase = 1 */
			UPDATE Estado_de_Cuenta
			SET 
				 -- Se calcula la fecha de pago de forma semanal.
				 FechaFin   = DATEADD(DAY, (CONVERT(INT, NumeroClase)* 7), @fechacreacion),
				 MontoTotal = @MontoTotal,  -- Se asigna el monto recibido en esta cuota
				 Estado     = 1,            -- Pago realizado
				 idDias     = @idDias,
				 Referencia = @Referencia,
				 Banco      = @Bancos,
				 idConcepto = @idConcepto,
				 idTipos    = @idTipos
				 -- No se incluye FechaInicio, por lo que se deja sin modificar.
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) = 1;

			UPDATE Estado_de_Cuenta
			SET Estado = 0
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) between 2 and @totalCuotas;

			UPDATE Estado_de_Cuenta
			SET FechaInicio = @fechacreacion
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) = 1;

			UPDATE Estado_de_Cuenta
			SET FechaFin = DATEADD(DAY, (CONVERT(INT, NumeroClase)* 7), @fechacreacion)
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) between 1 and @totalCuotas;
		END

		ELSE IF (@idConcepto = 3)
		BEGIN
			UPDATE Estado_de_Cuenta
			SET 
				 Estado     = 1,  -- Se marca como pagadas (o activas)
				 idDias     = @idDias,
				 Referencia = @Referencia,
				 Banco      = @Bancos,
				 idConcepto = @idConcepto,
				 idTipos    = @idTipos
				 -- Tampoco se actualiza FechaInicio, para mantener el valor original.
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 4;

			UPDATE Estado_de_Cuenta
			SET Estado = 0
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) between 5 and @totalCuotas;

			UPDATE Estado_de_Cuenta
			SET FechaFin = DATEADD(DAY, (CONVERT(INT, NumeroClase)* 7), @fechacreacion)
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) between 1 and @totalCuotas;

			UPDATE Estado_de_Cuenta
			SET MontoTotal = @MontoTotal
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 4;

			UPDATE Estado_de_Cuenta
			SET FechaInicio = @fechacreacion
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 4;
		END
	end
    ELSE
        BEGIN
            IF (@idConcepto = 2)
            BEGIN
                UPDATE Estado_de_Cuenta
                SET 
                    MontoTotal = @MontoTotal,
                    idDias = @idDias,
                    FechaInicio = @fechacreacion,
                    Referencia = @Referencia,
                    Banco = @Bancos,
                    Estado = 1,
                    idConcepto = @idConcepto,
                    idTipos = @idTipos
                WHERE NumeroClase = @NumeroClase
                  AND idEstudiantes = @IdEstudianteFound;

                IF (@@ROWCOUNT = 0)
                BEGIN
                    ROLLBACK TRANSACTION;
                    SET @Resultado = 0;
                    SET @Mensaje = 'No se encontró registro en Estado de Cuenta para actualizar (Concepto 2).';
                    RETURN;
                END;
            END
            ELSE IF (@idConcepto = 3)
            BEGIN
                UPDATE Estado_de_Cuenta
                SET 
                    MontoTotal = @MontoTotal,
                    idDias = @idDias,
                    FechaInicio = @fechacreacion,
                    Referencia = @Referencia,
                    Banco = @Bancos,
                    Estado = 1,
                    idConcepto = @idConcepto,
                    idTipos = @idTipos
                WHERE idEstudiantes = @IdEstudianteFound
                  AND CONVERT(INT, NumeroClase) BETWEEN CONVERT(INT, @NumeroClase) AND (CONVERT(INT, @NumeroClase) + 3);

                IF (@@ROWCOUNT = 0)
                BEGIN
                    ROLLBACK TRANSACTION;
                    SET @Resultado = 0;
                    SET @Mensaje = 'No se encontró registro en Estado de Cuenta para actualizar (Concepto 3).';
                    RETURN;
                END;
            END
            ELSE IF (@idConcepto = 4)
            BEGIN
                UPDATE Uniformes
                SET 
                    MontoTotal = @MontoTotal,
                    Referencia = @Referencia,
                    Banco = @Bancos,
                    Estado = 1,
                    idConcepto = @idConcepto,
                    idTipos = @idTipos
                WHERE NumeroAbono = @NumeroClase
                  AND idEstudiante = @IdEstudianteFound;

                IF (@@ROWCOUNT = 0)
                BEGIN
                    ROLLBACK TRANSACTION;
                    SET @Resultado = 0;
                    SET @Mensaje = 'No se encontró registro en Uniformes para actualizar.';
                    RETURN;
                END;
            END;
        END;

        IF (@idConcepto IN (2,3))
        BEGIN
            INSERT INTO Pagos (idCursos, NombreCompleto, Cedula, idConcepto, idHorario, idDias, idTipos, Bancos, Referencia)
            VALUES (@idCursos, @NombreCompleto, @Cedula, @idConcepto, @idHorario, @idDias, @idTipos, @Bancos, @Referencia);
        END;

        COMMIT TRANSACTION;
        SET @Resultado = 1;
        SET @Mensaje = 'Registro(s) actualizado(s) exitosamente.';
    END TRY
    BEGIN CATCH
        IF (XACT_STATE() <> 0)
            ROLLBACK TRANSACTION;

        SET @Resultado = 0;
        SET @Mensaje = 'Error al actualizar el registro: ' + ERROR_MESSAGE();
        RETURN;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_UniformesRegis 
(
    @NombreCompleto varchar(50),
    @Cedula        varchar(50),
    @idCursos      int,
    @idTipoCam     int,
    @idTipoPan     int,
    @MontoTotal    varchar(50),
    @idTipos       int,
    @Banco         varchar(50),
    @Referencia    varchar(50),
    @FechaPago     date,
    @idConcepto    int,
    @Resultado     BIT OUTPUT,
    @Mensaje       VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION RegisUni;
        
		DECLARE @IdEstudianteFound INT;
		SELECT @IdEstudianteFound = E.idEstudiantes
        FROM Estado_de_Cuenta ES
		inner join Estudiantes E on E.idEstudiantes = ES.idEstudiantes
		inner join Cursos C on C.idCursos = ES.idCursos
        WHERE E.Cedula = @Cedula and E.NombreCompleto = @NombreCompleto and ES.idCursos = @idCursos;

            IF @IdEstudianteFound IS NULL
            BEGIN
                SET @Resultado = 0;
                SET @Mensaje   = 'No se encontró un estudiante en el curso proporcionado que contenga los mismos nombres y cédula.';
                ROLLBACK TRANSACTION RegisUni;
                RETURN;
            END

            -- Inserta 5 registros usando una tabla derivada que genera 5 filas
            INSERT INTO Uniformes 
            (
                idEstudiante,
                idCursos,
                NumeroAbono,
                FechaPago,
                MontoTotal,
                Estado,
                idTipos,
                Referencia,
                Banco,
                idConcepto,
				idTipoCam,
				idTipoPan
            )
            SELECT 
                @IdEstudianteFound, 
                @idCursos, 
                NumeroAbono,                           -- Numeración de abono (1 a 5)
                @FechaPago, 
                CAST(ISNULL(@MontoTotal, '0') AS DECIMAL(18,2)), 
                CASE 
                    WHEN NumeroAbono = 1 THEN 1   -- La primera fila con Estado = 1
                    ELSE 0                      -- Las siguientes con Estado = 0
                END,
                @idTipos, 
                @Referencia, 
                @Banco, 
                @idConcepto,
				@idTipoCam,
				@idTipoPan
            FROM 
            (
                SELECT 1 AS NumeroAbono
                UNION ALL
                SELECT 2
                UNION ALL
                SELECT 3
                UNION ALL
                SELECT 4
                UNION ALL
                SELECT 5
            ) AS Pagos;

        COMMIT TRANSACTION RegisUni;

        SET @Resultado = 1;
        SET @Mensaje = 'Proceso completado correctamente.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION RegisUni;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
GO

create procedure sp_ReportedeEstudiantes(
@FechaInicio date,
@FechaFin date,
@idCurso int
)
as
begin
	set dateformat dmy;  

	select
	convert(Char(10), ES.FechaInicio,103)[FechaRegistro], E.Cedula, E.NombreCompleto[NombreCompleto], C.NombreCurso[Curso], 
	H.Hora[Horario], D.Dia[Día], ES.MontoTotal[MontoTotal], T.Tipo[TipoPago], CO.Descripcion[Concepto],
	ES.Banco, ES.Referencia, ES.Estado, Es.NumeroClase, CONVERT(CHAR(10), ES.FechaFin, 103)[FechaVencimiento]
	from Estado_de_Cuenta ES
	inner join Estudiantes E on E.idEstudiantes = ES.idEstudiantes
	inner join Concepto CO on CO.idConcepto = ES.idConcepto
	inner join Cursos C on C.idCursos = ES.idCursos
	inner join Horarios H on H.idHorario = ES.idHorario
	inner join Dias D on D.idDias = ES.idDias
	inner join Tipos T on T.idTipos = ES.idTipos
	 WHERE CONVERT(date, ES.FechaInicio) BETWEEN @FechaInicio AND @FechaFin
	and C.idCursos = iif(@idCurso = 0, C.idCursos, @idCurso)

end
go

CREATE PROCEDURE sp_ReportedeEstudiantesPendientesHoy(
@FechaHoy DATE,
@idCurso INT
)AS
BEGIN
    SET DATEFORMAT dmy;  

   select
	convert(Char(10), ES.FechaInicio,103)[FechaRegistro], E.Cedula, E.NombreCompleto[NombreCompleto], C.NombreCurso[Curso], 
	H.Hora[Horario], D.Dia[Día], ES.MontoTotal[MontoTotal], T.Tipo[TipoPago], CO.Descripcion[Concepto],
	ES.Banco, ES.Referencia, ES.Estado, Es.NumeroClase, CONVERT(CHAR(10), ES.FechaFin, 103)[FechaVencimiento]
	from Estado_de_Cuenta ES
	inner join Estudiantes E on E.idEstudiantes = ES.idEstudiantes
	inner join Concepto CO on CO.idConcepto = ES.idConcepto
	inner join Cursos C on C.idCursos = ES.idCursos
	inner join Horarios H on H.idHorario = ES.idHorario
	inner join Dias D on D.idDias = ES.idDias
	inner join Tipos T on T.idTipos = ES.idTipos
	WHERE ES.FechaFin = @FechaHoy
	and C.idCursos = iif(@idCurso = 0, C.idCursos, @idCurso)
END
GO

create procedure sp_Estudiante
as
begin
	select 
	E.idEstudiantes, E.Cedula, E.NombreCompleto[NombreCompleto], E.Correo, E.Telefono
	from Estudiantes E

end
go


create procedure sp_Eliminar(
@idEstudiantes int
)
as 
begin
	delete from Estudiantes where idEstudiantes = @idEstudiantes
	delete from Estado_de_Cuenta where idEstudiantes = @idEstudiantes

end
go

create procedure sp_Eliminar2(
@idEstudiantes int
)
as 
begin
	delete from Uniformes where idEstudiante = @idEstudiantes

end
go


create procedure sp_ReportedeUniformes
as
begin
	set dateformat dmy;  

	select
	E.idestudiantes, convert(Char(10), Uni.FechaPago,103)[FechaRegistro], E.Cedula, E.NombreCompleto[NombreCompleto], C.NombreCurso[Curso],
	Uni.MontoTotal[MontoTotal], T.Tipo[TipoPago], CO.Descripcion[Concepto],
	Uni.Banco, Uni.Referencia, Uni.Estado
	from Uniformes Uni
	inner join Estudiantes E on E.idEstudiantes = Uni.idEstudiante
	inner join Concepto CO on CO.idConcepto = Uni.idConcepto
	inner join Cursos C on C.idCursos = Uni.idCursos
	inner join Tipos T on T.idTipos = Uni.idTipos
	where Uni.Estado = 1
end
go

/*Datos Base*/

insert into rol (descripcion)
values ('ADMINISTRADOR')
go

insert into Usuario(idrol, NombreCompleto, Clave)
values(1, 'CEVENCA', 'oKgd73Hm42')
go

insert into Camisa(Talla)
values

('S'),
('M'),
('L'),
('XL'),
('2XL')
go

insert into Pantalon(Talla)
values

('S'),
('M'),
('L'),
('XL'),
('2XL')
go

insert into Concepto(Descripcion)values

('Inscripción'),
('Pago Semanal'),
('Pago Mensual'),
('Uniforme')
go

insert into Contador(contador)values (1)
go

insert into Contador1(contador)values (1)
go

insert into Contador2(contador)values (1)
go

insert into Cursos(NombreCurso, duracionCurso)values

('Laboratorio', 6),
('Enfermería', 6),
('Odontología', 6),
('Fisioterapia', 6),
('Farmacia', 6),
('Refrigeración', 3),
('Marketing Digital', 3),
('Masoterapia', 3)
go

insert into Dias(Dia)values

('Lunes'),
('Martes'),
('Miércoles'),
('Jueves'),
('Viernes'),
('Sábado')
go

insert into Tipos(Tipo)values

('Divisa'),
('Bolívares en efectivo'),
('Transferencia'),
('Depósito'),
('Pago móvil')
go

insert into Horarios(Hora)values

('8 am a 11 am'),
('11 am a 2 pm'),
('2 pm a 5 pm')
go