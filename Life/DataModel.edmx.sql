
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/02/2016 12:51:30
-- Generated from EDMX file: E:\Разработка на платформе .NET\C#\Life\Life\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LifeBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PlayerPlay]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaySet] DROP CONSTRAINT [FK_PlayerPlay];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayCoords]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoordsSet] DROP CONSTRAINT [FK_PlayCoords];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PlayerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerSet];
GO
IF OBJECT_ID(N'[dbo].[CoordsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoordsSet];
GO
IF OBJECT_ID(N'[dbo].[PlaySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaySet];
GO
IF OBJECT_ID(N'[dbo].[MSreplication_options]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSreplication_options];
GO
IF OBJECT_ID(N'[dbo].[spt_fallback_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_fallback_db];
GO
IF OBJECT_ID(N'[dbo].[spt_fallback_dev]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_fallback_dev];
GO
IF OBJECT_ID(N'[dbo].[spt_fallback_usg]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_fallback_usg];
GO
IF OBJECT_ID(N'[dbo].[spt_monitor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spt_monitor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CoordsSet'
CREATE TABLE [dbo].[CoordsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CoordX] int  NOT NULL,
    [CoordY] int  NOT NULL,
    [PlayId] int  NOT NULL,
    [Generation] int  NOT NULL
);
GO

-- Creating table 'PlaySet'
CREATE TABLE [dbo].[PlaySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Toy] nvarchar(max)  NOT NULL,
    [PlayerId] int  NOT NULL
);
GO

-- Creating table 'MSreplication_options'
CREATE TABLE [dbo].[MSreplication_options] (
    [optname] nvarchar(128)  NOT NULL,
    [value] bit  NOT NULL,
    [major_version] int  NOT NULL,
    [minor_version] int  NOT NULL,
    [revision] int  NOT NULL,
    [install_failures] int  NOT NULL
);
GO

-- Creating table 'spt_fallback_db'
CREATE TABLE [dbo].[spt_fallback_db] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_dbid] smallint  NULL,
    [name] varchar(30)  NOT NULL,
    [dbid] smallint  NOT NULL,
    [status] smallint  NOT NULL,
    [version] smallint  NOT NULL
);
GO

-- Creating table 'spt_fallback_dev'
CREATE TABLE [dbo].[spt_fallback_dev] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_low] int  NULL,
    [xfallback_drive] char(2)  NULL,
    [low] int  NOT NULL,
    [high] int  NOT NULL,
    [status] smallint  NOT NULL,
    [name] varchar(30)  NOT NULL,
    [phyname] varchar(127)  NOT NULL
);
GO

-- Creating table 'spt_fallback_usg'
CREATE TABLE [dbo].[spt_fallback_usg] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_vstart] int  NULL,
    [dbid] smallint  NOT NULL,
    [segmap] int  NOT NULL,
    [lstart] int  NOT NULL,
    [sizepg] int  NOT NULL,
    [vstart] int  NOT NULL
);
GO

-- Creating table 'spt_monitor'
CREATE TABLE [dbo].[spt_monitor] (
    [lastrun] datetime  NOT NULL,
    [cpu_busy] int  NOT NULL,
    [io_busy] int  NOT NULL,
    [idle] int  NOT NULL,
    [pack_received] int  NOT NULL,
    [pack_sent] int  NOT NULL,
    [connections] int  NOT NULL,
    [pack_errors] int  NOT NULL,
    [total_read] int  NOT NULL,
    [total_write] int  NOT NULL,
    [total_errors] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoordsSet'
ALTER TABLE [dbo].[CoordsSet]
ADD CONSTRAINT [PK_CoordsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaySet'
ALTER TABLE [dbo].[PlaySet]
ADD CONSTRAINT [PK_PlaySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [optname], [value], [major_version], [minor_version], [revision], [install_failures] in table 'MSreplication_options'
ALTER TABLE [dbo].[MSreplication_options]
ADD CONSTRAINT [PK_MSreplication_options]
    PRIMARY KEY CLUSTERED ([optname], [value], [major_version], [minor_version], [revision], [install_failures] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] in table 'spt_fallback_db'
ALTER TABLE [dbo].[spt_fallback_db]
ADD CONSTRAINT [PK_spt_fallback_db]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] in table 'spt_fallback_dev'
ALTER TABLE [dbo].[spt_fallback_dev]
ADD CONSTRAINT [PK_spt_fallback_dev]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] in table 'spt_fallback_usg'
ALTER TABLE [dbo].[spt_fallback_usg]
ADD CONSTRAINT [PK_spt_fallback_usg]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] ASC);
GO

-- Creating primary key on [lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] in table 'spt_monitor'
ALTER TABLE [dbo].[spt_monitor]
ADD CONSTRAINT [PK_spt_monitor]
    PRIMARY KEY CLUSTERED ([lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PlayerId] in table 'PlaySet'
ALTER TABLE [dbo].[PlaySet]
ADD CONSTRAINT [FK_PlayerPlay]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerPlay'
CREATE INDEX [IX_FK_PlayerPlay]
ON [dbo].[PlaySet]
    ([PlayerId]);
GO

-- Creating foreign key on [PlayId] in table 'CoordsSet'
ALTER TABLE [dbo].[CoordsSet]
ADD CONSTRAINT [FK_PlayCoords]
    FOREIGN KEY ([PlayId])
    REFERENCES [dbo].[PlaySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayCoords'
CREATE INDEX [IX_FK_PlayCoords]
ON [dbo].[CoordsSet]
    ([PlayId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------