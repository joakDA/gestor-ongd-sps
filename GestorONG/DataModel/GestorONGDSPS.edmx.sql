
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/15/2017 12:40:27
-- Generated from EDMX file: C:\Users\JOAQUIN-PC\Source\Repos\gestor-ongd-sps\GestorONG\DataModel\GestorONGDSPS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [spinola-solidaria];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_colaboradores_personas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[colaboradores] DROP CONSTRAINT [FK_colaboradores_personas];
GO
IF OBJECT_ID(N'[dbo].[FK_donaciones_colaboradores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[donaciones] DROP CONSTRAINT [FK_donaciones_colaboradores];
GO
IF OBJECT_ID(N'[dbo].[FK_donaciones_periodicidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[donaciones] DROP CONSTRAINT [FK_donaciones_periodicidad];
GO
IF OBJECT_ID(N'[dbo].[FK_personas-perfiles_perfiles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[personas_perfiles] DROP CONSTRAINT [FK_personas-perfiles_perfiles];
GO
IF OBJECT_ID(N'[dbo].[FK_personas-perfiles_personas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[personas_perfiles] DROP CONSTRAINT [FK_personas-perfiles_personas];
GO
IF OBJECT_ID(N'[dbo].[FK_voluntarios_personas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[voluntarios] DROP CONSTRAINT [FK_voluntarios_personas];
GO
IF OBJECT_ID(N'[dbo].[FK_Voluntarios_Sedes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[voluntarios] DROP CONSTRAINT [FK_Voluntarios_Sedes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[colaboradores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[colaboradores];
GO
IF OBJECT_ID(N'[dbo].[donaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[donaciones];
GO
IF OBJECT_ID(N'[dbo].[perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[perfiles];
GO
IF OBJECT_ID(N'[dbo].[periodicidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[periodicidades];
GO
IF OBJECT_ID(N'[dbo].[personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[personas];
GO
IF OBJECT_ID(N'[dbo].[personas_perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[personas_perfiles];
GO
IF OBJECT_ID(N'[dbo].[sede_delegacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sede_delegacion];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[voluntarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[voluntarios];
GO
IF OBJECT_ID(N'[gestor_ongd_sps_prodModelStoreContainer].[vistaColaboradores]', 'U') IS NOT NULL
    DROP TABLE [gestor_ongd_sps_prodModelStoreContainer].[vistaColaboradores];
GO
IF OBJECT_ID(N'[gestor_ongd_sps_prodModelStoreContainer].[voluntario]', 'U') IS NOT NULL
    DROP TABLE [gestor_ongd_sps_prodModelStoreContainer].[voluntario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'perfiles'
CREATE TABLE [dbo].[perfiles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(75)  NOT NULL
);
GO

-- Creating table 'personas'
CREATE TABLE [dbo].[personas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(100)  NOT NULL,
    [apellidos] nvarchar(100)  NOT NULL,
    [direccionPostal] nvarchar(150)  NOT NULL,
    [codigoPostal] nvarchar(5)  NOT NULL,
    [localidad] nvarchar(75)  NOT NULL,
    [provincia] nvarchar(75)  NOT NULL,
    [pais] nvarchar(100)  NOT NULL,
    [telefono1] nvarchar(15)  NOT NULL,
    [telefono2] nvarchar(15)  NULL,
    [email] nvarchar(150)  NOT NULL,
    [fechaNacimiento] datetime  NULL
);
GO

-- Creating table 'personas_perfiles'
CREATE TABLE [dbo].[personas_perfiles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idPersona] int  NULL,
    [idPerfil] int  NULL
);
GO

-- Creating table 'sede_delegacion'
CREATE TABLE [dbo].[sede_delegacion] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(100)  NOT NULL,
    [direccion] nvarchar(150)  NOT NULL,
    [codigoPostal] nvarchar(5)  NOT NULL,
    [localidad] nvarchar(75)  NOT NULL,
    [provincia] nvarchar(75)  NOT NULL,
    [pais] nvarchar(100)  NOT NULL,
    [personaContacto] nvarchar(200)  NULL,
    [emailContacto] nvarchar(150)  NULL,
    [telefonoContacto] nvarchar(20)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'voluntario'
CREATE TABLE [dbo].[voluntario] (
    [id] int  NOT NULL,
    [nombre] nvarchar(100)  NOT NULL,
    [apellidos] nvarchar(100)  NOT NULL,
    [direccionPostal] nvarchar(150)  NOT NULL,
    [codigoPostal] nvarchar(5)  NOT NULL,
    [localidad] nvarchar(75)  NOT NULL,
    [provincia] nvarchar(75)  NOT NULL,
    [pais] nvarchar(100)  NOT NULL,
    [telefono1] nvarchar(15)  NOT NULL,
    [telefono2] nvarchar(15)  NULL,
    [email] nvarchar(150)  NOT NULL,
    [fechaNacimiento] datetime  NULL,
    [fechaAlta] datetime  NOT NULL,
    [Sede] nvarchar(100)  NOT NULL,
    [Perfiles] nvarchar(75)  NOT NULL
);
GO

-- Creating table 'colaboradores'
CREATE TABLE [dbo].[colaboradores] (
    [idColaborador] int IDENTITY(1,1) NOT NULL,
    [CIF_NIF] nvarchar(9)  NOT NULL,
    [CuentaBancaria] nvarchar(24)  NOT NULL
);
GO

-- Creating table 'donaciones'
CREATE TABLE [dbo].[donaciones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [cantidad] real  NULL,
    [fechaAlta] datetime  NOT NULL,
    [idColaborador] int  NOT NULL,
    [idPeriodicidad] int  NOT NULL
);
GO

-- Creating table 'periodicidades'
CREATE TABLE [dbo].[periodicidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'vistaColaboradores'
CREATE TABLE [dbo].[vistaColaboradores] (
    [id] int  NOT NULL,
    [nombre] nvarchar(100)  NOT NULL,
    [apellidos] nvarchar(100)  NOT NULL,
    [direccionPostal] nvarchar(150)  NOT NULL,
    [codigoPostal] nvarchar(5)  NOT NULL,
    [localidad] nvarchar(75)  NOT NULL,
    [provincia] nvarchar(75)  NOT NULL,
    [pais] nvarchar(100)  NOT NULL,
    [telefono1] nvarchar(15)  NOT NULL,
    [telefono2] nvarchar(15)  NULL,
    [email] nvarchar(150)  NOT NULL,
    [fechaNacimiento] datetime  NULL,
    [CIF_NIF] nvarchar(9)  NOT NULL,
    [CuentaBancaria] nvarchar(24)  NOT NULL,
    [Perfiles] nvarchar(75)  NOT NULL,
    [cantidad] real  NOT NULL,
    [fechaAlta] datetime  NOT NULL,
    [Periodicidad] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'personas_voluntarios'
CREATE TABLE [dbo].[personas_voluntarios] (
    [fechaAlta] datetime  NOT NULL,
    [sede] int  NULL,
    [id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'perfiles'
ALTER TABLE [dbo].[perfiles]
ADD CONSTRAINT [PK_perfiles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'personas'
ALTER TABLE [dbo].[personas]
ADD CONSTRAINT [PK_personas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'personas_perfiles'
ALTER TABLE [dbo].[personas_perfiles]
ADD CONSTRAINT [PK_personas_perfiles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'sede_delegacion'
ALTER TABLE [dbo].[sede_delegacion]
ADD CONSTRAINT [PK_sede_delegacion]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id], [nombre], [apellidos], [direccionPostal], [codigoPostal], [localidad], [provincia], [pais], [telefono1], [email], [fechaAlta], [Sede], [Perfiles] in table 'voluntario'
ALTER TABLE [dbo].[voluntario]
ADD CONSTRAINT [PK_voluntario]
    PRIMARY KEY CLUSTERED ([id], [nombre], [apellidos], [direccionPostal], [codigoPostal], [localidad], [provincia], [pais], [telefono1], [email], [fechaAlta], [Sede], [Perfiles] ASC);
GO

-- Creating primary key on [idColaborador] in table 'colaboradores'
ALTER TABLE [dbo].[colaboradores]
ADD CONSTRAINT [PK_colaboradores]
    PRIMARY KEY CLUSTERED ([idColaborador] ASC);
GO

-- Creating primary key on [id] in table 'donaciones'
ALTER TABLE [dbo].[donaciones]
ADD CONSTRAINT [PK_donaciones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'periodicidades'
ALTER TABLE [dbo].[periodicidades]
ADD CONSTRAINT [PK_periodicidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [nombre], [apellidos], [direccionPostal], [codigoPostal], [localidad], [provincia], [pais], [telefono1], [email], [CIF_NIF], [CuentaBancaria], [Perfiles], [cantidad], [fechaAlta], [Periodicidad] in table 'vistaColaboradores'
ALTER TABLE [dbo].[vistaColaboradores]
ADD CONSTRAINT [PK_vistaColaboradores]
    PRIMARY KEY CLUSTERED ([id], [nombre], [apellidos], [direccionPostal], [codigoPostal], [localidad], [provincia], [pais], [telefono1], [email], [CIF_NIF], [CuentaBancaria], [Perfiles], [cantidad], [fechaAlta], [Periodicidad] ASC);
GO

-- Creating primary key on [id] in table 'personas_voluntarios'
ALTER TABLE [dbo].[personas_voluntarios]
ADD CONSTRAINT [PK_personas_voluntarios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idPerfil] in table 'personas_perfiles'
ALTER TABLE [dbo].[personas_perfiles]
ADD CONSTRAINT [FK_personas_perfiles_perfiles]
    FOREIGN KEY ([idPerfil])
    REFERENCES [dbo].[perfiles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_personas_perfiles_perfiles'
CREATE INDEX [IX_FK_personas_perfiles_perfiles]
ON [dbo].[personas_perfiles]
    ([idPerfil]);
GO

-- Creating foreign key on [idPersona] in table 'personas_perfiles'
ALTER TABLE [dbo].[personas_perfiles]
ADD CONSTRAINT [FK_personas_perfiles_personas]
    FOREIGN KEY ([idPersona])
    REFERENCES [dbo].[personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_personas_perfiles_personas'
CREATE INDEX [IX_FK_personas_perfiles_personas]
ON [dbo].[personas_perfiles]
    ([idPersona]);
GO

-- Creating foreign key on [sede] in table 'personas_voluntarios'
ALTER TABLE [dbo].[personas_voluntarios]
ADD CONSTRAINT [FK_Voluntarios_Sedes]
    FOREIGN KEY ([sede])
    REFERENCES [dbo].[sede_delegacion]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Voluntarios_Sedes'
CREATE INDEX [IX_FK_Voluntarios_Sedes]
ON [dbo].[personas_voluntarios]
    ([sede]);
GO

-- Creating foreign key on [idColaborador] in table 'colaboradores'
ALTER TABLE [dbo].[colaboradores]
ADD CONSTRAINT [FK_Colaboradores_Personas]
    FOREIGN KEY ([idColaborador])
    REFERENCES [dbo].[personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idColaborador] in table 'donaciones'
ALTER TABLE [dbo].[donaciones]
ADD CONSTRAINT [FK_donaciones_colaboradores]
    FOREIGN KEY ([idColaborador])
    REFERENCES [dbo].[colaboradores]
        ([idColaborador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_donaciones_colaboradores'
CREATE INDEX [IX_FK_donaciones_colaboradores]
ON [dbo].[donaciones]
    ([idColaborador]);
GO

-- Creating foreign key on [idPeriodicidad] in table 'donaciones'
ALTER TABLE [dbo].[donaciones]
ADD CONSTRAINT [FK_donaciones_periodicidad]
    FOREIGN KEY ([idPeriodicidad])
    REFERENCES [dbo].[periodicidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_donaciones_periodicidad'
CREATE INDEX [IX_FK_donaciones_periodicidad]
ON [dbo].[donaciones]
    ([idPeriodicidad]);
GO

-- Creating foreign key on [id] in table 'personas_voluntarios'
ALTER TABLE [dbo].[personas_voluntarios]
ADD CONSTRAINT [FK_voluntarios_inherits_personas]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[personas]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------