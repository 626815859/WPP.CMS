
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/05/2018 10:20:56
-- Generated from EDMX file: F:\新建文件夹\net课堂项目\2018\WP.CMS\WP.CMS.Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WP.CMSDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [UserPwd] nvarchar(50)  NULL,
    [UserMail] nvarchar(50)  NULL,
    [RegTime] datetime  NULL
);
GO

-- Creating table 'News'
CREATE TABLE [dbo].[News] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Msg] nvarchar(max)  NULL,
    [SubDateTime] datetime  NULL,
    [Author] nvarchar(50)  NULL,
    [ImagePath] nvarchar(50)  NULL
);
GO

-- Creating table 'NewsComments'
CREATE TABLE [dbo].[NewsComments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NewsID] int  NULL,
    [Msg] nvarchar(max)  NULL,
    [CreatDateTime] datetime  NULL,
    [UserInfo_Id] int  NOT NULL,
    [News_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [PK_News]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NewsComments'
ALTER TABLE [dbo].[NewsComments]
ADD CONSTRAINT [PK_NewsComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_Id] in table 'NewsComments'
ALTER TABLE [dbo].[NewsComments]
ADD CONSTRAINT [FK_UserInfoNewsComments]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoNewsComments'
CREATE INDEX [IX_FK_UserInfoNewsComments]
ON [dbo].[NewsComments]
    ([UserInfo_Id]);
GO

-- Creating foreign key on [News_Id] in table 'NewsComments'
ALTER TABLE [dbo].[NewsComments]
ADD CONSTRAINT [FK_NewsNewsComments]
    FOREIGN KEY ([News_Id])
    REFERENCES [dbo].[News]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NewsNewsComments'
CREATE INDEX [IX_FK_NewsNewsComments]
ON [dbo].[NewsComments]
    ([News_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------