USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[personas-perfiles]    Script Date: 01/06/2017 18:28:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[personas_perfiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
	[idPerfil] [int] NOT NULL,
 CONSTRAINT [PK_personas-perfiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[personas-perfiles]  WITH NOCHECK ADD  CONSTRAINT [FK_personas-perfiles_perfiles] FOREIGN KEY([idPerfil])
REFERENCES [dbo].[perfiles] ([id])
GO

ALTER TABLE [dbo].[personas-perfiles] CHECK CONSTRAINT [FK_personas-perfiles_perfiles]
GO

ALTER TABLE [dbo].[personas-perfiles]  WITH NOCHECK ADD  CONSTRAINT [FK_personas-perfiles_personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[personas] ([id])
GO

ALTER TABLE [dbo].[personas-perfiles] CHECK CONSTRAINT [FK_personas-perfiles_personas]
GO


