USE [hasslefreedev]
GO

/****** Object: Table [dbo].[UserMaster] Script Date: 11/16/2018 9:18:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserMaster] (
    [UserId]               INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]            NVARCHAR (50)  NOT NULL,
    [LastName]             NVARCHAR (50)  NULL,
    [LoginName]            NVARCHAR (50)  NULL,
    [Email]                NVARCHAR (50)  NULL,
    [Password]             NVARCHAR (50)  NULL,
    [CreatedBy]            INT            NOT NULL,
    [CreatedDateTime]      SMALLDATETIME  NOT NULL,
    [ModifiedBy]           INT            NOT NULL,
    [ModifiedDateTime]     SMALLDATETIME  NOT NULL,
    [LastAccessedDateTime] SMALLDATETIME  NULL,
    [LastAccessedIP]       NVARCHAR (15)  NULL,
    [PasswordToken]        NVARCHAR (MAX) NULL,
    [Active]               BIT            NOT NULL
);


