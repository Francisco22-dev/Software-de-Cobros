use SISTEMA_COBROS2

go

alter table Usuario
add NroDocumento varchar(50),
Estado bit
go

alter table Estado_de_Cuenta
add NroRecibo int
go

alter table Uniformes
add NroRecibo int
go

update Usuario
set NroDocumento='1',
Nombrecompleto = 'Director',
Estado = 1
where idUsuario = 1
go

insert into rol(descripcion)values ('EMPLEADO')
go

insert into rol(descripcion)values ('PROGRAMADOR')
go

insert into Usuario (idrol, NombreCompleto, Clave, NroDocumento, Estado) values
(2, 'SECRETARIA', '', '3', 1)
go

insert into Usuario (idrol, NombreCompleto, Clave, NroDocumento, Estado) values
(3, 'FRANCISCO', 'Fjst2211@$', '31581403', 1)
go

insert into permiso (idrol, NombreMenu) values

(1, 'Inscripciones'),
(1, 'Pagos'),
(1, 'Uniformes'),
(1, 'Registros'),
(1, 'Corte'),
(1, 'Funciones'),
(1, 'Usuarios')
go

insert into permiso (idrol, NombreMenu) values

(3, 'Inscripciones'),
(3, 'Pagos'),
(3, 'Uniformes'),
(3, 'Registros'),
(3, 'Corte'),
(3, 'Funciones'),
(3, 'Usuarios')
go

insert into permiso (idrol, NombreMenu) values

(2, 'Inscripciones'),
(2, 'Pagos'),
(2, 'Uniformes'),
(2, 'Corte')
go

create procedure Permisos(
@idUsuario int
)as
begin
select p.idrol,p.NombreMenu from permiso p
inner join rol r on r.idrol = p.idrol
inner join Usuario u on u.idrol = r.idrol
where idUsuario = @idUsuario

end

go

drop procedure sp_Inscripciones	
go

drop type [Inscripciones_nuevas]
go

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
	[idConcepto] int null,
	[Recibo] int null
)
go

create PROCEDURE sp_Inscripciones(
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
	@Recibo int,
    @Inscripcion     [Inscripciones_nuevas] READONLY,  -- Otros datos adicionales si se requieren
    @Resultado       BIT OUTPUT,
    @Mensaje         VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
			select top 1 @Recibo = contador
			from Contador;
        -- Declaración de variables necesarias
        DECLARE @idEstudiante    INT = 0,
                @duracionCurso   INT,
                @totalPagos      INT, 
                @i               INT = 0;
                
        SET @Resultado = 1;
        SET @Mensaje = '';

        BEGIN TRANSACTION registro;
			
			IF NOT (@Bancos = '' AND @Referencia = '')
			BEGIN
				IF EXISTS (
					SELECT 1 
					FROM Estado_de_Cuenta      
					WHERE Referencia = @Referencia
					  AND Banco = @Bancos
				)
				BEGIN
					ROLLBACK TRANSACTION;
					SET @Resultado = 0;
					SET @Mensaje = 'La referencia está repetida.';
					RETURN;
				END;
			END;

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
                        idConcepto,
						NroRecibo
                    )
                    VALUES (
                        @idEstudiante,
                        @idCursos,
                        0,
                        @fechacreacion,
                        @Montoini,
                        1,       -- Estado Solvente (Inscripción)
                        @idDias,
                        @idHorario,
                        @idTipos,
                        @Referencia,
                        @Bancos,
                        @idConcepto,
						@Recibo
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
                        idConcepto,
						NroRecibo
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
                        @idConcepto,
						null
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

update Concepto
set Descripcion = 'Pago Quincenal' where idConcepto = 3
go

update Concepto
set Descripcion = 'Pago Mensual' where idConcepto = 4
go

insert into Concepto (Descripcion) values ('Pago de uniforme')
go

drop procedure sp_RegistroPagos

drop type [Registro de Pagos]
go

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
	[NumeroClase] int null,
	[Recibo] int null
)
go

create PROCEDURE sp_RegistroPagos
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
	@Recibo int,
    @Pago            dbo.[Registro de Pagos] READONLY,  
    @Resultado       BIT OUTPUT,
    @Mensaje         VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
			select top 1 @Recibo = contador
			from Contador;
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
            SET @Mensaje = 'El estudiante que usted ha escrito no existe en el curso que usted seleccionó, por favor verifique nuevamente la Cédula y el Nombre.';
            RETURN;
        END;

		IF NOT (@Bancos = '' AND @Referencia = '')
		BEGIN
			IF EXISTS (
				SELECT 1 
				FROM Estado_de_Cuenta
				WHERE Referencia = @Referencia
				  AND Banco = @Bancos
			)
			BEGIN
				ROLLBACK TRANSACTION;
				SET @Resultado = 0;
				SET @Mensaje = 'La referencia está repetida.';
				RETURN;
			END;
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
			SET FechaInicio = @fechacreacion,
			NroRecibo = @Recibo
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) = 1;

			UPDATE Estado_de_Cuenta
			SET FechaFin = DATEADD(DAY, (CONVERT(INT, NumeroClase)* 7), @fechacreacion)
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) between 1 and @totalCuotas;
		END

		ELSE IF (@idConcepto = 4)
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
			SET MontoTotal = @MontoTotal,
			NroRecibo = @Recibo
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 4;

			UPDATE Estado_de_Cuenta
			SET FechaInicio = @fechacreacion
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 4;
		END
		else if (@idConcepto = 3)
		begin
		update Estado_de_Cuenta
		set 
			 Estado     = 1,  -- Se marca como pagadas (o activas)
				 idDias     = @idDias,
				 Referencia = @Referencia,
				 Banco      = @Bancos,
				 idConcepto = @idConcepto,
				 idTipos    = @idTipos
				 -- Tampoco se actualiza FechaInicio, para mantener el valor original.
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 2;

			UPDATE Estado_de_Cuenta
			SET Estado = 0
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) between 3 and @totalCuotas;

			UPDATE Estado_de_Cuenta
			SET FechaFin = DATEADD(DAY, (CONVERT(INT, NumeroClase)* 7), @fechacreacion)
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) between 1 and @totalCuotas;

			UPDATE Estado_de_Cuenta
			SET MontoTotal = @MontoTotal,
			NroRecibo = @Recibo
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 2;

			UPDATE Estado_de_Cuenta
			SET FechaInicio = @fechacreacion
			WHERE idEstudiantes = @IdEstudianteFound
			  AND CONVERT(INT, NumeroClase) BETWEEN 1 AND 2;
		end
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
			else if (@idConcepto = 3)
			begin
				update Estado_de_Cuenta
				set 
					MontoTotal = @MontoTotal,
                    idDias = @idDias,
                    FechaInicio = @fechacreacion,
                    Referencia = @Referencia,
                    Banco = @Bancos,
                    Estado = 1,
                    idConcepto = @idConcepto,
                    idTipos = @idTipos,
					NroRecibo = @Recibo
                WHERE idEstudiantes = @IdEstudianteFound
                  AND CONVERT(INT, NumeroClase) BETWEEN CONVERT(INT, @NumeroClase) AND (CONVERT(INT, @NumeroClase) + 1);
			end
            ELSE IF (@idConcepto = 4)
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
                    idTipos = @idTipos,
					NroRecibo = @Recibo
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
            ELSE IF (@idConcepto = 5)
            BEGIN
                UPDATE Uniformes
                SET 
                    MontoTotal = @MontoTotal,
                    Referencia = @Referencia,
                    Banco = @Bancos,
                    Estado = 1,
                    idConcepto = @idConcepto,
                    idTipos = @idTipos,
					NroRecibo = @Recibo
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

        IF (@idConcepto IN (2,3,4))
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

alter PROCEDURE sp_UniformesRegis 
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
	@Recibo int,
    @Resultado     BIT OUTPUT,
    @Mensaje       VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
			select top 1 @Recibo = contador
			from Contador;
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
			IF NOT (@Banco = '' AND @Referencia = '')
			BEGIN
				IF EXISTS (
					SELECT 1 
					FROM Estado_de_Cuenta      
					WHERE Referencia = @Referencia
					  AND Banco = @Banco
				)
				BEGIN
					ROLLBACK TRANSACTION;
					SET @Resultado = 0;
					SET @Mensaje = 'La referencia está repetida.';
					RETURN;
				END;
			END;


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
				idTipoPan,
				NroRecibo
            )
            SELECT 
                @IdEstudianteFound, 
                @idCursos, 
                NumeroAbono,                           -- Numeración de abono (1 a 5)
                @FechaPago, 
                @MontoTotal,
                CASE 
                    WHEN NumeroAbono = 1 THEN 1   -- La primera fila con Estado = 1
                    ELSE 0                      -- Las siguientes con Estado = 0
                END,
                @idTipos, 
                @Referencia, 
                @Banco, 
                @idConcepto,
				@idTipoCam,
				@idTipoPan,
				@Recibo
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

create procedure sp_Corte(
@fechaHoy date
)as
begin
 SET DATEFORMAT dmy;  

   select
	convert(Char(10), ES.FechaInicio,103)[FechaRegistro], E.Cedula, E.NombreCompleto[NombreCompleto], C.NombreCurso[Curso], 
	H.Hora[Horario], D.Dia[Día], ES.MontoTotal[MontoTotal], T.Tipo[TipoPago], CO.Descripcion[Concepto],
	ES.Banco, ES.Referencia, ES.Estado, Es.NumeroClase, ES.NroRecibo[Recibo], CONVERT(CHAR(10), ES.FechaFin, 103)[FechaVencimiento]
	from Estado_de_Cuenta ES
	inner join Estudiantes E on E.idEstudiantes = ES.idEstudiantes
	inner join Concepto CO on CO.idConcepto = ES.idConcepto
	inner join Cursos C on C.idCursos = ES.idCursos
	inner join Horarios H on H.idHorario = ES.idHorario
	inner join Dias D on D.idDias = ES.idDias
	inner join Tipos T on T.idTipos = ES.idTipos
	WHERE ES.FechaInicio = @fechaHoy
END
GO

create procedure sp_ReportedeUniformesC(
@fechaHoy date
)
as
begin
	set dateformat dmy;  

	select
	E.idestudiantes, convert(Char(10), Uni.FechaPago,103)[FechaRegistro], E.Cedula, E.NombreCompleto[NombreCompleto], C.NombreCurso[Curso],
	Uni.MontoTotal[MontoTotal], T.Tipo[TipoPago], CO.Descripcion[Concepto],
	Uni.Banco, Uni.Referencia, Uni.NroRecibo[Recibo], Uni.Estado
	from Uniformes Uni
	inner join Estudiantes E on E.idEstudiantes = Uni.idEstudiante
	inner join Concepto CO on CO.idConcepto = Uni.idConcepto
	inner join Cursos C on C.idCursos = Uni.idCursos
	inner join Tipos T on T.idTipos = Uni.idTipos
	where Uni.Estado = 1 and Uni.FechaPago = @fechaHoy
end
go

create procedure sp_AGCurso(
@NombreCurso varchar(50),
@duracionCurso int,
@Resultado     BIT OUTPUT,
@Mensaje       VARCHAR(500) OUTPUT
)as
begin
	BEGIN TRY
        BEGIN TRANSACTION 
            INSERT INTO Cursos 
            (
                NombreCurso,
				duracionCurso
            )
            values
			(
				@NombreCurso,
				@duracionCurso
			)

        COMMIT TRANSACTION

        SET @Resultado = 1;
        SET @Mensaje = 'Curso registrado correctamente.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION 
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
go

create procedure sp_RegistrarUsuario(
@NombreCompleto varchar(50),
@Documento varchar(50),
@Clave varchar(50),
@idrol int,
@Estado bit,
@idResultado int output,
@Mensaje varchar(500) output
)as
begin
	begin try
	begin transaction
	set @idResultado = 0;
	set @Mensaje = '';

	if not exists (select * from Usuario where NroDocumento = @Documento)
	begin
		insert into Usuario (NombreCompleto, NroDocumento, Clave, idrol, Estado)
		values (@NombreCompleto, @Documento, @Clave, @idrol, @Estado)

		set @idResultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede repetir la cédula para más de un usuario'
	commit transaction
		SET @idResultado = 1;
        SET @Mensaje = 'Usuario registrado exitosamente.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION 
        SET @idResultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
go

create procedure sp_EditarUsuario(
@idUsuario int,
@NombreCompleto varchar(50),
@Documento varchar(50),
@Clave varchar(50),
@idrol int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
 begin try
 begin transaction
	set @Resultado = 0;
	set @Mensaje = '';

	if not exists (select * from Usuario where NroDocumento = @Documento and idUsuario != @idUsuario)
	begin
		update Usuario set 
		NombreCompleto = @NombreCompleto,
		NroDocumento = @Documento,
		Clave = @Clave, 
		idrol = @idrol,
		Estado = @Estado
		where idUsuario = @idUsuario

		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede repetir la cédula para más de un usuario.'
	commit transaction
		SET @Resultado = 1;
        SET @Mensaje = 'Usuario editado.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION 
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
go

create procedure sp_EliminarUsuario(
@idUsuario int,
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	begin try
	begin transaction
	set @Resultado = 0;
	set @Mensaje = '';

	delete from Usuario where idUsuario = @idUsuario
	commit transaction
		SET @Resultado = 1;
        SET @Mensaje = 'Usuario eliminado.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION 
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
go

alter procedure sp_ReportedeEstudiantes(
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
	ES.Banco, ES.Referencia, ES.Estado, Es.NumeroClase, ES.NroRecibo[Recibo], CONVERT(CHAR(10), ES.FechaFin, 103)[FechaVencimiento]
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

alter PROCEDURE sp_ReportedeEstudiantesPendientesHoy(
@FechaHoy DATE,
@idCurso INT
)AS
BEGIN
    SET DATEFORMAT dmy;  

   select
	convert(Char(10), ES.FechaInicio,103)[FechaRegistro], E.Cedula, E.NombreCompleto[NombreCompleto], C.NombreCurso[Curso], 
	H.Hora[Horario], D.Dia[Día], ES.MontoTotal[MontoTotal], T.Tipo[TipoPago], CO.Descripcion[Concepto],
	ES.Banco, ES.Referencia, ES.Estado, Es.NumeroClase, ES.NroRecibo[Recibo], CONVERT(CHAR(10), ES.FechaFin, 103)[FechaVencimiento]
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

alter procedure sp_ReportedeUniformes
as
begin
	set dateformat dmy;  

	select
	E.idestudiantes, convert(Char(10), Uni.FechaPago,103)[FechaRegistro], E.Cedula, E.NombreCompleto[NombreCompleto], C.NombreCurso[Curso],
	Uni.MontoTotal[MontoTotal], T.Tipo[TipoPago], CO.Descripcion[Concepto],
	Uni.Banco, Uni.Referencia, Uni.NroRecibo[Recibo], Uni.Estado
	from Uniformes Uni
	inner join Estudiantes E on E.idEstudiantes = Uni.idEstudiante
	inner join Concepto CO on CO.idConcepto = Uni.idConcepto
	inner join Cursos C on C.idCursos = Uni.idCursos
	inner join Tipos T on T.idTipos = Uni.idTipos
	where Uni.Estado = 1
end
go

update Cursos set NombreCurso = 'Enfermeria' where idCursos = 2
go

update Cursos set NombreCurso = 'Odontologia' where idCursos = 3
go

update Cursos set NombreCurso = 'Refrigeracion' where idCursos = 6
go

update Dias set Dia = 'Miercoles' where idDias = 3
go

update Dias set Dia = 'Sabado' where idDias = 3
go

update Tipos set Tipo = 'Bolivares en efectivo' where idTipos = 2
go

update Tipos set Tipo = 'Deposito' where idTipos = 4
go

update Tipos set Tipo = 'Pago movil' where idTipos = 5
go

CREATE TABLE Licencias
(
    IdLicencia INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(100) NOT NULL,
    FechaUltimoDesbloqueo DATETIME NOT NULL,
    Estado BIT NOT NULL DEFAULT 1  -- 1: Activo, 0: Inactivo (opcional)
);
go 

insert into Licencias(Codigo, FechaUltimoDesbloqueo, Estado) values('2211500231403581', getdate(), 1)
go
select * from Licencias
create procedure ObtenerUsuario(
@Mensaje varchar(500) output
)
as 
begin 
	SELECT u.idUsuario,u.NroDocumento,u.NombreCompleto,u.Clave,u.Estado,r.idrol,r.descripcion from Usuario u 
	inner join rol r on r.idrol = u.idrol
end