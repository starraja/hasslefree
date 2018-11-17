USE [hasslefreedev]
GO

/****** Object: Table [dbo].[RoleMaster] Script Date: 11/16/2018 9:19:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleMaster] (
    [RoleId]           INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]         VARCHAR (50)  NOT NULL,
    [RoleDescription]  VARCHAR (50)  NULL,
    [Active]           BIT           NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDateTime]  SMALLDATETIME NOT NULL,
    [ModifiedBy]       INT           NOT NULL,
    [ModifiedDateTime] SMALLDATETIME NOT NULL
);


