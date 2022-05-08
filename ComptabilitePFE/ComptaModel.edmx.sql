
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2022 02:55:01
-- Generated from EDMX file: C:\Users\ayoub\Desktop\PFE\ComptabilitePFE\ComptabilitePFE\ComptaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ComptaPFE];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Exercice_Exercice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exercice] DROP CONSTRAINT [FK_Exercice_Exercice];
GO
IF OBJECT_ID(N'[dbo].[FK_Exercice_Societe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exercice] DROP CONSTRAINT [FK_Exercice_Societe];
GO
IF OBJECT_ID(N'[dbo].[FK_Journal_Journal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Journal] DROP CONSTRAINT [FK_Journal_Journal];
GO
IF OBJECT_ID(N'[dbo].[FK_ParametrageBilan_RubriqueBilan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParametrageBilan] DROP CONSTRAINT [FK_ParametrageBilan_RubriqueBilan];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Exercice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exercice];
GO
IF OBJECT_ID(N'[dbo].[Journal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Journal];
GO
IF OBJECT_ID(N'[dbo].[LignePieceComptable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LignePieceComptable];
GO
IF OBJECT_ID(N'[dbo].[ParametrageBilan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParametrageBilan];
GO
IF OBJECT_ID(N'[dbo].[ParametrageEtatResultat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParametrageEtatResultat];
GO
IF OBJECT_ID(N'[dbo].[PieceComptable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PieceComptable];
GO
IF OBJECT_ID(N'[dbo].[PlanComptable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanComptable];
GO
IF OBJECT_ID(N'[dbo].[RubriqueBilan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RubriqueBilan];
GO
IF OBJECT_ID(N'[dbo].[RubriqueEtatResultat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RubriqueEtatResultat];
GO
IF OBJECT_ID(N'[dbo].[Societe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Societe];
GO
IF OBJECT_ID(N'[dbo].[Utilisateur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Utilisateur];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [CodeClient] nvarchar(30)  NOT NULL,
    [RaisonSociale] nvarchar(300)  NOT NULL,
    [Contact] nvarchar(30)  NOT NULL,
    [Email] nvarchar(30)  NOT NULL,
    [Adresse] nvarchar(300)  NOT NULL,
    [Tel1] nvarchar(30)  NOT NULL,
    [Tel2] nvarchar(30)  NOT NULL,
    [MatriculeFiscale] nvarchar(30)  NOT NULL,
    [NbSociete] nvarchar(30)  NOT NULL,
    [DateCreation] datetime  NOT NULL,
    [Observation] nvarchar(300)  NOT NULL
);
GO

-- Creating table 'Exercice'
CREATE TABLE [dbo].[Exercice] (
    [CodeSociete] nvarchar(10)  NOT NULL,
    [CodeExercice] nvarchar(4)  NOT NULL,
    [DateDebut] datetime  NOT NULL,
    [DateFin] datetime  NOT NULL,
    [Cloturer] bit  NOT NULL,
    [TypeSaisie] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'Journal'
CREATE TABLE [dbo].[Journal] (
    [CodeSociete] nvarchar(10)  NOT NULL,
    [CodeJournal] nvarchar(5)  NOT NULL,
    [Libelle] nvarchar(150)  NOT NULL,
    [AutoriserControle] bit  NOT NULL,
    [NumeroCompte] nvarchar(10)  NOT NULL,
    [Tresorerie] bit  NOT NULL,
    [Ouverture] bit  NOT NULL
);
GO

-- Creating table 'LignePieceComptable'
CREATE TABLE [dbo].[LignePieceComptable] (
    [CodeSociete] nvarchar(10)  NOT NULL,
    [CodePiece] nvarchar(10)  NOT NULL,
    [CodeJournal] nvarchar(4)  NOT NULL,
    [CodeExercice] nvarchar(4)  NOT NULL,
    [NumeroCompte] nvarchar(10)  NOT NULL,
    [NumeroOrdre] int  NOT NULL,
    [Debit] decimal(19,3)  NOT NULL,
    [Credit] decimal(19,3)  NOT NULL,
    [Reference] nvarchar(40)  NOT NULL,
    [DateReference] datetime  NULL,
    [NumeroLettrage] nvarchar(6)  NOT NULL,
    [NumeroRapprochement] nvarchar(6)  NULL
);
GO

-- Creating table 'ParametrageBilan'
CREATE TABLE [dbo].[ParametrageBilan] (
    [CodeRubrique] nvarchar(6)  NOT NULL,
    [NumeroCompte] nvarchar(10)  NOT NULL,
    [Sens] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'ParametrageEtatResultat'
CREATE TABLE [dbo].[ParametrageEtatResultat] (
    [CodeRubrique] nvarchar(6)  NOT NULL,
    [NumeroCompte] nvarchar(10)  NOT NULL,
    [Sens] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'PieceComptable'
CREATE TABLE [dbo].[PieceComptable] (
    [CodeSociete] nvarchar(10)  NOT NULL,
    [CodePiece] nvarchar(10)  NOT NULL,
    [CodeJournal] nvarchar(4)  NOT NULL,
    [CodeExercice] nvarchar(4)  NOT NULL,
    [DateEcriture] datetime  NOT NULL,
    [TotalPiece] decimal(18,3)  NOT NULL,
    [LibelleEcriture] nvarchar(300)  NOT NULL,
    [NomUtilisateur] nvarchar(20)  NOT NULL,
    [DateCreation] datetime  NOT NULL,
    [HeureCreation] datetime  NOT NULL
);
GO

-- Creating table 'PlanComptable'
CREATE TABLE [dbo].[PlanComptable] (
    [CodeSociete] nvarchar(10)  NOT NULL,
    [NumeroCompte] nvarchar(10)  NOT NULL,
    [Libelle] nvarchar(300)  NOT NULL,
    [TypeCompte] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'RubriqueBilan'
CREATE TABLE [dbo].[RubriqueBilan] (
    [CodeRubrique] nvarchar(6)  NOT NULL,
    [CodeRubriqueParent] nvarchar(6)  NOT NULL,
    [Libelle] nvarchar(60)  NOT NULL,
    [Nature] nvarchar(1)  NOT NULL,
    [Type] nvarchar(1)  NOT NULL,
    [Note] nvarchar(5)  NOT NULL,
    [Signe] nvarchar(1)  NOT NULL,
    [Justification] bit  NOT NULL
);
GO

-- Creating table 'RubriqueEtatResultat'
CREATE TABLE [dbo].[RubriqueEtatResultat] (
    [CodeRubrique] nvarchar(6)  NOT NULL,
    [CodeRubriqueParent] nvarchar(6)  NOT NULL,
    [Libelle] nvarchar(60)  NOT NULL,
    [Nature] nvarchar(1)  NOT NULL,
    [Type] nvarchar(1)  NOT NULL,
    [Note] nvarchar(5)  NOT NULL,
    [Signe] nvarchar(1)  NOT NULL,
    [Justification] bit  NOT NULL
);
GO

-- Creating table 'Societe'
CREATE TABLE [dbo].[Societe] (
    [CodeSociete] nvarchar(10)  NOT NULL,
    [CodeClient] nvarchar(30)  NOT NULL,
    [RaisonSociete] nvarchar(300)  NOT NULL,
    [CapitalSociete] decimal(18,3)  NOT NULL,
    [Adresse] nvarchar(300)  NOT NULL,
    [Tel1] nvarchar(30)  NOT NULL,
    [Tel2] nvarchar(30)  NOT NULL,
    [Email] nvarchar(30)  NOT NULL,
    [MatriculeFiscale] nvarchar(30)  NOT NULL,
    [Observation] nvarchar(300)  NOT NULL,
    [DateCreation] datetime  NOT NULL
);
GO

-- Creating table 'Utilisateur'
CREATE TABLE [dbo].[Utilisateur] (
    [NomUtilisateur] nvarchar(30)  NOT NULL,
    [CodeClient] nvarchar(30)  NOT NULL,
    [NomPrenom] nvarchar(300)  NOT NULL,
    [MotPasse] nvarchar(30)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CodeClient] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([CodeClient] ASC);
GO

-- Creating primary key on [CodeSociete], [CodeExercice] in table 'Exercice'
ALTER TABLE [dbo].[Exercice]
ADD CONSTRAINT [PK_Exercice]
    PRIMARY KEY CLUSTERED ([CodeSociete], [CodeExercice] ASC);
GO

-- Creating primary key on [CodeSociete], [CodeJournal] in table 'Journal'
ALTER TABLE [dbo].[Journal]
ADD CONSTRAINT [PK_Journal]
    PRIMARY KEY CLUSTERED ([CodeSociete], [CodeJournal] ASC);
GO

-- Creating primary key on [CodeSociete], [CodePiece], [CodeJournal], [CodeExercice], [NumeroCompte], [NumeroOrdre] in table 'LignePieceComptable'
ALTER TABLE [dbo].[LignePieceComptable]
ADD CONSTRAINT [PK_LignePieceComptable]
    PRIMARY KEY CLUSTERED ([CodeSociete], [CodePiece], [CodeJournal], [CodeExercice], [NumeroCompte], [NumeroOrdre] ASC);
GO

-- Creating primary key on [CodeRubrique], [NumeroCompte] in table 'ParametrageBilan'
ALTER TABLE [dbo].[ParametrageBilan]
ADD CONSTRAINT [PK_ParametrageBilan]
    PRIMARY KEY CLUSTERED ([CodeRubrique], [NumeroCompte] ASC);
GO

-- Creating primary key on [CodeRubrique], [NumeroCompte] in table 'ParametrageEtatResultat'
ALTER TABLE [dbo].[ParametrageEtatResultat]
ADD CONSTRAINT [PK_ParametrageEtatResultat]
    PRIMARY KEY CLUSTERED ([CodeRubrique], [NumeroCompte] ASC);
GO

-- Creating primary key on [CodeSociete], [CodePiece], [CodeJournal], [CodeExercice] in table 'PieceComptable'
ALTER TABLE [dbo].[PieceComptable]
ADD CONSTRAINT [PK_PieceComptable]
    PRIMARY KEY CLUSTERED ([CodeSociete], [CodePiece], [CodeJournal], [CodeExercice] ASC);
GO

-- Creating primary key on [CodeSociete], [NumeroCompte] in table 'PlanComptable'
ALTER TABLE [dbo].[PlanComptable]
ADD CONSTRAINT [PK_PlanComptable]
    PRIMARY KEY CLUSTERED ([CodeSociete], [NumeroCompte] ASC);
GO

-- Creating primary key on [CodeRubrique] in table 'RubriqueBilan'
ALTER TABLE [dbo].[RubriqueBilan]
ADD CONSTRAINT [PK_RubriqueBilan]
    PRIMARY KEY CLUSTERED ([CodeRubrique] ASC);
GO

-- Creating primary key on [CodeRubrique] in table 'RubriqueEtatResultat'
ALTER TABLE [dbo].[RubriqueEtatResultat]
ADD CONSTRAINT [PK_RubriqueEtatResultat]
    PRIMARY KEY CLUSTERED ([CodeRubrique] ASC);
GO

-- Creating primary key on [CodeSociete] in table 'Societe'
ALTER TABLE [dbo].[Societe]
ADD CONSTRAINT [PK_Societe]
    PRIMARY KEY CLUSTERED ([CodeSociete] ASC);
GO

-- Creating primary key on [NomUtilisateur] in table 'Utilisateur'
ALTER TABLE [dbo].[Utilisateur]
ADD CONSTRAINT [PK_Utilisateur]
    PRIMARY KEY CLUSTERED ([NomUtilisateur] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CodeRubrique] in table 'ParametrageBilan'
ALTER TABLE [dbo].[ParametrageBilan]
ADD CONSTRAINT [FK_ParametrageBilan_RubriqueBilan]
    FOREIGN KEY ([CodeRubrique])
    REFERENCES [dbo].[RubriqueBilan]
        ([CodeRubrique])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CodeSociete] in table 'Exercice'
ALTER TABLE [dbo].[Exercice]
ADD CONSTRAINT [FK_Exercice_Societe]
    FOREIGN KEY ([CodeSociete])
    REFERENCES [dbo].[Societe]
        ([CodeSociete])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------