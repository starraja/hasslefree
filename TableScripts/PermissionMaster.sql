USE [hasslefreedev]
GO

/****** Object: Table [dbo].[PermissionMaster] Script Date: 11/16/2018 9:19:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PermissionMaster] (
    [PermissionId]          INT            IDENTITY (1, 1) NOT NULL,
    [UIELEMENT_CODE]        NVARCHAR (50)  NOT NULL,
    [UIELEMENT_Description] NVARCHAR (MAX) NULL,
    [CreatedBy]             INT            NOT NULL,
    [CreatedDateTime]       SMALLDATETIME  NOT NULL,
    [ModifiedBy]            INT            NOT NULL,
    [ModifiedDateTime]      SMALLDATETIME  NOT NULL
);


