USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[voluntarios]    Script Date: 29/05/2017 21:17:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[voluntarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[sede] [int] NULL,
 CONSTRAINT [PK_voluntarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[voluntarios] ADD  CONSTRAINT [DF_voluntarios_fechaAlta]  DEFAULT (getdate()) FOR [fechaAlta]
GO

ALTER TABLE [dbo].[voluntarios]  WITH CHECK ADD  CONSTRAINT [FK_Voluntarios_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[personas] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[voluntarios] CHECK CONSTRAINT [FK_Voluntarios_Personas]
GO

ALTER TABLE [dbo].[voluntarios]  WITH CHECK ADD  CONSTRAINT [FK_Voluntarios_Sedes] FOREIGN KEY([sede])
REFERENCES [dbo].[sede_delegacion] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[voluntarios] CHECK CONSTRAINT [FK_Voluntarios_Sedes]
GO


