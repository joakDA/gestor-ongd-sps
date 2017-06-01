USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[perfiles]    Script Date: 01/06/2017 18:27:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[perfiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_perfiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del perfil' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'perfiles', @level2type=N'COLUMN',@level2name=N'nombre'
GO


