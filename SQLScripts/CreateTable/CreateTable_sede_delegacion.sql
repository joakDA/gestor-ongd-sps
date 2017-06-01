USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[sede_delegacion]    Script Date: 29/05/2017 21:17:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sede_delegacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[direccion] [nvarchar](150) NOT NULL,
	[codigoPostal] [nvarchar](5) NOT NULL,
	[localidad] [nvarchar](75) NOT NULL,
	[provincia] [nvarchar](75) NOT NULL,
	[pais] [nvarchar](100) NOT NULL,
	[personaContacto] [nvarchar](200) NULL,
	[emailContacto] [nvarchar](150) NULL,
	[telefonoContacto] [nvarchar](15) NULL,
 CONSTRAINT [PK_sede_delegacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


