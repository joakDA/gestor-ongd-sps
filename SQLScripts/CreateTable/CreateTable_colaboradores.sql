USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[colaboradores]    Script Date: 30/07/2017 20:44:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[colaboradores](
	[CIF_NIF] [nvarchar](9) NOT NULL,
	[CuentaBancaria] [nvarchar](24) NOT NULL,
	[idColaborador] [int] NOT NULL,
 CONSTRAINT [PK_colaboradores_id] PRIMARY KEY CLUSTERED 
(
	[idColaborador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[colaboradores] ADD  DEFAULT ((-1)) FOR [idColaborador]
GO

ALTER TABLE [dbo].[colaboradores]  WITH NOCHECK ADD  CONSTRAINT [FK_colaboradores_personas] FOREIGN KEY([idColaborador])
REFERENCES [dbo].[personas] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[colaboradores] NOCHECK CONSTRAINT [FK_colaboradores_personas]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CIF o NIF del colaborador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'colaboradores', @level2type=N'COLUMN',@level2name=N'CIF_NIF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cuenta Bancaria del Colaborador en Formato IBAN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'colaboradores', @level2type=N'COLUMN',@level2name=N'CuentaBancaria'
GO


