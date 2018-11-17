USE [hasslefreedev]
GO

/****** Object: Table [dbo].[RolePermission] Script Date: 11/16/2018 9:19:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RolePermission] (
    [RolePermissionId] INT           NOT NULL,
    [PermissionId]     INT           NOT NULL,
    [RoleId]           INT           NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


