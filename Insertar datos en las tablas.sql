use SISTEMA_COBROS2

go

insert into permiso(idrol, NombreMenu)
values(1, 'Usuarios') 

delete from Concepto	
where idConcepto = 9

select * from Estado_de_Cuenta

select * from Cursos

select * from Contador2

SELECT * FROM Contador 

DBCC CHECKIDENT ('dbo.Pagos', RESEED, 0);

select count(*) +1 from Pagos

SET IDENTITY_INSERT Cursos ON;
INSERT INTO Cursos (idCursos, NombreCurso, duracionCurso) VALUES (11, 'Barbería', 3);
SET IDENTITY_INSERT Cursos OFF;

update Usuario
set Estado = 1234 where idrol = 1

alter table rol
drop column NroDocumento

alter table Usuario
add NroDocumento varchar(50)

alter table Pagos alter column MontoTotal varchar(50)

drop type Uniformes

drop procedure sp_Corte

drop procedure sp_UniformesRegis

EXEC sp_help 'Pagos'


create table Contador2(
contador INT NOT NULL
)

ALTER TABLE dbo.Uniformes
DROP CONSTRAINT PK__Uniforme__62EA894A03B29B58;

ALTER TABLE dbo.Estado_de_Cuenta
ADD idEstado INT IDENTITY(1,1) NOT NULL;

ALTER TABLE dbo.Uniformes
ADD CONSTRAINT PK_Uniformes PRIMARY KEY (idEstado);


SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Estado_de_Cuenta'
  AND COLUMN_NAME = 'FechaFin';

