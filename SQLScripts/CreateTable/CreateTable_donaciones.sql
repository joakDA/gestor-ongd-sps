USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[donaciones]    Script Date: 30/07/2017 20:43:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[donaciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [float] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[idColaborador] [int] NOT NULL,
	[idPeriodicidad] [int] NOT NULL,
 CONSTRAINT [PK_donaciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[donaciones] ADD  CONSTRAINT [DF_donaciones_fechaAlta]  DEFAULT (getdate()) FOR [fechaAlta]
GO

ALTER TABLE [dbo].[donaciones]  WITH NOCHECK ADD  CONSTRAINT [FK_donaciones_colaboradores] FOREIGN KEY([idColaborador])
REFERENCES [dbo].[colaboradores] ([idColaborador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[donaciones] NOCHECK CONSTRAINT [FK_donaciones_colaboradores]
GO

ALTER TABLE [dbo].[donaciones]  WITH NOCHECK ADD  CONSTRAINT [FK_donaciones_periodicidad] FOREIGN KEY([idPeriodicidad])
REFERENCES [dbo].[periodicidades] ([id])
GO

ALTER TABLE [dbo].[donaciones] NOCHECK CONSTRAINT [FK_donaciones_periodicidad]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id autoincremental de la donación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'donaciones', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Float que representa la cantidad de la donación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'donaciones', @level2type=N'COLUMN',@level2name=N'cantidad'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de alta de la donación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'donaciones', @level2type=N'COLUMN',@level2name=N'fechaAlta'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id del colaborador que ha hecho la donación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'donaciones', @level2type=N'COLUMN',@level2name=N'idColaborador'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id de la periodicidad de la donación (mensual, trimestral, ...)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'donaciones', @level2type=N'COLUMN',@level2name=N'idPeriodicidad'
GO


