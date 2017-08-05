USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[sede_delegacion]    Script Date: 29/07/2017 17:39:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sede_delegacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[direccion] [nvarchar](150) NULL,
	[codigoPostal] [nvarchar](5) NULL,
	[localidad] [nvarchar](75) NOT NULL,
	[provincia] [nvarchar](75) NOT NULL,
	[pais] [nvarchar](100) NOT NULL,
	[personaContacto] [nvarchar](200) NULL,
	[emailContacto] [nvarchar](150) NULL,
	[telefonoContacto] [nvarchar](20) NULL,
 CONSTRAINT [PK_sede_delegacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[sede_delegacion] ADD  CONSTRAINT [DF_sede_delegacion_personaContacto]  DEFAULT ('') FOR [personaContacto]
GO

ALTER TABLE [dbo].[sede_delegacion] ADD  CONSTRAINT [DF_sede_delegacion_emailContacto]  DEFAULT ('') FOR [emailContacto]
GO

ALTER TABLE [dbo].[sede_delegacion] ADD  CONSTRAINT [DF_sede_delegacion_telefonoContacto]  DEFAULT ('') FOR [telefonoContacto]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Almacena los datos de una sede o delegación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sede_delegacion'
GO


