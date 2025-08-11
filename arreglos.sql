use SISTEMA_COBROS2
go

create procedure sp_EditarCurso(
@NombreCurso varchar(50),
@idCursos int,
@duracionCurso int,
@Resultado     BIT OUTPUT,
@Mensaje       VARCHAR(500) OUTPUT
)as
begin
	BEGIN TRY
        BEGIN TRANSACTION 
            update Cursos
			set
			NombreCurso = @NombreCurso,
			duracionCurso = @duracionCurso
			where idCursos = @idCursos

        COMMIT TRANSACTION

        SET @Resultado = 1;
        SET @Mensaje = 'Curso editado correctamente.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION 
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
go

alter PROCEDURE sp_RegistroPagos
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
			
        BEGIN TRANSACTION;
		DECLARE @IdEstudianteFound INT;
        SELECT @IdEstudianteFound = E.idEstudiantes
        FROM Estado_de_Cuenta ES
		inner join Estudiantes E on E.idEstudiantes = ES.idEstudiantes
        WHERE E.Cedula = @Cedula;

        IF (@IdEstudianteFound IS NULL)
        BEGIN
            ROLLBACK TRANSACTION;
            SET @Resultado = 0;
            SET @Mensaje = 'Cédula no registrada.';
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
                    idTipos = @idTipos,
					NroRecibo = @Recibo
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

create PROCEDURE sp_GetStudentData(
    @Cedula VARCHAR(50),
    @Mensaje VARCHAR(500) OUTPUT
	)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificamos si existen registros con la cédula indicada
    IF NOT EXISTS (
        SELECT 1
        FROM Estado_de_Cuenta ES
        INNER JOIN Estudiantes E ON E.idEstudiantes = ES.idEstudiantes
        INNER JOIN Concepto CO ON CO.idConcepto = ES.idConcepto
        INNER JOIN Cursos C ON C.idCursos = ES.idCursos
        INNER JOIN Horarios H ON H.idHorario = ES.idHorario
        INNER JOIN Dias D ON D.idDias = ES.idDias
        INNER JOIN Tipos T ON T.idTipos = ES.idTipos
        WHERE E.Cedula = @Cedula
    )
    BEGIN
        SET @Mensaje = 'Cédula no registrada';
        RETURN;
    END

    -- Si existen registros, se limpia el mensaje (o se le puede dar otro valor)
    SET @Mensaje = '';

    SELECT
        E.Cedula,
        E.NombreCompleto,
        C.NombreCurso,
        H.Hora,
        D.Dia
    FROM Estado_de_Cuenta ES
    INNER JOIN Estudiantes E ON E.idEstudiantes = ES.idEstudiantes
    INNER JOIN Concepto CO ON CO.idConcepto = ES.idConcepto
    INNER JOIN Cursos C ON C.idCursos = ES.idCursos
    INNER JOIN Horarios H ON H.idHorario = ES.idHorario
    INNER JOIN Dias D ON D.idDias = ES.idDias
    INNER JOIN Tipos T ON T.idTipos = ES.idTipos
    WHERE E.Cedula = @Cedula;
END
go

update Contador set contador = 3974
go

update Tipos set Tipo = 'Divisa en efectivo' where idTipos = 1
go

update Tipos set Tipo = 'Punto' where idTipos = 6
go

insert into Tipos(Tipo) values('Divisa electronica')
go

alter PROCEDURE sp_Inscripciones(
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

alter table Estado_de_Cuenta
alter column NroRecibo varchar(500)
go

alter table Uniformes
alter column NroRecibo varchar(500)
go

create table Estudiantes_Viejos(
idEstudiantes int primary key identity,
NombreCompleto varchar (50),
Cedula varchar(50),
Telefono varchar(50),
Nota varchar(500)
)

go


create PROCEDURE sp_InscripcionesViejos(
    @NombreCompleto  VARCHAR(50),
    @Cedula          VARCHAR(50),
    @Telefono        VARCHAR(50),
    @Nota          VARCHAR(500),
    @Resultado       BIT OUTPUT,
    @Mensaje         VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
	begin transaction
			BEGIN
				IF EXISTS (
					SELECT 1 
					FROM Estudiantes_Viejos      
					WHERE Cedula = @Cedula
				)
				BEGIN
					ROLLBACK TRANSACTION;
					SET @Resultado = 0;
					SET @Mensaje = 'Este estudiante ya existe';
					RETURN;
				END;
				end;
		
            -------------------------
            -- 1. Registro del estudiante
            -------------------------
            INSERT INTO Estudiantes_Viejos(NombreCompleto, Cedula, Nota, Telefono)
            VALUES (@NombreCompleto, @Cedula, @Nota, @Telefono);

        COMMIT TRANSACTION;
		set @Resultado = 1;
		set @Mensaje = 'Datos registrados exitosamente';

    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

create procedure sp_EstudianteViejos
as
begin
	select 
	E.idEstudiantes, E.Cedula, E.NombreCompleto[NombreCompleto], E.Nota, E.Telefono
	from Estudiantes_Viejos E

end
go

insert into permiso(idrol, NombreMenu) values(2, 'Registros')
go

