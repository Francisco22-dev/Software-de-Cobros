use SISTEMA_COBROS

go



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


exec sp_ReportedeUniformes