USE [gestor_ongd_sps_prod]
GO

/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 23/12/2017 14:42:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO