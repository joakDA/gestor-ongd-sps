USE [gestor_ongd_sps_prod]
GO

/****** Object:  View [dbo].[voluntario]    Script Date: 10/06/2017 18:22:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[voluntario]
AS
SELECT						dbo.personas.id, dbo.personas.nombre, dbo.personas.apellidos, dbo.personas.direccionPostal, dbo.personas.codigoPostal, dbo.personas.localidad, dbo.personas.provincia, 
                         dbo.personas.pais, dbo.personas.telefono1, dbo.personas.telefono2, dbo.personas.email, dbo.personas.fechaNacimiento, dbo.voluntarios.fechaAlta, dbo.perfiles.nombre AS Perfiles, 
                         dbo.sede_delegacion.nombre AS Sede
FROM            dbo.perfiles INNER JOIN
                         dbo.personas INNER JOIN
                         dbo.personas_perfiles ON dbo.personas.id = dbo.personas_perfiles.idPersona ON dbo.perfiles.id = dbo.personas_perfiles.idPerfil INNER JOIN
                         dbo.voluntarios ON dbo.personas.id = dbo.voluntarios.idPersona INNER JOIN
                         dbo.sede_delegacion ON dbo.voluntarios.sede = dbo.sede_delegacion.id
WHERE        (dbo.perfiles.nombre = N'Voluntario')
WITH CHECK OPTION ;  
GO



