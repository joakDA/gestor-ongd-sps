USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[personas]    Script Date: 29/05/2017 20:29:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[personas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellidos] [nvarchar](100) NOT NULL,
	[direccionPostal] [nvarchar](150) NOT NULL,
	[codigoPostal] [nvarchar](5) NOT NULL,
	[localidad] [nvarchar](75) NOT NULL,
	[provincia] [nvarchar](75) NOT NULL,
	[pais] [nvarchar](100) NOT NULL,
	[telefono1] [nvarchar](15) NOT NULL,
	[telefono2] [nvarchar](15) NULL,
	[email] [nvarchar](150) NOT NULL,
	[fechaNacimiento] [datetime] NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


